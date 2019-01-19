using UnityEngine;
using System.Collections;

public class Weapon01 : MonoBehaviour {
	// Esta arma otorga + atribute% ... ex (lv 1 = 10%) al ataque del personaje osea por toque

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
		actualizarWeaponBtn ();
	}

	// Metodo para actualizar los textos y demas del boton del arma
	void actualizarWeaponBtn () {
		// Btn text
		mainScript.actualizarTabWeapon01Level();
		mainScript.actualizarTabWeapon01Atribute ();
		mainScript.actualizarTabWeapon01LevelCost ();
		mainScript.actualizarTabWeapon01AtributeToAdd ();

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

			weaponAtributeCalculation ();
			weaponAtributeToAddCalculation ();
			weaponLevelCostCalculation ();

			addingAtribute ();

			actualizarWeaponBtn ();
		}
	}

	//
	void passingVariablesToSave () {
		gameStatus.weapon01Level = level;
		gameStatus.weapon01AtributeBase = atributeBase;
		gameStatus.weapon01Atribute = atribute;
		gameStatus.weapon01LevelCostBase = levelCostBase;
		gameStatus.weapon01LevelCost = levelCost;
		gameStatus.weapon01AtributeToAddBase = atributeToAddBase;
		gameStatus.weapon01AtributeToAdd = atributeToAdd;
	}
	
	// Update is called once per frame
	void Update () {
		addingAtribute ();
		passingVariablesToSave ();
	}
}
