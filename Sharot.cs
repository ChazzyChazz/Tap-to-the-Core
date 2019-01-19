using UnityEngine;
using System.Collections;

public class Sharot : MonoBehaviour {

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
		atkSpeed = 1.30f;

		actualizarSharotBtn ();
	}

	public void actualizarSharotBtn () {
		mainScript.actualizarTabSharotAtk ();
		mainScript.actualizarTabSharotAtkToAdd ();
		mainScript.actualizarTabSharotLevel ();
		mainScript.actualizarTabSharotLevelCost ();
		mainScript.actualizarTabSharotUnlockTxt ();
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
	public void sharotLevelUp () {
		if(player.money >= levelCost){
			level++;
			player.money -= levelCost;

			bobAtkcalculation ();
			bobLevelUpCost ();
			gettinAtkToAdd ();

			actualizarSharotBtn ();
		}
	}

	// Metodo para subir de nivel x10
	public void sharotLevelUp_x10 () {
		if(player.money >= levelCost){
			for(int i = 0; i < 10; i++){
				sharotLevelUp ();
			}
		}
	}

	// Metodo para subir de nivel x100
	public void sharotLevelUp_x100 () {
		if(player.money >= levelCost * 15){
			for(int i = 0; i < 100; i++){
				sharotLevelUp ();
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
		gameStatus.sharotLevel = level;
		gameStatus.sharotBaseAtk = atkBase;
		gameStatus.sharotAtk = atk;
		gameStatus.sharotLevelCostBase = levelCostBase;
		gameStatus.sharotLevelCost = levelCost;
		gameStatus.sharotAtkToAdd = atkToAdd;
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (atk);
		charActivation ();
		passingVariablesToSave ();
		/*if(Input.GetKeyDown(KeyCode.V)){
			Instantiate (attack,attackPosition.transform.position,Quaternion.identity);
			//Debug.Log (attack.transform.position.x);
		}*/
	}
}