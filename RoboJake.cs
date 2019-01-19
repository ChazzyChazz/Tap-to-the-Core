using UnityEngine;
using System.Collections;

public class RoboJake : MonoBehaviour {
	// status variables
	public float level;
	public float levelCost;
	public float levelCostBase;
	public float atk;
	public float atkBase;
	public float atkToAdd;
	public float atkSpeed;
	private float atkSpeedCount = 0f;
	public float DPS;

	// Scripts variables
	public monsterHp mainScript;
	public Monster monster;
	public Player player;

	public GameStatus gameStatus;

	//
	public GameObject attack;
	public GameObject attackPosition;

	//
	//public canvasTextController canvasText;

	// Use this for initialization
	void Start () {
		atkSpeed = 1.5f;

		actualizarBobBtn ();
	}

	public void actualizarBobBtn () {
		mainScript.actualizarTabRoboAtk ();
		mainScript.actualizarTabRoboAtkToAdd ();
		mainScript.actualizarTabRoboLevel ();
		mainScript.actualizarTabRoboLevelCost ();
		mainScript.actualizarTabRoboUnlockTxt ();

		mainScript.actualizarTabPlayerMoney ();

		mainScript.actualizarMoney ();
	}

	// Metodo para calcular el dano x nivel
	void bobAtkcalculation () {
		atk = atkBase * Mathf.Pow(Mathf.Pow(level,1.025f),1.033f);
	}

	// Metodo para calcular el dinero necesario para subir de nivel
	void bobLevelUpCost () {
		levelCost = levelCostBase * Mathf.Pow(1.095f,level);
	}

	// Metodo para calcular el dano a anadir en el siguiente nivel
	void gettinAtkToAdd () {
		atkToAdd = atkBase * Mathf.Pow(Mathf.Pow(level + 1,1.025f),1.033f);
	}

	// Metodo para calculo del DPS (damage per second)
	void calculationOfDPS () {
		DPS = atk / atkSpeed;
	}

	// Metodo para subir de nivel
	public void RoboJakeLevelUp () {
		if(player.money >= levelCost){
			level++;
			player.money -= levelCost;

			bobAtkcalculation ();
			bobLevelUpCost ();
			gettinAtkToAdd ();

			actualizarBobBtn ();
		}
	}

	// Metodo para subir de nivel x10
	public void RoboJakeLevelUp_x10 () {
		if(player.money >= levelCost){
			for(int i = 0; i < 10; i++){
				RoboJakeLevelUp ();
			}
		}
	}

	// Metodo para subir de nivel x100
	public void RoboJakeLevelUp_x100 () {
		if(player.money >= levelCost * 15){
			for(int i = 0; i < 100; i++){
				RoboJakeLevelUp ();
			}
		}
	}

	// Metodo para calcular el dano
	void partnerDamage () {
		mainScript = mainScript.GetComponent<monsterHp> ();
		monster = monster.GetComponent<Monster> ();
		if(atkSpeedCount < atkSpeed){
			atkSpeedCount += Time.deltaTime;
			mainScript.partnerAtkActivation = true;
			if(atkSpeedCount >= atkSpeed){
				atkSpeedCount = 0;
				mainScript.partnerAtkActivation = false;
			}
		}
		if (atkSpeedCount == 0) {
			Instantiate (attack, attackPosition.transform.position, Quaternion.identity);
		}
	}

	// Metodo que activa el renderizado o "mostrado" del personaje
	void mostrarCharacter () {
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
	}

	// Metodo que activa el renderizado o "mostrado" del personaje
	void noMostrarCharacter () {
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}

	// Metodo para activar las funciones del personaje y mostrarlo
	void charActivation () {
		if (level > 0) {
			partnerDamage ();
			calculationOfDPS ();
			mostrarCharacter ();
		} else {
			noMostrarCharacter();
		}
	}

	//
	void passingVariablesToSave () {
		gameStatus.roboLevel = level;
		gameStatus.roboBaseAtk = atkBase;
		gameStatus.roboAtk = atk;
		gameStatus.roboLevelCostBase = levelCostBase;
		gameStatus.roboLevelCost = levelCost;
		gameStatus.roboAtkToAdd = atkToAdd;
	}

	// Update is called once per frame
	void Update () {
		charActivation ();
		passingVariablesToSave ();
		/*if(Input.GetKeyDown(KeyCode.V)){
			Instantiate (attack,attackPosition.transform.position,Quaternion.identity);
			//Debug.Log (attack.transform.position.x);
		}*/
	}
}