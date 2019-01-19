using System;
using UnityEngine;
using System.Collections;

public class VariablesToBeSaved : MonoBehaviour {

	// Scripts
	private Player player;
	private Bob bob;
	private RoboJake robo;
	private DogBotBobby dogBot;
	private Dron dron;
	private Litus litus;
	private Sharot sharot;
	private Mateo mateo;
	private Bik bik;
	private Laser laser;

	private WeaponRandom weaponR;
	private Weapon01 weapon01;
	private Weapon02 weapon02;
	private Weapon03 weapon03;

	private Abilitie01_PlasmaGranade ability01;
	private Abilitie04_GoldShot ability04;

	private monsterHp mainScript;
	private BackgroundBehavior backgroundB;
	private StopSoundEffectsButton soundEffectsBtn;
	private StopBgMusicButton BgMusicBtn;
	private OfflineIncome offlineIncome;

	//
	public GameStatus gameStatus;

	// Use this for initialize even before Start
	void Awake () {
		gameStatus = GameObject.Find ("GameStatus").GetComponent<GameStatus> ();
		
	}

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("RPlayer").GetComponent<Player> ();
		bob = GameObject.Find ("Bob").GetComponent<Bob> ();
		robo = GameObject.Find ("Robo-Jake").GetComponent<RoboJake> ();
		dogBot = GameObject.Find ("DogBot-Bobby").GetComponent<DogBotBobby> ();
		dron = GameObject.Find ("DronAK-1400").GetComponent<Dron> ();
		litus = GameObject.Find ("Litus").GetComponent<Litus> ();
		sharot = GameObject.Find ("Sharot").GetComponent<Sharot> ();
		mateo = GameObject.Find ("Mateo Rodriguez").GetComponent<Mateo> ();
		bik = GameObject.Find ("BikKlubber the Merc.").GetComponent<Bik> ();
		laser = GameObject.Find ("Laser Automata").GetComponent<Laser> ();

		weaponR = GameObject.Find ("WeaponRandom").GetComponent<WeaponRandom> ();
		weapon01 = GameObject.Find ("WeaponsCode").GetComponent<Weapon01> ();
		weapon02 = GameObject.Find ("WeaponsCode").GetComponent<Weapon02> ();
		weapon03 = GameObject.Find ("WeaponsCode").GetComponent<Weapon03> ();

		ability01 = GameObject.Find ("Abilities").GetComponent<Abilitie01_PlasmaGranade> ();
		ability04 = GameObject.Find ("Abilities").GetComponent<Abilitie04_GoldShot> ();

		mainScript = GameObject.Find ("Main Camera").GetComponent<monsterHp> ();
		backgroundB = GameObject.Find ("Ascensor").GetComponent<BackgroundBehavior> ();
		soundEffectsBtn = GameObject.Find ("SoundEffectsButtonCode").GetComponent<StopSoundEffectsButton> ();
		BgMusicBtn = GameObject.Find ("BgMusicButtonCode").GetComponent<StopBgMusicButton> ();
		offlineIncome = GameObject.Find ("OfflineIncome").GetComponent<OfflineIncome> ();

