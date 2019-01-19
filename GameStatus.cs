using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class GameStatus : MonoBehaviour {
	// Variables to save***

	// Player
	public float playerLevel;
	public float playerBaseAttack;
	public float playerAtk;
	public float playerLevelCostBase;
	public float playerLevelCost;
	public float playerAtkToAdd;
	public float playerCriticDamagePorcent;
	public float playerTaps;
	public float playerMoney;
	public float playerTotalMoney;
	public float playerUranium;
	public float playerCrystals;
	public float playerGameTime;
	public float playerTotalGameTime;

	// Partners----------------------------------------------------------------------------------------------*

	// Partner01_Bob
	public float bobLevel;
	public float bobBaseAtk;
	public float bobAtk;
	public float bobLevelCostBase;
	public float bobLevelCost;
	public float bobAtkToAdd;

	// Partner02_Robo
	public float roboLevel;
	public float roboBaseAtk;
	public float roboAtk;
	public float roboLevelCostBase;
	public float roboLevelCost;
	public float roboAtkToAdd;

	// Partner03_Robo
	public float dogBotLevel;
	public float dogBotBaseAtk;
	public float dogBotAtk;
	public float dogBotLevelCostBase;
	public float dogBotLevelCost;
	public float dogBotAtkToAdd;

	// Partner04_Dron
	public float dronLevel;
	public float dronBaseAtk;
	public float dronAtk;
	public float dronLevelCostBase;
	public float dronLevelCost;
	public float dronAtkToAdd;

	// Partner05_Litus
	public float litusLevel;
	public float litusBaseAtk;
	public float litusAtk;
	public float litusLevelCostBase;
	public float litusLevelCost;
	public float litusAtkToAdd;

	// Partner06_Sharot
	public float sharotLevel;
	public float sharotBaseAtk;
	public float sharotAtk;
	public float sharotLevelCostBase;
	public float sharotLevelCost;
	public float sharotAtkToAdd;

	// Partner07_Mateo
	public float mateoLevel;
	public float mateoBaseAtk;
	public float mateoAtk;
	public float mateoLevelCostBase;
	public float mateoLevelCost;
	public float mateoAtkToAdd;

	// Partner08_Bik
	public float bikLevel;
	public float bikBaseAtk;
	public float bikAtk;
	public float bikLevelCostBase;
	public float bikLevelCost;
	public float bikAtkToAdd;

	// Partner09_Laser
	public float laserLevel;
	public float laserBaseAtk;
	public float laserAtk;
	public float laserLevelCostBase;
	public float laserLevelCost;
	public float laserAtkToAdd;

	// Weapons-----------------------------------------------------------------------------------------------*

	//
	public List<int> usedValues = new List<int> ();

	// weapon01
	public float weapon01Level;
	public float weapon01Atribute;
	public float weapon01AtributeBase;
	public float weapon01LevelCost;
	public float weapon01LevelCostBase;
	public float weapon01AtributeToAdd;
	public float weapon01AtributeToAddBase;

	// weapon02
	public float weapon02Level;
	public float weapon02Atribute;
	public float weapon02AtributeBase;
	public float weapon02LevelCost;
	public float weapon02LevelCostBase;
	public float weapon02AtributeToAdd;
	public float weapon02AtributeToAddBase;

	// weapon03
	public float weapon03Level;
	public float weapon03Atribute;
	public float weapon03AtributeBase;
	public float weapon03LevelCost;
	public float weapon03LevelCostBase;
	public float weapon03AtributeToAdd;
	public float weapon03AtributeToAddBase;

	//Abilities ---------------------------------------------------------------------------------------------*

	// ability01
	public float ability01Level;
	public float ability01DamageBase;
	public float ability01DamageMultiply;
	public float ability01LevelCostBase;
	public float ability01LevelCost;
	public float ability01CooldownTimeBase;
	public float ability01CooldownTime;

	// ability04
	public float ability04Level;
	public float ability04GoldPorcentPerTapBase;
	public float ability04GoldPorcentPerTap;
	public float ability04LevelCostBase;
	public float ability04LevelCost;
	public float ability04CooldownTimeBase;
	public float ability04CooldownTime;
	public float ability04PowUpDuration;
	public float ability04PowUpDurationBase;

	// Others
	public int stage;
	public int stageL;
	public int level;
	public float randomNumber;
	public int backgroundNumber;
	public bool beforeBossTraining;

	// Music/Effects
	public bool soundEffectsTurning;
	public bool BgMusicTurning;

	// OfflineIncome
	public DateTime quitTime;

	// This Object
	public static GameStatus gameStatus;
	//
	//public bool saveText = false;
	//public bool loadText = false;
	//private float saveElapsedTime = 0f;
	//private float loadElapsedTime = 0f;

	// to set/get the path of the datos archive
	private String archivePath;

	// Use this for initialize even before Start
	void Awake(){
		Directory.CreateDirectory (Application.persistentDataPath + "/data");
		archivePath = Application.persistentDataPath + "/data/datos.dat";
		if(gameStatus==null){ // Procura que si no existe se cree el objeto
			gameStatus = this;
			DontDestroyOnLoad(gameObject);
			Load (); //Lo llamamos aqui para que solo se ejecute una vez al empeza
		}else if(gameStatus!=this){// Procura que si se crea una copia se destruya
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		
	}

	public void Save(){
		//Debug.Log ("guardado");
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(archivePath);

		DataToBeSaved datos = new DataToBeSaved();
		// player
		datos.playerLevel = playerLevel;
		datos.playerBaseAttack = playerBaseAttack;
		datos.playerAtk = playerAtk;
		datos.playerLevelCostBase = playerLevelCostBase;
		datos.playerLevelCost = playerLevelCost;
		datos.playerAtkToAdd = playerAtkToAdd;
		datos.playerCriticDamagePorcent = playerCriticDamagePorcent;
		datos.playerTaps = playerTaps;
		datos.playerMoney = playerMoney;
		datos.playerTotalMoney = playerTotalMoney;
		datos.playerUranium = playerUranium;
		datos.playerCrystals = playerCrystals;
		datos.playerGameTime = playerGameTime;
		datos.playerTotalGameTime = playerTotalGameTime;

		// Partners------------------------------------------------------------------------------------------*

		// Partner01_Bob
		datos.bobLevel = bobLevel;
		datos.bobBaseAtk = bobBaseAtk;
		datos.bobAtk = bobAtk;
		datos.bobLevelCostBase = bobLevelCostBase;
		datos.bobLevelCost = bobLevelCost;
		datos.bobAtkToAdd = bobAtkToAdd;

		// Partner02_Robo
		datos.roboLevel = roboLevel;
		datos.roboBaseAtk = roboBaseAtk;
		datos.roboAtk = roboAtk;
		datos.roboLevelCostBase = roboLevelCostBase;
		datos.roboLevelCost = roboLevelCost;
		datos.roboAtkToAdd = roboAtkToAdd;

		// Partner03_DogBot
		datos.dogBotLevel = dogBotLevel;
		datos.dogBotBaseAtk = dogBotBaseAtk;
		datos.dogBotAtk = dogBotAtk;
		datos.dogBotLevelCostBase = dogBotLevelCostBase;
		datos.dogBotLevelCost = dogBotLevelCost;
		datos.dogBotAtkToAdd = dogBotAtkToAdd;

		// Partner04_Dron
		datos.dronLevel = dronLevel;
		datos.dronBaseAtk = dronBaseAtk;
		datos.dronAtk = dronAtk;
		datos.dronLevelCostBase = dronLevelCostBase;
		datos.dronLevelCost = dronLevelCost;
		datos.dronAtkToAdd = dronAtkToAdd;

		// Partner05_Litus
		datos.litusLevel = litusLevel;
		datos.litusBaseAtk = litusBaseAtk;
		datos.litusAtk = litusAtk;
		datos.litusLevelCostBase = litusLevelCostBase;
		datos.litusLevelCost = litusLevelCost;
		datos.litusAtkToAdd = litusAtkToAdd;

		// Partner06_Sharot
		datos.sharotLevel = sharotLevel;
		datos.sharotBaseAtk = sharotBaseAtk;
		datos.sharotAtk = sharotAtk;
		datos.sharotLevelCostBase = sharotLevelCostBase;
		datos.sharotLevelCost = sharotLevelCost;
		datos.sharotAtkToAdd = sharotAtkToAdd;

		// Partner07_Mateo
		datos.mateoLevel = mateoLevel;
		datos.mateoBaseAtk = mateoBaseAtk;
		datos.mateoAtk = mateoAtk;
		datos.mateoLevelCostBase = mateoLevelCostBase;
		datos.mateoLevelCost = mateoLevelCost;
		datos.mateoAtkToAdd = mateoAtkToAdd;

		// Partner08_Bik
		datos.bikLevel = bikLevel;
		datos.bikBaseAtk = bikBaseAtk;
		datos.bikAtk = bikAtk;
		datos.bikLevelCostBase = bikLevelCostBase;
		datos.bikLevelCost = bikLevelCost;
		datos.bikAtkToAdd = bikAtkToAdd;

		// Partner09_Laser
		datos.laserLevel = laserLevel;
		datos.laserBaseAtk = laserBaseAtk;
		datos.laserAtk = laserAtk;
		datos.laserLevelCostBase = laserLevelCostBase;
		datos.laserLevelCost = laserLevelCost;
		datos.laserAtkToAdd = laserAtkToAdd;

		// Weapons-------------------------------------------------------------------------------------------*

		//
		datos.usedValues = usedValues;

		//weapon01
		datos.weapon01Level = weapon01Level;
		datos.weapon01AtributeBase = weapon01AtributeBase;
		datos.weapon01Atribute = weapon01Atribute;
		datos.weapon01LevelCostBase = weapon01LevelCostBase;
		datos.weapon01LevelCost = weapon01LevelCost;
		datos.weapon01AtributeToAddBase = weapon01AtributeToAddBase;
		datos.weapon01AtributeToAdd = weapon01AtributeToAdd;

		//weapon02
		datos.weapon02Level = weapon02Level;
		datos.weapon02AtributeBase = weapon02AtributeBase;
		datos.weapon02Atribute = weapon02Atribute;
		datos.weapon02LevelCostBase = weapon02LevelCostBase;
		datos.weapon02LevelCost = weapon02LevelCost;
		datos.weapon02AtributeToAddBase = weapon02AtributeToAddBase;
		datos.weapon02AtributeToAdd = weapon02AtributeToAdd;

		//weapon03
		datos.weapon03Level = weapon03Level;
		datos.weapon03AtributeBase = weapon03AtributeBase;
		datos.weapon03Atribute = weapon03Atribute;
		datos.weapon03LevelCostBase = weapon03LevelCostBase;
		datos.weapon03LevelCost = weapon03LevelCost;
		datos.weapon03AtributeToAddBase = weapon03AtributeToAddBase;
		datos.weapon03AtributeToAdd = weapon03AtributeToAdd;

		//Abilities------------------------------------------------------------------------------------------*

		// ability01
		datos.ability01Level = ability01Level;
		datos.ability01DamageBase = ability01DamageBase;
		datos.ability01DamageMultiply = ability01DamageMultiply;
		datos.ability01LevelCostBase = ability01LevelCostBase;
		datos.ability01LevelCost = ability01LevelCost;
		datos.ability01CooldownTimeBase = ability01CooldownTimeBase;
		datos.ability01CooldownTime = ability01CooldownTime;

		// ability04
		datos.ability04Level = ability04Level;
		datos.ability04GoldPorcentPerTapBase = ability04GoldPorcentPerTapBase;
		datos.ability04GoldPorcentPerTap = ability04GoldPorcentPerTap;
		datos.ability04LevelCostBase = ability04LevelCostBase;
		datos.ability04LevelCost = ability04LevelCost;
		datos.ability04CooldownTimeBase = ability04CooldownTimeBase;
		datos.ability04CooldownTime = ability04CooldownTime;
		datos.ability04PowUpDuration = ability04PowUpDuration;
		datos.ability04PowUpDurationBase = ability04PowUpDurationBase;

		// mainScript
		datos.level = level;
		datos.stage = stage;
		datos.stageL = stageL;
		datos.randomNumber = randomNumber;
		datos.beforeBossTraining = beforeBossTraining;

		// backgroundBehavior
		datos.backgroundNumber = backgroundNumber;

		// music/effects
		datos.soundEffectsTurning = soundEffectsTurning;
		datos.BgMusicTurning = BgMusicTurning;

		// offlineIncome
		datos.quitTime = quitTime;

		bf.Serialize(file, datos);

		file.Close();
		//saveText = true;
	}

	public void Load(){
		Debug.Log ("cargado");
		if(File.Exists(archivePath)){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(archivePath, FileMode.Open);

			DataToBeSaved datos = (DataToBeSaved) bf.Deserialize(file);
			//player
			playerLevel = datos.playerLevel;
			//Debug.Log (datos.playerLevel+" / "+playerLevel);
			playerBaseAttack = datos.playerBaseAttack;
			playerAtk = datos.playerAtk;
			playerLevelCostBase = datos.playerLevelCostBase;
			playerLevelCost = datos.playerLevelCost;
			playerAtkToAdd = datos.playerAtkToAdd;
			playerCriticDamagePorcent = datos.playerCriticDamagePorcent;
			playerTaps = datos.playerTaps;
			playerMoney = datos.playerMoney;
			playerTotalMoney = datos.playerTotalMoney;
			playerUranium = datos.playerUranium;
			playerCrystals = datos.playerCrystals;
			playerGameTime = datos.playerGameTime;
			playerTotalGameTime = datos.playerTotalGameTime;

			//-----------------------------------------------------------------------------------------------*

			// Partner01_Bob
			bobLevel = datos.bobLevel;
			bobBaseAtk = datos.bobBaseAtk;
			bobAtk = datos.bobAtk;
			bobLevelCostBase = datos.bobLevelCostBase;
			bobLevelCost = datos.bobLevelCost;
			bobAtkToAdd = datos.bobAtkToAdd;

			// Partner02_Robo
			roboLevel = datos.roboLevel;
			roboBaseAtk = datos.roboBaseAtk;
			roboAtk = datos.roboAtk;
			roboLevelCostBase = datos.roboLevelCostBase;
			roboLevelCost = datos.roboLevelCost;
			roboAtkToAdd = datos.roboAtkToAdd;

			// Partner03_DogBot
			dogBotLevel = datos.dogBotLevel;
			dogBotBaseAtk = datos.dogBotBaseAtk;
			dogBotAtk = datos.dogBotAtk;
			dogBotLevelCostBase = datos.dogBotLevelCostBase;
			dogBotLevelCost = datos.dogBotLevelCost;
			dogBotAtkToAdd = datos.dogBotAtkToAdd;

			// Partner04_Dron
			dronLevel = datos.dronLevel;
			dronBaseAtk = datos.dronBaseAtk;
			dronAtk = datos.dronAtk;
			dronLevelCostBase = datos.dronLevelCostBase;
			dronLevelCost = datos.dronLevelCost;
			dronAtkToAdd = datos.dronAtkToAdd;

			// Partner05_Litus
			litusLevel = datos.litusLevel;
			litusBaseAtk = datos.litusBaseAtk;
			litusAtk = datos.litusAtk;
			litusLevelCostBase = datos.litusLevelCostBase;
			litusLevelCost = datos.litusLevelCost;
			litusAtkToAdd = datos.litusAtkToAdd;

			// Partner06_Sharot
			sharotLevel = datos.sharotLevel;
			sharotBaseAtk = datos.sharotBaseAtk;
			sharotAtk = datos.sharotAtk;
			sharotLevelCostBase = datos.sharotLevelCostBase;
			sharotLevelCost = datos.sharotLevelCost;
			sharotAtkToAdd = datos.sharotAtkToAdd;

			// Partner07_Mateo
			mateoLevel = datos.mateoLevel;
			mateoBaseAtk = datos.mateoBaseAtk;
			mateoAtk = datos.mateoAtk;
			mateoLevelCostBase = datos.mateoLevelCostBase;
			mateoLevelCost = datos.mateoLevelCost;
			mateoAtkToAdd = datos.mateoAtkToAdd;

			// Partner08_Bik
			bikLevel = datos.bikLevel;
			bikBaseAtk = datos.bikBaseAtk;
			bikAtk = datos.bikAtk;
			bikLevelCostBase = datos.bikLevelCostBase;
			bikLevelCost = datos.bikLevelCost;
			bikAtkToAdd = datos.bikAtkToAdd;

			// Partner09_Laser
			laserLevel = datos.laserLevel;
			laserBaseAtk = datos.laserBaseAtk;
			laserAtk = datos.laserAtk;
			laserLevelCostBase = datos.laserLevelCostBase;
			laserLevelCost = datos.laserLevelCost;
			laserAtkToAdd = datos.laserAtkToAdd;

			//-----------------------------------------------------------------------------------------------*

			//
			usedValues = datos.usedValues;

			//weapon01
			weapon01Level = datos.weapon01Level;
			weapon01AtributeBase = datos.weapon01AtributeBase;
			weapon01Atribute = datos.weapon01Atribute;
			weapon01LevelCostBase = datos.weapon01LevelCostBase;
			weapon01LevelCost = datos.weapon01LevelCost;
			weapon01AtributeToAddBase = datos.weapon01AtributeToAddBase;
			weapon01AtributeToAdd = datos.weapon01AtributeToAdd;

			//weapon02
			weapon02Level = datos.weapon02Level;
			weapon02AtributeBase = datos.weapon02AtributeBase;
			weapon02Atribute = datos.weapon02Atribute;
			weapon02LevelCostBase = datos.weapon02LevelCostBase;
			weapon02LevelCost = datos.weapon02LevelCost;
			weapon02AtributeToAddBase = datos.weapon02AtributeToAddBase;
			weapon02AtributeToAdd = datos.weapon02AtributeToAdd;

			//weapon03
			weapon03Level = datos.weapon03Level;
			weapon03AtributeBase = datos.weapon03AtributeBase;
			weapon03Atribute = datos.weapon03Atribute;
			weapon03LevelCostBase = datos.weapon03LevelCostBase;
			weapon03LevelCost = datos.weapon03LevelCost;
			weapon03AtributeToAddBase = datos.weapon03AtributeToAddBase;
			weapon03AtributeToAdd = datos.weapon03AtributeToAdd;

			//Abilities--------------------------------------------------------------------------------------*

			// ability01
			ability01Level = datos.ability01Level;
			ability01DamageBase = datos.ability01DamageBase;
			ability01DamageMultiply = datos.ability01DamageMultiply;
			ability01LevelCostBase = datos.ability01LevelCostBase;
			ability01LevelCost = datos.ability01LevelCost;
			ability01CooldownTimeBase = datos.ability01CooldownTimeBase;
			ability01CooldownTime = datos.ability01CooldownTime;

			// ability04
			ability04Level = datos.ability04Level;
			ability04GoldPorcentPerTapBase = datos.ability04GoldPorcentPerTapBase;
			ability04GoldPorcentPerTap = datos.ability04GoldPorcentPerTap;
			ability04LevelCostBase = datos.ability04LevelCostBase;
			ability04LevelCost = datos.ability04LevelCost;
			ability04CooldownTimeBase = datos.ability04CooldownTimeBase;
			ability04CooldownTime = datos.ability04CooldownTime;
			ability04PowUpDuration = datos.ability04PowUpDuration;
			ability04PowUpDurationBase = datos.ability04PowUpDurationBase;

			//mainScript
			level = datos.level;
			stage = datos.stage;
			stageL = datos.stageL;
			randomNumber = datos.randomNumber;
			beforeBossTraining = datos.beforeBossTraining;

			//backgroundBehavior
			backgroundNumber = datos.backgroundNumber;

			//music/effects
			soundEffectsTurning = datos.soundEffectsTurning;
			BgMusicTurning = datos.BgMusicTurning;

			// offlineIncome
			quitTime = datos.quitTime;

			file.Close();
			//loadText = true;
		}else{ // Initializer
			// player
			playerLevel = 1f;
			playerBaseAttack = 1f;
			playerAtk = playerBaseAttack;//base
			playerLevelCostBase = 5f;
			playerLevelCost = playerLevelCostBase;//base
			playerAtkToAdd = 2f;
			playerCriticDamagePorcent = 2f;
			playerTaps = 0f;
			playerMoney = 0f;
			playerTotalMoney = 0f;
			playerUranium = 0f;
			playerCrystals = 0f;
			playerGameTime = 0f;
			playerTotalGameTime = 0f;

			//-----------------------------------------------------------------------------------------------*

			// Partner01_Bob
			bobLevel = 0f;
			bobBaseAtk = 5f;
			bobAtk = bobBaseAtk;
			bobLevelCostBase = 55f;
			bobLevelCost = bobLevelCostBase;
			bobAtkToAdd = 5f;

			// Partner02_Robo
			roboLevel = 0f;
			roboBaseAtk = 17f;
			roboAtk = roboBaseAtk;
			roboLevelCostBase = 275f;
			roboLevelCost = roboLevelCostBase;
			roboAtkToAdd = 17f;

			// Partner03_DogBot
			dogBotLevel = 0f;
			dogBotBaseAtk = 58f;
			dogBotAtk = dogBotBaseAtk;
			dogBotLevelCostBase = 960f;
			dogBotLevelCost = dogBotLevelCostBase;
			dogBotAtkToAdd = 58f;

			// Partner04_Dron
			dronLevel = 0f;
			dronBaseAtk = 210f;
			dronAtk = dronBaseAtk;
			dronLevelCostBase = 2800f;
			dronLevelCost = dronLevelCostBase;
			dronAtkToAdd = 210f;

			// Partner05_Litus
			litusLevel = 0f;
			litusBaseAtk = 975f;
			litusAtk = litusBaseAtk;
			litusLevelCostBase = 19755f;
			litusLevelCost = litusLevelCostBase;
			litusAtkToAdd = 975f;

			// Partner06_Sharot
			sharotLevel = 0f;
			sharotBaseAtk = 4455f;
			sharotAtk = sharotBaseAtk;
			sharotLevelCostBase = 89777f;
			sharotLevelCost = sharotLevelCostBase;
			sharotAtkToAdd = 4455f;

			// Partner07_Mateo
			mateoLevel = 0f;
			mateoBaseAtk = 17150f;
			mateoAtk = mateoBaseAtk;
			mateoLevelCostBase = 515600f;
			mateoLevelCost = mateoLevelCostBase;
			mateoAtkToAdd = 17150f;

			// Partner08_Bik
			bikLevel = 0f;
			bikBaseAtk = 92500f;
			bikAtk = bikBaseAtk;
			bikLevelCostBase = 3100500f;
			bikLevelCost = bikLevelCostBase;
			bikAtkToAdd = 92500f;

			// Partner09_Laser
			laserLevel = 0f;
			laserBaseAtk = 525300f;
			laserAtk = laserBaseAtk;
			laserLevelCostBase = 28755000f;
			laserLevelCost = laserLevelCostBase;
			laserAtkToAdd = 525300f;

			//-----------------------------------------------------------------------------------------------*

			weapon01Level = 1f;
			weapon01AtributeBase = 10f;
			weapon01Atribute = weapon01AtributeBase;
			weapon01LevelCostBase = 1f;
			weapon01LevelCost = weapon01LevelCostBase;
			weapon01AtributeToAddBase = 10f;
			weapon01AtributeToAdd = weapon01AtributeToAddBase;

			weapon02Level = 1f;
			weapon02AtributeBase = 15f;
			weapon02Atribute = weapon03AtributeBase;
			weapon02LevelCostBase = 1f;
			weapon02LevelCost = weapon03LevelCostBase;
			weapon02AtributeToAddBase = 15f;
			weapon02AtributeToAdd = weapon03AtributeToAddBase;

			weapon03Level = 1f;
			weapon03AtributeBase = 20f;
			weapon03Atribute = weapon03AtributeBase;
			weapon03LevelCostBase = 1f;
			weapon03LevelCost = weapon03LevelCostBase;
			weapon03AtributeToAddBase = 20f;
			weapon03AtributeToAdd = weapon03AtributeToAddBase;

			//Abilities--------------------------------------------------------------------------------------*

			// ability01
			ability01Level = 1f;
			ability01DamageBase = 85f;
			ability01DamageMultiply = ability01Level * ability01DamageBase;
			ability01LevelCostBase = 10f;
			ability01LevelCost = ability01LevelCostBase;
			ability01CooldownTimeBase = 1800f;
			ability01CooldownTime = 0f;

			// ability04
			ability04Level = 1f;//
			ability04GoldPorcentPerTapBase = 20f;
			ability04GoldPorcentPerTap = ability04GoldPorcentPerTapBase;
			ability04LevelCostBase = 10f;//
			ability04LevelCost = ability04LevelCostBase;//
			ability04CooldownTimeBase = 3600f;//
			ability04CooldownTime = 0f;//
			ability04PowUpDuration = 0f;//
			ability04PowUpDurationBase = 30f;//

			// mainScript
			level = 1;
			stageL = 10;
			stage = 1;
			randomNumber = 1f;
			beforeBossTraining = false;

			//
			backgroundNumber = 0;

			//
			soundEffectsTurning = true;
			BgMusicTurning = true;

			//
			quitTime = DateTime.Now;
		}
	}
}

[Serializable]
class DataToBeSaved{
	// Player
	public float playerLevel;
	public float playerBaseAttack;
	public float playerAtk;
	public float playerLevelCostBase;
	public float playerLevelCost;
	public float playerAtkToAdd;
	public float playerCriticDamagePorcent;
	public float playerTaps;
	public float playerMoney;
	public float playerTotalMoney;
	public float playerUranium;
	public float playerCrystals;
	public float playerGameTime;
	public float playerTotalGameTime;

	// Partners----------------------------------------------------------------------------------------------*

	// Partner01_Bob
	public float bobLevel;
	public float bobBaseAtk;
	public float bobAtk;
	public float bobLevelCostBase;
	public float bobLevelCost;
	public float bobAtkToAdd;

	// Partner02_Robo
	public float roboLevel;
	public float roboBaseAtk;
	public float roboAtk;
	public float roboLevelCostBase;
	public float roboLevelCost;
	public float roboAtkToAdd;

	// Partner03_Robo
	public float dogBotLevel;
	public float dogBotBaseAtk;
	public float dogBotAtk;
	public float dogBotLevelCostBase;
	public float dogBotLevelCost;
	public float dogBotAtkToAdd;

	// Partner04_Dron
	public float dronLevel;
	public float dronBaseAtk;
	public float dronAtk;
	public float dronLevelCostBase;
	public float dronLevelCost;
	public float dronAtkToAdd;

	// Partner05_Litus
	public float litusLevel;
	public float litusBaseAtk;
	public float litusAtk;
	public float litusLevelCostBase;
	public float litusLevelCost;
	public float litusAtkToAdd;

	// Partner06_Sharot
	public float sharotLevel;
	public float sharotBaseAtk;
	public float sharotAtk;
	public float sharotLevelCostBase;
	public float sharotLevelCost;
	public float sharotAtkToAdd;

	// Partner07_Mateo
	public float mateoLevel;
	public float mateoBaseAtk;
	public float mateoAtk;
	public float mateoLevelCostBase;
	public float mateoLevelCost;
	public float mateoAtkToAdd;

	// Partner08_Bik
	public float bikLevel;
	public float bikBaseAtk;
	public float bikAtk;
	public float bikLevelCostBase;
	public float bikLevelCost;
	public float bikAtkToAdd;

	// Partner09_Laser
	public float laserLevel;
	public float laserBaseAtk;
	public float laserAtk;
	public float laserLevelCostBase;
	public float laserLevelCost;
	public float laserAtkToAdd;

	// Weapons-----------------------------------------------------------------------------------------------*

	//
	public List<int> usedValues = new List<int> ();

	// weapon01
	public float weapon01Level;
	public float weapon01Atribute;
	public float weapon01AtributeBase;
	public float weapon01LevelCost;
	public float weapon01LevelCostBase;
	public float weapon01AtributeToAdd;
	public float weapon01AtributeToAddBase;

	// weapon02
	public float weapon02Level;
	public float weapon02Atribute;
	public float weapon02AtributeBase;
	public float weapon02LevelCost;
	public float weapon02LevelCostBase;
	public float weapon02AtributeToAdd;
	public float weapon02AtributeToAddBase;

	// weapon03
	public float weapon03Level;
	public float weapon03Atribute;
	public float weapon03AtributeBase;
	public float weapon03LevelCost;
	public float weapon03LevelCostBase;
	public float weapon03AtributeToAdd;
	public float weapon03AtributeToAddBase;

	//Ability------------------------------------------------------------------------------------------------*

	// ability01
	public float ability01Level;
	public float ability01DamageBase;
	public float ability01DamageMultiply;
	public float ability01LevelCostBase;
	public float ability01LevelCost;
	public float ability01CooldownTimeBase;
	public float ability01CooldownTime;

	// ability04
	public float ability04Level;
	public float ability04GoldPorcentPerTapBase;
	public float ability04GoldPorcentPerTap;
	public float ability04LevelCostBase;
	public float ability04LevelCost;
	public float ability04CooldownTimeBase;
	public float ability04CooldownTime;
	public float ability04PowUpDuration;
	public float ability04PowUpDurationBase;

	// Others
	public int stage;
	public int stageL;
	public int level;
	public float randomNumber;
	public int backgroundNumber;
	public bool beforeBossTraining;

	// Music/Effects
	public bool soundEffectsTurning;
	public bool BgMusicTurning;

	// OfflineIncome
	public DateTime quitTime;
}