using UnityEngine;
using System.Collections;

public class DogBotBobby : MonoBehaviour {

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

	// Use this for initialization
	void Start () {
		atkSpeed = 1.5f;

		actualizarBobBtn ();
	}

	public void actualizarBobBtn () {
		mainScript.actualizarTabDogBotAtk ();
		mainScript.actualizarTabDogBotAtkToAdd ();
		mainScript.actualizarTabDogBotLevel ();
		mainScript.actualizarTabDogBotLevelCost ();
		mainScript.actualizarTabDogBotUnlockTxt ();
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
	public void dogBotLevelUp () {
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
	public void dogBotLevelUp_x10 () {
		if(player.money >= levelCost){
			for(int i = 0; i < 10; i++){
				dogBotLevelUp ();
			}
		}
	}

	// Metodo para subir de nivel x100
	public void dogBotLevelUp_x100 () {
		if(player.money >= levelCost * 15){
			for(int i = 0; i < 100; i++){
				dogBotLevelUp ();
			}
		}
	}

	// Metodo para calcular el dano
	void partnerDamage () {
		mainScript = mainScript.GetComponent<monsterHp> ();
		monster = monster.GetComponent<Monster> ();
		if (atkSpeedCount < atkSpeed) {
			atkSpeedCount += Time.deltaTime;
			mainScript.partnerAtkActivation = true;
			if (atkSpeedCount >= atkSpeed) {
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
		gameStatus.dogBotLevel = level;
		gameStatus.dogBotBaseAtk = atkBase;
		gameStatus.dogBotAtk = atk;
		gameStatus.dogBotLevelCostBase = levelCostBase;
		gameStatus.dogBotLevelCost = levelCost;
		gameStatus.dogBotAtkToAdd = atkToAdd;
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