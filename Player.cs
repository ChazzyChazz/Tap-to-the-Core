using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Variables estados del jugador
	public float level;
	public float levelCost;
	public float levelCostBase;
	public float attack;// controla el ataque por toque del jugador
	public float baseAttack;
	public float attackToAdd;
	public float totalAttack;
	public float taps;// controla los toques del jugador
	public float money;// controla el dinero del jugador
	public float totalMoney;// controla el dinero total del jugador en el juego
	public float uranium;// controla los cristales del jugador
	public float crystals;// controla los cristales del jugador
	public float gameTime;
	public float totalGameTime;

	public float criticAttack;//
	public float criticDamagePorcent;//

	private int upgMultiple_x10 = 10;
	private int upgMultiple_x100 = 100;

    // Other Scripts
	public monsterHp mainScript;
	public WeaponsConnector weaponsConnect;
	public GameStatus gameStatus;

	// Use this for initialization
	void Start () {
		criticAttack = attack * criticDamagePorcent;

		weaponsConnect.RefreshPorcent ();

		actualizarPlayerBtn ();
	}

	// Metodo para actualizar todos los textos pertinentes del jugador
	public void actualizarPlayerBtn (){
		//Tab btn text
		mainScript.actualizarTabPlayerLevel ();
		mainScript.actualizarTabPlayerAtk ();
		mainScript.actualizarTabPlayerAtkToAdd ();
		mainScript.actualizarTabPlayerLevelCost ();
		mainScript.actualizarTabPlayerMoney ();
		mainScript.actualizarTabPlayerUranium ();
		mainScript.actualizarTabPlayerCrystals ();

		//Screen Text
		mainScript.actualizarAtk();
		mainScript.actualizarTMdamage ();
		mainScript.actualizarCriticTMdamage ();
		mainScript.actualizarMoney ();

		//Other
		mainScript.actualizarTabAbility00Name();
		mainScript.actualizarTabAbility00WhatToDo ();
	}

	// Metodo para calcular el ataque
	void playerAttackCalculation () {
		attack += (level * baseAttack) - baseAttack;
	}
	// Metodo para calcular el ataque critico
	void playerCriticAttackCalculation () {
		criticAttack = totalAttack * criticDamagePorcent;
	}
	// Metodo para calcular dinero necesario para subir de nivel
	void playerLevelUpCost () {
		levelCost = levelCostBase * Mathf.Pow(1.085f,level);
	}
	// Metodo para calcular el dano a anadir en el siguiente nivel
	void gettingAttackToAdd () {
		attackToAdd = level * baseAttack;
	}

	// Metodo para subir de nivel
	public void playerLevelUp () {
		if (money >= levelCost) {
			level++;
			money -= levelCost;

			playerAttackCalculation ();
			playerCriticAttackCalculation ();
			playerLevelUpCost ();
			gettingAttackToAdd ();

			weaponsConnect.RefreshPorcent ();

		    actualizarPlayerBtn ();
		}
	}

	// Metodo para subir de nivel x10
	public void playerLevelUp_x10 () {
		if (money >= levelCost) {
			for(int i = 0; i < upgMultiple_x10; i++){
				playerLevelUp ();
			}
		}
	}

	// Metodo para subir de nivel x100
	public void playerLevelUp_x100 () {
		if (money >= levelCost * 15) {
			for(int i = 0; i < upgMultiple_x100; i++){
				playerLevelUp ();
			}
		}
	}

	// Metodo para obtener el ataque total del jugador
	void totalAtk () {
		totalAttack = attack + weaponsConnect.OverallAtkPorcentToAdd();
		//Debug.Log (weaponsConnect.OverallAtkPorcentToAdd());
	}

	//
	void calculatingGameTime () {
		gameTime += Time.deltaTime;
		totalGameTime += Time.deltaTime;
	}

	// Variables a igualar para que esten listas para ser guardadas
	void passingVariablesToSave () {
		gameStatus.playerLevel = level;
		gameStatus.playerBaseAttack = baseAttack;
		gameStatus.playerAtk = attack;
		gameStatus.playerLevelCostBase = levelCostBase;
		gameStatus.playerLevelCost = levelCost;
		gameStatus.playerAtkToAdd = attackToAdd;
		gameStatus.playerCriticDamagePorcent = criticDamagePorcent;
		gameStatus.playerTaps = taps;
		gameStatus.playerMoney = money;
		gameStatus.playerTotalMoney = totalMoney;
		gameStatus.playerUranium = uranium;
		gameStatus.playerCrystals = crystals;
		gameStatus.playerGameTime = gameTime;
		gameStatus.playerTotalGameTime = totalGameTime;
	}
		
	// Update is called once per frame
	void Update () {
		totalAtk ();
		playerCriticAttackCalculation ();
		calculatingGameTime ();

		passingVariablesToSave ();
	}
}
