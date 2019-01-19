using UnityEngine;
using System;
using System.Collections;

public class OfflineIncome : MonoBehaviour {

	//
	public int offlineIncomeTimeSpawn_Mins = 1;
	//public int offlineIncomeTimeSpawn_Level = 20;
	public float offlineMoney;
	private bool offlineMoneyActivation = false;

	//
	public GameObject offlineIncomeButton;

	// Variables
	public DateTime quitTime;
	public DateTime returnTime;
	public DateTime totalIncome;

	//
	TimeSpan varName1;
	double varName2;

	//
	public GameStatus gameStatus;

	public Player player;
	public monsterHp mainScript;

	//
	void Awake () {
		returnTime = DateTime.Now;
	}

	// Use this for initialization
	void Start () {
		varName1 = returnTime - gameStatus.quitTime;
		varName2 = varName1.TotalMinutes;

		if (varName2 > offlineIncomeTimeSpawn_Mins/* && mainScript.level > offlineIncomeTimeSpawn_Level*/) {
			offlineMoneyActivation = true;
		} else {
			offlineMoneyActivation = false;
		}

		offlineIncomeCalculation ();

		//Debug.Log (varName2);
	}

	//
	void offlineIncomeCalculation () {
		offlineMoney = ((int)varName2 + mainScript.level) * 2;
	}

	//
	public void gettingOfflineIncome () {
		if(offlineMoneyActivation){
			//Debug.Log (player.money);
			player.money += offlineMoney;
			//Debug.Log (offlineMoney);
			//Debug.Log (player.money);
			offlineMoney = 0;
		}
	}

	// Metodo para activar/desactivar el boton
	void activatingOfflineIncomeButton () {
		if (offlineMoney > 0 ) {
			offlineIncomeButton.SetActive (true);
		} else {
			offlineIncomeButton.SetActive (false);
		}
	}

	// Variable a pasar para guardar
	void passingVariablesToSave () {
		gameStatus.quitTime = quitTime;
	}
	
	// Update is called once per frame
	void Update () {
		quitTime = DateTime.Now;

		//activatingOfflineIncomeButton ();

		passingVariablesToSave();
	}
}