		variablesToLoad ();
	
	}

	void variablesToSave () {
		
	}

	// Variables a igualar para que a al momento de "cargar" tengan un valor (el deseado)
	void variablesToLoad () {
		// player
		player.level = gameStatus.playerLevel;
		player.baseAttack = gameStatus.playerBaseAttack;
		player.attack = gameStatus.playerAtk;
		player.levelCostBase = gameStatus.playerLevelCostBase;
		player.levelCost = gameStatus.playerLevelCost;
		player.attackToAdd = gameStatus.playerAtkToAdd;
		player.criticDamagePorcent = gameStatus.playerCriticDamagePorcent;
		player.taps = gameStatus.playerTaps;
		player.money = gameStatus.playerMoney;
		player.totalMoney = gameStatus.playerTotalMoney;
		player.uranium = gameStatus.playerUranium;
		player.crystals = gameStatus.playerCrystals;
		player.gameTime = gameStatus.playerGameTime;
		player.totalGameTime = gameStatus.playerTotalGameTime;

		//Partners-------------------------------------------------------------------------------------------*

		// partner01_Bob
		bob.level = gameStatus.bobLevel;
		bob.atkBase = gameStatus.bobBaseAtk;
		bob.atk = gameStatus.bobAtk;
		bob.levelCostBase = gameStatus.bobLevelCostBase;
		bob.levelCost = gameStatus.bobLevelCost;
		bob.atkToAdd = gameStatus.bobAtkToAdd;

		// partner02_Robo
		robo.level = gameStatus.roboLevel;
		robo.atkBase = gameStatus.roboBaseAtk;
		robo.atk = gameStatus.roboAtk;
		robo.levelCostBase = gameStatus.roboLevelCostBase;
		robo.levelCost = gameStatus.roboLevelCost;
		robo.atkToAdd = gameStatus.roboAtkToAdd;

		// partner03_DogBot
		dogBot.level = gameStatus.dogBotLevel;
		dogBot.atkBase = gameStatus.dogBotBaseAtk;
		dogBot.atk = gameStatus.dogBotAtk;
		dogBot.levelCostBase = gameStatus.dogBotLevelCostBase;
		dogBot.levelCost = gameStatus.dogBotLevelCost;
		dogBot.atkToAdd = gameStatus.dogBotAtkToAdd;

		// partner04_Dron
		dron.level = gameStatus.dronLevel;
		dron.atkBase = gameStatus.dronBaseAtk;
		dron.atk = gameStatus.dronAtk;
		dron.levelCostBase = gameStatus.dronLevelCostBase;
		dron.levelCost = gameStatus.dronLevelCost;
		dron.atkToAdd = gameStatus.dronAtkToAdd;

		// partner05_Litus
		litus.level = gameStatus.litusLevel;
		litus.atkBase = gameStatus.litusBaseAtk;
		litus.atk = gameStatus.litusAtk;
		litus.levelCostBase = gameStatus.litusLevelCostBase;
		litus.levelCost = gameStatus.litusLevelCost;
		litus.atkToAdd = gameStatus.litusAtkToAdd;

		// partner06_Sharot
		sharot.level = gameStatus.sharotLevel;
		sharot.atkBase = gameStatus.sharotBaseAtk;
		sharot.atk = gameStatus.sharotAtk;
		sharot.levelCostBase = gameStatus.sharotLevelCostBase;
		sharot.levelCost = gameStatus.sharotLevelCost;
		sharot.atkToAdd = gameStatus.sharotAtkToAdd;

		// partner07_Mateo
		mateo.level = gameStatus.mateoLevel;
		mateo.atkBase = gameStatus.mateoBaseAtk;
		mateo.atk = gameStatus.mateoAtk;
		mateo.levelCostBase = gameStatus.mateoLevelCostBase;
		mateo.levelCost = gameStatus.mateoLevelCost;
		mateo.atkToAdd = gameStatus.mateoAtkToAdd;

		// partner08_Bik
		bik.level = gameStatus.bikLevel;
		bik.atkBase = gameStatus.bikBaseAtk;
		bik.atk = gameStatus.bikAtk;
		bik.levelCostBase = gameStatus.bikLevelCostBase;
		bik.levelCost = gameStatus.bikLevelCost;
		bik.atkToAdd = gameStatus.bikAtkToAdd;

		// partner09_Laser
		laser.level = gameStatus.laserLevel;
		laser.atkBase = gameStatus.laserBaseAtk;
		laser.atk = gameStatus.laserAtk;
		laser.levelCostBase = gameStatus.laserLevelCostBase;
		laser.levelCost = gameStatus.laserLevelCost;
		laser.atkToAdd = gameStatus.laserAtkToAdd;

		//Weapons--------------------------------------------------------------------------------------------*

		//
		//weaponR.weaponsButtonList = gameStatus.weaponButtonList;
		weaponR.usedValues = gameStatus.usedValues;

		// weapon01
		weapon01.level = gameStatus.weapon01Level;
		weapon01.atributeBase = gameStatus.weapon01AtributeBase;
		weapon01.atribute = gameStatus.weapon01Atribute;
		weapon01.levelCostBase = gameStatus.weapon01LevelCostBase;
		weapon01.levelCost = gameStatus.weapon01LevelCost;
		weapon01.atributeToAdd = gameStatus.weapon01AtributeToAddBase;
		weapon01.atributeToAdd = gameStatus.weapon01AtributeToAdd;

		// weapon02
		weapon02.level = gameStatus.weapon02Level;
		weapon02.atributeBase = gameStatus.weapon02AtributeBase;
		weapon02.atribute = gameStatus.weapon02Atribute;
		weapon02.levelCostBase = gameStatus.weapon02LevelCostBase;
		weapon02.levelCost = gameStatus.weapon02LevelCost;
		weapon02.atributeToAdd = gameStatus.weapon02AtributeToAddBase;
		weapon02.atributeToAdd = gameStatus.weapon02AtributeToAdd;

		// weapon03
		weapon03.level = gameStatus.weapon03Level;
		weapon03.atributeBase = gameStatus.weapon03AtributeBase;
		weapon03.atribute = gameStatus.weapon03Atribute;
		weapon03.levelCostBase = gameStatus.weapon03LevelCostBase;
		weapon03.levelCost = gameStatus.weapon03LevelCost;
		weapon03.atributeToAdd = gameStatus.weapon03AtributeToAddBase;
		weapon03.atributeToAdd = gameStatus.weapon03AtributeToAdd;

		//Abilities-----------------------------------------------------------------------------------------------

		ability01.level =  gameStatus.ability01Level;
		ability01.damageBase = gameStatus.ability01DamageBase;
		ability01.damageMultiply = gameStatus.ability01DamageMultiply;
		ability01.levelCostBase = gameStatus.ability01LevelCostBase;
		ability01.levelCost = gameStatus.ability01LevelCost;
		ability01.cooldownTimeBase = gameStatus.ability01CooldownTimeBase;
		ability01.cooldownTime = gameStatus.ability01CooldownTime;

		ability04.level = gameStatus.ability04Level;
		ability04.goldPorcentPerTapBase = gameStatus.ability04GoldPorcentPerTapBase;
		ability04.goldPorcentPerTap = gameStatus.ability04GoldPorcentPerTap;
		ability04.levelCostBase = gameStatus.ability04LevelCostBase;
		ability04.levelCost = gameStatus.ability04LevelCost;
		ability04.cooldownTimeBase = gameStatus.ability04CooldownTimeBase;
		ability04.cooldownTime = gameStatus.ability04CooldownTime;
		ability04.powerUpDurationBase = gameStatus.ability04PowUpDurationBase;
		ability04.powerUpDuration = gameStatus.ability04PowUpDuration;

		// mainScript
		mainScript.level = gameStatus.level;
		mainScript.stage = gameStatus.stage;
		mainScript.stageL = gameStatus.stageL;
		mainScript.randomNumber = gameStatus.randomNumber;
		mainScript.beforeBossTraining = gameStatus.beforeBossTraining;

		// backgroundBehavior
		backgroundB.backgroundNumber = gameStatus.backgroundNumber;

		// music/effects
		soundEffectsBtn.turning = gameStatus.soundEffectsTurning;
		BgMusicBtn.turning = gameStatus.BgMusicTurning;

		// offlineIncome
		offlineIncome.quitTime = gameStatus.quitTime;
		//Debug.Log (offlineIncome.quitTime +" lol "+ gameStatus.quitTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
