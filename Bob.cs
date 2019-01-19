using UnityEngine;
using System.Collections;

public class Bob : MonoBehaviour {

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

	private int upgMultiple_x10 = 10;
	private int upgMultiple_x100 = 100;

	// Scripts variables
	public monsterHp mainScript;
	public Monster monster;
	public Player player;
	public GameStatus gameStatus;

	// Variables tipo GameObject para animacion de ataque
	public GameObject attack;
	public GameObject attackPosition;

	// Use this for initialization
	void Start () {
		atkSpeed = 1f;

		actualizarBobBtn ();
	}

	public void actualizarBobBtn () {
		mainScript.actualizarTabBobAtk ();
		mainScript.actualizarTabBobAtkToAdd ();
		mainScript.actualizarTabBobLevel ();
		mainScript.actualizarTabBobLevelCost ();
		mainScript.actualizarTabBobUnlockTxt ();
		mainScript.actualizarTabPlayerMoney ();

		mainScript.actualizarMoney ();
	}

	// Metodo para calcular el dano x nivel
	void bobAtkcalculation () {
		atk = atkBase * Mathf.Pow(Mathf.Pow(level,1.025f),1.033f);
		//Debug.Log (atk);
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
	public void bobLevelUp () {
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
	public void bobLevelUp_x10 () {
		if(player.money >= levelCost){
			for(int i = 0; i < upgMultiple_x10; i++){
				bobLevelUp ();
			}
		}
	}

	// Metodo para subir de nivel x100
	public void bobLevelUp_x100 () {
		if(player.money >= levelCost * 15){
			for(int i = 0; i < upgMultiple_x100; i++){
				bobLevelUp ();
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
				//monster.hp -= atk;
				atkSpeedCount = 0;
				mainScript.partnerAtkActivation = false;
			}
		}
		if(atkSpeedCount == 0){
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
		gameStatus.bobLevel = level;
		gameStatus.bobBaseAtk = atkBase;
		gameStatus.bobAtk = atk;
		gameStatus.bobLevelCostBase = levelCostBase;
		gameStatus.bobLevelCost = levelCost;
		gameStatus.bobAtkToAdd = atkToAdd;
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

