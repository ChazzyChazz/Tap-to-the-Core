using UnityEngine;
using System.Collections;

public class Weapon02 : MonoBehaviour {
	// Esta arma otorga + atribute% ... ex (lv 1 = 15%) al ataque del personaje osea por toque

	// Variables principales
	public float level;// variable para el nivel del arma
	public float levelCost;// variable para el costo de subir de nivel el arma
	public float levelCostBase;// variable para el costo base de subir de nivel el arma
	public float atribute;// aributo que da el arma al desbloquearla
	public float atributeBase;// atributo base
	public float atributeToAdd;// atributo que se aumenta al subir de nivel el arma
	public float atributeToAddBase;// atributo base que se aumenta al subir de nivel el arma
	public float atributeToGet;

	// Variables para otros scripts
	public Player player;
	public monsterHp mainScript;
	public GameStatus gameStatus;

	//
	public GameObject weaponBtn;

	// Use this for initialization
	void Start () {
		level = 1f;
		atributeBase = 15f;
		atribute = atributeBase;
		levelCostBase = 1f;
		levelCost = levelCostBase;
		atributeToAddBase = 15f;
		atributeToAdd = atributeToAddBase;
		//atributeToGet = (player.attack * atribute) / 100;

		//addingAtribute ();

		actualizarWeaponBtn ();
	}

	// Metodo para actualizar los textos y demas del boton del arma
	void actualizarWeaponBtn () {
		// Btn text
		mainScript.actualizarTabWeapon02Level();
		mainScript.actualizarTabWeapon02Atribute ();
		mainScript.actualizarTabWeapon02LevelCost ();
		mainScript.actualizarTabWeapon02AtributeToAdd ();

		//
		mainScript.actualizarAtk();
		mainScript.actualizarTabPlayerAtk ();

		//
		mainScript.actualizarTabPlayerUranium ();
	}

	// Metodo para calcular el costo para subir de nivel
	void weaponLevelCostCalculation () {
		levelCost = levelCostBase * level;
	}

	// Metodo para calcular el atributo al subir de nivel
	void weaponAtributeCalculation () {
		atribute += atributeToAddBase;
	}

	// Metodo para calcular cuanto aumentara el atributo al subir de nivel
	void weaponAtributeToAddCalculation () {
		atributeToAdd = atributeToAddBase;
	}

	//
	public void addingAtribute () {
		if(weaponBtn.activeInHierarchy){
			atributeToGet = (player.attack * atribute) / 100;
		}else{
			atributeToGet = 0;
		}
	}

	// Metodo para subir de nivel
	public void weaponLevelUp () {
		if (player.uranium >= levelCost) {
			level++;
			player.uranium -= levelCost;

			//player.attack += atributeToGet;

			weaponAtributeCalculation ();
			weaponAtributeToAddCalculation ();
			weaponLevelCostCalculation ();

			addingAtribute ();

			actualizarWeaponBtn ();
		}
	}

	//
	void passingVariablesToSave () {
		gameStatus.weapon02Level = level;
		gameStatus.weapon02AtributeBase = atributeBase;
		gameStatus.weapon02Atribute = atribute;
		gameStatus.weapon02LevelCostBase = levelCostBase;
		gameStatus.weapon02LevelCost = levelCost;
		gameStatus.weapon02AtributeToAddBase = atributeToAddBase;
		gameStatus.weapon02AtributeToAdd = atributeToAdd;
	}

	// Update is called once per frame
	void Update () {
		addingAtribute ();
		passingVariablesToSave ();
	}
}