using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class canvasTextController : MonoBehaviour {
	//General
	public Text playerTabMoney;
	public Text playerTabMoney2;
	public Text playerTabUranium;
	public Text playerTabCrystals;

	// Player -----------------------------------------------------------------------------------------------------

	//For Player
	public Text playerAtk;
	public Text playerLevel;
	public Text playerLvCost;
	public Text playerAtkToAdd;

	// Characters -------------------------------------------------------------------------------------------------

	//For Bob
	public Text bobAtk;
	public Text bobLevel;
	public Text bobLvCost;
	public Text bobAtkToAdd;
	public Text bobUnlock;

	//For DogBot
	public Text dogBotAtk;
	public Text dogBotLevel;
	public Text dogBotLvCost;
	public Text dogBotAtkToAdd;
	public Text dogBotUnlock;

	//For Robo
	public Text roboBotAtk;
	public Text roboBotLevel;
	public Text roboBotLvCost;
	public Text roboBotAtkToAdd;
	public Text roboBotUnlock;

	//For Dron
	public Text DronAtk;
	public Text DronLevel;
	public Text DronLvCost;
	public Text DronAtkToAdd;
	public Text DronUnlock;

	//For Litus
	public Text LitusAtk;
	public Text LitusLevel;
	public Text LitusLvCost;
	public Text LitusAtkToAdd;
	public Text LitusUnlock;

	//For Sharot
	public Text SharotAtk;
	public Text SharotLevel;
	public Text SharotLvCost;
	public Text SharotAtkToAdd;
	public Text SharotUnlock;

	//For Mateo
	public Text MateoAtk;
	public Text MateoLevel;
	public Text MateoLvCost;
	public Text MateoAtkToAdd;
	public Text MateoUnlock;

	//For Bik
	public Text BikAtk;
	public Text BikLevel;
	public Text BikLvCost;
	public Text BikAtkToAdd;
	public Text BikUnlock;

	//For Laser
	public Text LaserAtk;
	public Text LaserLevel;
	public Text LaserLvCost;
	public Text LaserAtkToAdd;
	public Text LaserUnlock;

	// Weapons ----------------------------------------------------------------------------------------------------

	//Unlock
	public Text weaponUnlockCost;

	//Plasma Gun
	public Text weapon01Lv;
	public Text weapon01Atribute;
	public Text weapon01LvCost;
	public Text weapon01AtributeToAdd;

	//Rectificator
	public Text weapon02Lv;
	public Text weapon02Atribute;
	public Text weapon02LvCost;
	public Text weapon02AtributeToAdd;

	//Plasma Gatling
	public Text weapon03Lv;
	public Text weapon03Atribute;
	public Text weapon03LvCost;
	public Text weapon03AtributeToAdd;

	// Abilities ---------------------------------------------------------------------------------------------

	//Plasma Granade
	public Text Ability01Lv;
	public Text Ability01Atribute;
	public Text Ability01LvCost;
	public Text Ability01AtributeToAdd;
	public Text Ability01Cooldown;

	//Gold Shot
	public Text Ability04Lv;
	public Text Ability04Atribute;
	public Text Ability04LvCost;
	public Text Ability04AtributeToAdd;
	public Text Ability04PowUpDuration;
	public Text Ability04Cooldown;

	//Time Travel
	public Text Ability00Name;
	public Text Ability00WhatToDo;

	// Others ------------------------------------------------------------------------------------------------
	public Text monstersName;

	// Use this for initialization
	void Start () {
		//General
		getting4TextComponents (playerTabMoney, playerTabMoney2, playerTabUranium, playerTabCrystals);

		//*Player/Allies*-------------------------------------------------------------------------------------

		//Player Btn Text
		getting4TextComponents (playerAtk, playerLevel, playerLvCost, playerAtkToAdd);
		//Bob Btn Text
		getting5TextComponents (bobAtk, bobLevel, bobLvCost, bobUnlock, bobAtkToAdd);// 01
		//DogBot Btn Text
		getting5TextComponents (dogBotAtk, dogBotLevel, dogBotLvCost, dogBotUnlock, dogBotAtkToAdd);// 02
		//Robo Btn Text
		getting5TextComponents (roboBotAtk, roboBotLevel, roboBotLvCost, roboBotUnlock, roboBotAtkToAdd);// 03
		//Dron Btn Text
		getting5TextComponents (DronAtk, DronLevel, DronLvCost, DronUnlock, DronAtkToAdd);// 04
		//Litus Btn Text
		getting5TextComponents (LitusAtk, LitusLevel, LitusLvCost, LitusUnlock, LitusAtkToAdd);// 05
		//Sharot Btn Text
		getting5TextComponents (SharotAtk, SharotLevel, SharotLvCost, SharotUnlock, SharotAtkToAdd);// 06
		//Mateo Btn Text
		getting5TextComponents (MateoAtk, MateoLevel, MateoLvCost, MateoUnlock, MateoAtkToAdd);// 07
		//Bik Btn Text
		getting5TextComponents (BikAtk, BikLevel, BikLvCost, BikUnlock, BikAtkToAdd);// 08
		//Mateo Btn Text
		getting5TextComponents (LaserAtk, LaserLevel, LaserLvCost, LaserUnlock, LaserAtkToAdd);// 09

		//*Weapons*-------------------------------------------------------------------------------------------
		gettingTextComponent(weaponUnlockCost);// Unlock btn
		getting4TextComponents (weapon01Lv, weapon01Atribute, weapon01LvCost, weapon01AtributeToAdd);// 01
		getting4TextComponents (weapon02Lv, weapon02Atribute, weapon02LvCost, weapon02AtributeToAdd);// 02
		getting4TextComponents (weapon03Lv, weapon03Atribute, weapon03LvCost, weapon03AtributeToAdd);// 03

		//*Abilities*-----------------------------------------------------------------------------------------
		getting5TextComponents (Ability01Lv, Ability01Atribute, Ability01LvCost, Ability01AtributeToAdd, Ability01Cooldown);
		getting6TextComponents (Ability04Lv, Ability04Atribute, Ability04LvCost, Ability04AtributeToAdd, Ability04Cooldown, Ability04PowUpDuration);

		gettingTextComponent (Ability00Name);
		gettingTextComponent (Ability00WhatToDo);

		//*Others*--------------------------------------------------------------------------------------------
		gettingTextComponent (monstersName);
	}

	// Metodo para agilizar el uso del metodo gettingTextComponent
	void getting6TextComponents (Text varName1, Text varName2, Text varName3, Text varName4, Text varName5, Text varName6){
		gettingTextComponent(varName1);
		gettingTextComponent(varName2);
		gettingTextComponent(varName3);
		gettingTextComponent(varName4);
		gettingTextComponent(varName5);
		gettingTextComponent(varName6);
	}

	// Metodo para agilizar el uso del metodo gettingTextComponent
	void getting5TextComponents (Text varName1, Text varName2, Text varName3, Text varName4, Text varName5){
		gettingTextComponent(varName1);
		gettingTextComponent(varName2);
		gettingTextComponent(varName3);
		gettingTextComponent(varName4);
		gettingTextComponent(varName5);
	}

	// Metodo para agilizar el uso del metodo gettingTextComponent
	void getting4TextComponents (Text varName1, Text varName2, Text varName3, Text varName4){
		gettingTextComponent(varName1);
		gettingTextComponent(varName2);
		gettingTextComponent(varName3);
		gettingTextComponent(varName4);
	}

	void gettingTextComponent (Text varName){
		varName = varName.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
