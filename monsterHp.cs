using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class monsterHp : MonoBehaviour {

	//
	public Image[] ability01Colors;
	public Text[] ability01TextColors;
	public Image[] ability04Colors;
	public Text[] ability04TextColors;

	//
	public Color turnedOffColor;
	public Color turnedOnColor;

	public Color everyTextOffColor;
	public Color levelPointsColor;
	public Color damagePointsColor;
	public Color levelCostColor;

	//
	void settingTurnOnColor (Image[] lenght) {
		for(int i = 0; i < lenght.Length; i++){
			lenght [i].color = turnedOnColor;
		}
	}

	//
	void settingTurnOffColor (Image[] lenght) {
		for(int i = 0; i < lenght.Length; i++){
			lenght [i].color = turnedOffColor;
		}
	}

	//
	void settingTurnOffTextColor (Text[] lenght) {
		for(int i = 0; i < lenght.Length; i++){
			lenght [i].color = everyTextOffColor;
		}
	}
	
	// Variables principales

	// Private
	private float bossTime = 30f;
	private float bossTimeLimit = 30f;
	private bool bossTimeActivation = false;
	private bool bossEncounter = true;
	private bool megaBossEncounter = true;
	private bool damShow = false;
	private bool criDamShow = false;
	//private float screenCenterX = Screen.width / 2;
	//private float screenCenterY = Screen.height / 2;

	// Public
	public int level;
	public int alertMovSpeed;
	public int stage = 1;
	public int stageL = 10;
	public float critic = 0f;
	public bool monsterFadeIn = false;
	public bool monsterFadeOut = false;
	public float blinkTime = 0;
	public bool partnerAtkActivation = false;
	public float partnersTotalDPS;
	public float monsterDeathTime = 0f;
	public bool monsterDeathTimeActivation = false;
	public bool backgroundChangeActivation = false;
	public bool stageChangeActivation = false;
	public bool beforeBossTraining = false;
	public bool playerTouch = false;// para el boton principal de tap

	// Variables para los numeros aleatorios
	public float randomNumber;
	float randomCriticNumber;
	float randomCoinsNumber;

	// Variables tipo TextMesh para control de texto
	//public TextMesh TMpuntosHp;
	public TextMesh TMpuntosAtk;
	public TextMesh TMpuntosMoney;
	public TextMesh TMpStage;
	public TextMesh TMpLevel;
	public TextMesh TMdamage;
	public TextMesh TMdamageCritic;
	public TextMesh TMstageLimit;
	public TextMesh TMbossTime;
	public TextMesh TMtotalPartnersAtkPerSecond;

	// Variables tipo Text para control de texto
	public Text monsterCanvasHp;
	public Text bossMonsterCanvasTime;

	// Variables Others xD
	public Scrollbar HealthBar;
	public Scrollbar TimeBar;
	public Animator animacion;
	public Button tapButton;

	// Variables ParticleSystem
	public ParticleSystem blood;
	public ParticleSystem blood2;
	public ParticleSystem bossAura;
	public ParticleSystem coins;

	// Cameras as GameObjects
	public GameObject bossAlertCam;
	public GameObject megaBossAlertCam;
	// GameObjects
	public GameObject relojSprite;
	public GameObject stageControl;
	public GameObject bossStageControl;
	public GameObject trainingControl;
	public GameObject bossBtn;
	public GameObject bossBtn2;
	public GameObject dmgText;
	public GameObject criDmgText;
	public GameObject fallingCoin;
	public GameObject tapAnimation;
	public GameObject enemy;
	public GameObject bossTimeText;
	// Abilities GameObjects
	public GameObject ability01UseBtn;
	public GameObject ability04UseBtn;


	// Variables de referencia a otro script c#
	public Player player;
	public Monster monster;
	public ShakeObj shake;
	public FadeToBlack fadeBlack;
	public Fade fadeScript;
	public canvasTextController canvasText;
	public BackgroundBehavior backgroundScript;
	public NumbersConverters numbersConverter;

	// Variables de referencia a los scripts de los companeros
	public Bob characterBob;
	public RoboJake characterRoboJake;
	public DogBotBobby characterDogBotBobby;
	public Dron characterDron;
	public Litus characterLitus;
	public Sharot characterSharot;
	public Mateo characterMateo;
	public Bik characterBik;
	public Laser characterLaser;

	// GameStatus = PersistentData = Save/Load
	public GameStatus gameStatus;

	// Weapons
	public WeaponRandom weaponRandom;
	public Weapon01 weapon_01;
	public Weapon02 weapon_02;
	public Weapon03 weapon_03;

	// abilities
	public Abilitie01_PlasmaGranade ability_01;
	public Abilitie04_GoldShot ability_04;
	public TimeTravel ability_00;

	// Variables para musica/efectos
	public AudioSource tapShot;

	// Use this for initialization
	void Start () {
		// Inicializacion de variables
		alertMovSpeed = 250;
		critic = 0f;
		bossTime = 30f;

		// Llamada a metodos
		actualizarHp ();
		actualizarLevel ();
		actualizarStage ();
		actualizarStageLimit ();
		actualizarBossTime ();
		actualizarPartnersDPS ();

		// Inicializacion de otros scripts
		if(!animacion){
		    animacion = GetComponent<Animator> ();
		}
		canvasText = canvasText.GetComponent<canvasTextController> ();
		player = player.GetComponent<Player> ();
		monster = monster.GetComponent<Monster> ();

		tapShot = tapShot.GetComponent<AudioSource>();

		monsterCanvasHp.GetComponent<Text>();
		bossMonsterCanvasTime.GetComponent<Text>();
	
	}// Start End

	//
	void actualizarEveryAtkText () {
		actualizarAtk ();
		actualizarTMdamage ();
		actualizarTabPlayerAtk ();
		actualizarCriticTMdamage ();
	}

	//***METODOS PARA ACTUALIZACION DE TEXTOS TIPOS TEXTMESH*** 

	// Metodo para actualizar el texto "TMpuntosAtk"
	public void actualizarAtk () {TMpuntosAtk.text = numbersConverter.numbersBigFormat(player.totalAttack);}
	// Metodo para actualizar el texto "TMdamage"
	public void actualizarTMdamage () {TMdamage.text = numbersConverter.numbersBigFormat(player.totalAttack);}
	// Metodo para actualizar el texto "criticTMdamage"
	public void actualizarCriticTMdamage () {TMdamageCritic.text = numbersConverter.numbersBigFormat(player.criticAttack);}
	// Metodo para actualizar el texto "TMpuntosHp"
	public void actualizarHp () {
		if (monster.hp < 1) {
			monsterCanvasHp.text = "Hp: 0";
		} else {
			monsterCanvasHp.text = "Hp: " + numbersConverter.numbersBigFormat (monster.hp);
		}
	}
	// Metodo para actualizar el texto "TMpuntosMoney"
	public void actualizarMoney () {
		if (player.money < 1) {
			TMpuntosMoney.text = "0";
		} else {
			TMpuntosMoney.text = numbersConverter.numbersBigFormat (player.money);
		}
	}
	// Metodo para actualizar el texto "TMpLevel"
	void actualizarLevel () {TMpLevel.text = numbersConverter.numbersBigFormat(level);}
	// Metodo para actualizar el texto "TMpStage"
	void actualizarStage () {TMpStage.text = stage.ToString ();}
	// Metodo para actualizar el texto "TMpStage"
	void actualizarStageLimit () {TMstageLimit.text = stageL.ToString ();}
	// Metodo para actualizar el texto "TMbossTime"
	void actualizarBossTime () {/*TMbossTime.text*/bossMonsterCanvasTime.text = bossTime.ToString ("0.0");}
	// Metodo para actualizar el texto "TMtotalPartnersAtkPerSecond"
	void actualizarPartnersDPS () {
		if(partnersTotalDPS > 0){
			TMtotalPartnersAtkPerSecond.text = numbersConverter.numbersBigFormat(partnersTotalDPS);
		} else {
			TMtotalPartnersAtkPerSecond.text = "0";
		}
	}

	//***METODOS PARA ACTUALIZACION DE TEXTOS TIPOS CANVAS TEXT***
	//PLAYER ------------------------------------------------------------------------------------------------------------------*
	// Metodo para actualizar el texto "playerAtk"
	public void actualizarTabPlayerAtk () {canvasText.playerAtk.text = numbersConverter.numbersBigFormat(player.totalAttack);}
	// Metodo para actualizar el texto "playerLevel"
	public void actualizarTabPlayerLevel () {canvasText.playerLevel.text = numbersConverter.numbersBigFormat(player.level);}
	// Metodo para actualizar el texto "playerLevelCost"
	public void actualizarTabPlayerLevelCost () {canvasText.playerLvCost.text = numbersConverter.numbersBigFormat(player.levelCost);}
	// Metodo para actualizar el texto "playerAtkToAdd"
	public void actualizarTabPlayerAtkToAdd () {canvasText.playerAtkToAdd.text = "+"+numbersConverter.numbersBigFormat(player.attackToAdd)+" Dmg";}
	// Metodo para actualizar el texto "playerMoney"
	public void actualizarTabPlayerMoney () {
		if (player.money < 1) {
			canvasText.playerTabMoney.text = "0";//tab 1
			canvasText.playerTabMoney2.text = "0";//tab 2
		} else {
			canvasText.playerTabMoney.text = numbersConverter.numbersBigFormat (player.money);//tab 1
			canvasText.playerTabMoney2.text = numbersConverter.numbersBigFormat (player.money);//tab 2
		}
	}
	// Metodo para actualizar el texto "playerTabUranium"
	public void actualizarTabPlayerUranium (){
		if (player.uranium < 1) {
			canvasText.playerTabUranium.text = "0";
		} else {
			canvasText.playerTabUranium.text = numbersConverter.numbersBigFormat (player.uranium);
		}
	}
	// Metodo para actualizar el texto "playerTabCrystals"
	public void actualizarTabPlayerCrystals (){
		if(player.crystals < 1){
			canvasText.playerTabCrystals.text = "0";
		}else{
			canvasText.playerTabCrystals.text = numbersConverter.numbersBigFormat(player.crystals);
		}

	}

	//BOB----------------------------------------------------------------------------------------------------------------------*
	// Metodo para actualizar el texto "bobAtk"
	public void actualizarTabBobAtk () {
		if(characterBob.level > 0){
			canvasText.bobAtk.text = numbersConverter.numbersBigFormat(characterBob.atk);
		}else{
			canvasText.bobAtk.text = "0";
		}
	}
	// Metodo para actualizar el texto "bobLevel"
	public void actualizarTabBobLevel () {
		if(characterBob.level > 0){
			canvasText.bobLevel.text = numbersConverter.numbersBigFormat(characterBob.level);
		}else{
			canvasText.bobLevel.text = "0";
		}
	}
	// Metodo para actualizar el texto "bobLevelCost"
	public void actualizarTabBobLevelCost () {canvasText.bobLvCost.text = numbersConverter.numbersBigFormat(characterBob.levelCost);}
	// Metodo para actualizar el texto "bobAtkToAdd"
	public void actualizarTabBobAtkToAdd () {canvasText.bobAtkToAdd.text = "▲"+numbersConverter.numbersBigFormat(characterBob.atkToAdd);}
	public void actualizarTabBobUnlockTxt () {
		if (characterBob.level < 1) {
			canvasText.bobUnlock.text = "Unlock";
		} else {
			canvasText.bobUnlock.text = "Level Up";
		}
	}

	//DogBot------------------------------------------------------------------------------------------------------*
	public void actualizarTabDogBotAtk(){
		if(characterDogBotBobby.level > 0){
			canvasText.dogBotAtk.text = numbersConverter.numbersBigFormat(characterDogBotBobby.atk);
		}else{
			canvasText.dogBotAtk.text = "0";
		}
	}
	//
	public void actualizarTabDogBotLevel (){
		if(characterDogBotBobby.level > 0){
			canvasText.dogBotLevel.text = numbersConverter.numbersBigFormat(characterDogBotBobby.level);
		}else{
			canvasText.dogBotLevel.text = "0";
		}
	}
	//
	public void actualizarTabDogBotLevelCost (){canvasText.dogBotLvCost.text = numbersConverter.numbersBigFormat(characterDogBotBobby.levelCost);}
	//
	public void actualizarTabDogBotAtkToAdd (){canvasText.dogBotAtkToAdd.text = "▲"+numbersConverter.numbersBigFormat(characterDogBotBobby.atkToAdd);}
	//
	public void actualizarTabDogBotUnlockTxt (){
		if (characterDogBotBobby.level < 1) {
			canvasText.dogBotUnlock.text = "Unlock";
		} else {
			canvasText.dogBotUnlock.text = "Level Up";
		}
	}

	//Robo--------------------------------------------------------------------------------------------------------*
	public void actualizarTabRoboAtk(){
		if(characterRoboJake.level > 0){
			canvasText.roboBotAtk.text = numbersConverter.numbersBigFormat(characterRoboJake.atk);
		}else{
			canvasText.roboBotAtk.text = "0";
		}
	}
	//
	public void actualizarTabRoboLevel (){
		if(characterRoboJake.level > 0){
			canvasText.roboBotLevel.text = numbersConverter.numbersBigFormat(characterRoboJake.level);
		}else{
			canvasText.roboBotLevel.text = "0";
		}
	}
	//
	public void actualizarTabRoboLevelCost (){canvasText.roboBotLvCost.text = numbersConverter.numbersBigFormat(characterRoboJake.levelCost);}
	//
	public void actualizarTabRoboAtkToAdd (){canvasText.roboBotAtkToAdd.text = "▲"+numbersConverter.numbersBigFormat(characterRoboJake.atkToAdd);}
	//
	public void actualizarTabRoboUnlockTxt (){
		if (characterRoboJake.level < 1) {
			canvasText.roboBotUnlock.text = "Unlock";
		} else {
			canvasText.roboBotUnlock.text = "Level Up";
		}
	}

	//Dron--------------------------------------------------------------------------------------------------------*
	public void actualizarTabDronAtk(){
		if(characterDron.level > 0){
			canvasText.DronAtk.text = numbersConverter.numbersBigFormat(characterDron.atk);
		}else{
			canvasText.DronAtk.text = "0";
		}
	}
	//
	public void actualizarTabDronLevel (){
		if(characterDron.level > 0){
			canvasText.DronLevel.text = numbersConverter.numbersBigFormat(characterDron.level);
		}else{
			canvasText.DronLevel.text = "0";
		}
	}
	//
	public void actualizarTabDronLevelCost (){canvasText.DronLvCost.text = numbersConverter.numbersBigFormat(characterDron.levelCost);}
	//
	public void actualizarTabDronAtkToAdd (){canvasText.DronAtkToAdd.text = "▲"+numbersConverter.numbersBigFormat(characterDron.atkToAdd);}
	//
	public void actualizarTabDronUnlockTxt (){
		if (characterDron.level < 1) {
			canvasText.DronUnlock.text = "Unlock";
		} else {
			canvasText.DronUnlock.text = "Level Up";
		}
	}

	//Litus-------------------------------------------------------------------------------------------------------*
	public void actualizarTabLitusAtk(){
		if(characterLitus.level > 0){
			canvasText.LitusAtk.text = numbersConverter.numbersBigFormat(characterLitus.atk);
		}else{
			canvasText.LitusAtk.text = "0";
		}
	}
	//
	public void actualizarTabLitusLevel (){
		if(characterLitus.level > 0){
			canvasText.LitusLevel.text = numbersConverter.numbersBigFormat(characterLitus.level);
		}else{
			canvasText.LitusLevel.text = "0";
		}
	}
	//
	public void actualizarTabLitusLevelCost (){canvasText.LitusLvCost.text = numbersConverter.numbersBigFormat(characterLitus.levelCost);}
	//
	public void actualizarTabLitusAtkToAdd (){canvasText.LitusAtkToAdd.text = "▲"+numbersConverter.numbersBigFormat(characterLitus.atkToAdd);}
	//
	public void actualizarTabLitusUnlockTxt (){
		if (characterLitus.level < 1) {
			canvasText.LitusUnlock.text = "Unlock";
		} else {
			canvasText.LitusUnlock.text = "Level Up";
		}
	}

	//Sharot------------------------------------------------------------------------------------------------------*

	// Metodos para actualizar los textos de Partner Sharot
	public void actualizarTabSharotAtk(){
		if(characterSharot.level > 0){
			canvasText.SharotAtk.text = numbersConverter.numbersBigFormat(characterSharot.atk);
		}else{
			canvasText.SharotAtk.text = "0";
		}
	}
	public void actualizarTabSharotLevel (){
		if(characterSharot.level > 0){
			canvasText.SharotLevel.text = numbersConverter.numbersBigFormat(characterSharot.level);
		}else{
			canvasText.SharotLevel.text = "0";
		}
	}
	public void actualizarTabSharotLevelCost (){canvasText.SharotLvCost.text = numbersConverter.numbersBigFormat(characterSharot.levelCost);}
	public void actualizarTabSharotAtkToAdd (){canvasText.SharotAtkToAdd.text = "▲"+numbersConverter.numbersBigFormat(characterSharot.atkToAdd);}
	public void actualizarTabSharotUnlockTxt (){
		if (characterSharot.level < 1) {
			canvasText.SharotUnlock.text = "Unlock";
		} else {
			canvasText.SharotUnlock.text = "Level Up";
		}
	}

	//Mateo-------------------------------------------------------------------------------------------------------*

	// Metodos para actualizar los textos de Partner Mateo
	public void actualizarTabMateoAtk(){
		if(characterMateo.level > 0){
			canvasText.MateoAtk.text = numbersConverter.numbersBigFormat(characterMateo.atk);
		}else{
			canvasText.MateoAtk.text = "0";
		}
	}
	public void actualizarTabMateoLevel (){
		if(characterMateo.level > 0){
			canvasText.MateoLevel.text = numbersConverter.numbersBigFormat(characterMateo.level);
		}else{
			canvasText.MateoLevel.text = "0";
		}
	}
	public void actualizarTabMateoLevelCost (){canvasText.MateoLvCost.text = numbersConverter.numbersBigFormat(characterMateo.levelCost);}
	public void actualizarTabMateoAtkToAdd (){canvasText.MateoAtkToAdd.text = "▲"+numbersConverter.numbersBigFormat(characterMateo.atkToAdd);}
	public void actualizarTabMateoUnlockTxt (){
		if (characterMateo.level < 1) {
			canvasText.MateoUnlock.text = "Unlock";
		} else {
			canvasText.MateoUnlock.text = "Level Up";
		}
	}

	//Bik---------------------------------------------------------------------------------------------------------*

	// Metodos para actualizar textos de partner Bik
	public void actualizarTabBikAtk(){
		if(characterBik.level > 0){
			canvasText.BikAtk.text = numbersConverter.numbersBigFormat(characterBik.atk);
		}else{
			canvasText.BikAtk.text = "0";
		}
	}
	public void actualizarTabBikLevel (){
		if(characterBik.level > 0){
			canvasText.BikLevel.text = numbersConverter.numbersBigFormat(characterBik.level);
		}else{
			canvasText.BikLevel.text = "0";
		}
	}
	public void actualizarTabBikLevelCost (){canvasText.BikLvCost.text = numbersConverter.numbersBigFormat(characterBik.levelCost);}
	public void actualizarTabBikAtkToAdd (){canvasText.BikAtkToAdd.text = "▲"+numbersConverter.numbersBigFormat(characterBik.atkToAdd);}
	public void actualizarTabBikUnlockTxt (){
		if (characterBik.level < 1) {
			canvasText.BikUnlock.text = "Unlock";
		} else {
			canvasText.BikUnlock.text = "Level Up";
		}
	}

	//Laser-------------------------------------------------------------------------------------------------------*
	// Metodos para actualizar los textos de Los botones del Partner Laser
	public void actualizarTabLaserAtk(){
		if(characterLaser.level > 0){
			canvasText.LaserAtk.text = numbersConverter.numbersBigFormat(characterLaser.atk);
		}else{
			canvasText.LaserAtk.text = "0";
		}
	}
	public void actualizarTabLaserLevel (){
		if(characterLaser.level > 0){
			canvasText.LaserLevel.text = numbersConverter.numbersBigFormat(characterLaser.level);
		}else{
			canvasText.LaserLevel.text = "0";
		}
	}
	public void actualizarTabLaserLevelCost (){canvasText.LaserLvCost.text = numbersConverter.numbersBigFormat(characterLaser.levelCost);}
	public void actualizarTabLaserAtkToAdd (){canvasText.LaserAtkToAdd.text = "▲"+numbersConverter.numbersBigFormat(characterLaser.atkToAdd);}
	public void actualizarTabLaserUnlockTxt (){
		if (characterLaser.level < 1) {
			canvasText.LaserUnlock.text = "Unlock";
		} else {
			canvasText.LaserUnlock.text = "Level Up";
		}
	}

	//"Weapons"---------------------------------------------------------------------------------------------------*

	//Metodo para actualizar el texto "weaponUnlockCost"
	public void actualizarTabWeaponUnlockCost () {canvasText.weaponUnlockCost.text = numbersConverter.numbersBigFormat(weaponRandom.weaponUnlockCost);}

	// Metodos para actualizar los textos weapon01
	public void actualizarTabWeapon01Level (){canvasText.weapon01Lv.text = numbersConverter.numbersBigFormat(weapon_01.level);}
	public void actualizarTabWeapon01Atribute (){canvasText.weapon01Atribute.text = numbersConverter.numbersBigFormat(weapon_01.atribute)+"%";}
	public void actualizarTabWeapon01LevelCost (){canvasText.weapon01LvCost.text = numbersConverter.numbersBigFormat(weapon_01.levelCost);}
	public void actualizarTabWeapon01AtributeToAdd (){canvasText.weapon01AtributeToAdd.text = "+ "+numbersConverter.numbersBigFormat(weapon_01.atributeToAdd)+"%";}

	// Metodos para actualizar los textos weapon02
	public void actualizarTabWeapon02Level (){canvasText.weapon02Lv.text = numbersConverter.numbersBigFormat(weapon_02.level);}
	public void actualizarTabWeapon02Atribute (){canvasText.weapon02Atribute.text = numbersConverter.numbersBigFormat(weapon_02.atribute)+"%";}
	public void actualizarTabWeapon02LevelCost (){canvasText.weapon02LvCost.text = numbersConverter.numbersBigFormat(weapon_02.levelCost);}
	public void actualizarTabWeapon02AtributeToAdd (){canvasText.weapon02AtributeToAdd.text = "+ "+numbersConverter.numbersBigFormat(weapon_02.atributeToAdd)+"%";}

	// Metodos para actualizar los textos weapon03
	public void actualizarTabWeapon03Level (){canvasText.weapon03Lv.text = numbersConverter.numbersBigFormat(weapon_03.level);}
	public void actualizarTabWeapon03Atribute (){canvasText.weapon03Atribute.text = numbersConverter.numbersBigFormat(weapon_03.atribute)+"%";}
	public void actualizarTabWeapon03LevelCost (){canvasText.weapon03LvCost.text = numbersConverter.numbersBigFormat(weapon_03.levelCost);}
	public void actualizarTabWeapon03AtributeToAdd (){canvasText.weapon03AtributeToAdd.text = "+ "+numbersConverter.numbersBigFormat(weapon_03.atributeToAdd)+"%";}

	//Ability -----------------------------------------------------------------------------------------------*

	// Metodos para actualizar los textos ability01
	public void actualizarTabAbility01Level (){canvasText.Ability01Lv.text = numbersConverter.numbersBigFormat(ability_01.level);}
	public void actualizarTabAbility01Atribute (){canvasText.Ability01Atribute.text = "x"+numbersConverter.numbersBigFormat(ability_01.damageMultiply);}
	public void actualizarTabAbility01LevelCost (){canvasText.Ability01LvCost.text = numbersConverter.numbersBigFormat(ability_01.levelCost);}
	public void actualizarTabAbility01AtributeToAdd (){canvasText.Ability01AtributeToAdd.text = "+ "+numbersConverter.numbersBigFormat(ability_01.damageBase);}
	//
	public void actualizarTabAbility01Cooldown () {
		if (ability_01.cooldownTime > 0) {
			canvasText.Ability01Cooldown.text = numbersConverter.numbersTimeFormat (ability_01.cooldownTime);
		} else {
			canvasText.Ability01Cooldown.text = "";
		}
	}

	// Metodos para actualizar los textos ability04
	public void actualizarTabAbility04Level (){canvasText.Ability04Lv.text = numbersConverter.numbersBigFormat(ability_04.level);}
	public void actualizarTabAbility04Atribute (){canvasText.Ability04Atribute.text = "+ "+numbersConverter.numbersBigFormat(ability_04.goldPorcentPerTap)+"%";}
	public void actualizarTabAbility04LevelCost (){canvasText.Ability04LvCost.text = numbersConverter.numbersBigFormat(ability_04.levelCost);}
	public void actualizarTabAbility04AtributeToAdd (){canvasText.Ability04AtributeToAdd.text = "+ "+numbersConverter.numbersBigFormat(ability_04.goldPorcentPerTapBase)+"%";}
	//
	public void actualizarTabAbility04Cooldown () {
		if (ability_04.cooldownTime > 0) {
			canvasText.Ability04Cooldown.text = numbersConverter.numbersTimeFormat (ability_04.cooldownTime);
		} else {
			canvasText.Ability04Cooldown.text = "";
		}
	}
	//
	public void actualizarTabAbility04PowUpDuration () {
		if (ability_04.powerUpDuration > 0) {
			canvasText.Ability04PowUpDuration.text = numbersConverter.numbersTimeFormat (ability_04.powerUpDuration);
		} else {
			canvasText.Ability04PowUpDuration.text = "";
		}
	}

	// Metodo para actualizar el texto "ability00Name"
	public void actualizarTabAbility00Name (){
		if(player.level < 500){
			canvasText.Ability00Name.text = "Unlock";
		}else{
			canvasText.Ability00Name.text = "Time Travel";
		}
	}
	//
	public void actualizarTabAbility00WhatToDo (){
		if(player.level < 500){
			canvasText.Ability00WhatToDo.text = "Lv 600+";
		}else{
			canvasText.Ability00WhatToDo.text = "Lets do it";
		}
	}

	// Other-------------------------------------------------------------------------------------------------*
	public void actualizarMonstersName (string text) {
		canvasText.monstersName.text = text;
	}

	//--------------------------------------------------------------------------------------------------------

	// Metodo para calculo del dano total de los companeros
	float calculoPartnersDPS () {
		partnersTotalDPS = 
			characterBob.DPS +                            // Partner 01 Dps
			characterDogBotBobby.DPS +                    // Partner 02 Dps
			characterRoboJake.DPS +                       // Partner 03 Dps
			characterDron.DPS +                           // Partner 04 Dps
			characterLitus.DPS +                          // Partner 05 Dps
			characterSharot.DPS +                         // Partner 06 Dps
			characterMateo.DPS +                          // Partner 07 Dps
			characterBik.DPS +                            // Partner 08 Dps
			characterLaser.DPS;                           // Partner 09 Dps
		actualizarPartnersDPS ();
		return partnersTotalDPS;
	}

	// Metodo para el conteo de las oleadas
	void conteoStageLevel () {
		if(level <= 3000){
			if(stage > stageL){
				stage = 1;
				level++;
				actualizarLevel ();
				actualizarStage ();
			}
		}
	}

	// Metodo para calcular cuanto dinero suelta el enemigo al ser derrotado
	void formulaMoney () {
		player.money += monster.money;
		player.totalMoney += monster.money;
		actualizarMoney ();
		actualizarTabPlayerMoney ();
	}

	// Metodo para generar una instancia de la moneda
	/*void monedaCayendo (){
		if (level < 3) {
			randomCoinsNumber = Random.Range (1, 2);
		} else if (level < 5) {
			randomCoinsNumber = Random.Range (1, 3);
		} else if (level < 10) {
			randomCoinsNumber = Random.Range (1, 5);
		} else {
			randomCoinsNumber = Random.Range (3,6);
		}

		for(int i = 1; i <= randomCoinsNumber; i++){
			Instantiate (fallingCoin);
		}
		//Debug.Log (randomCoinsNumber);
	}*/

	// Metodo para cuando muere un enemigo
	void muerteEnemigo () {
		if (monster.hp < 1 && monsterDeathTime == 0) {
			coins.Play ();
			Instantiate (coins);
		}

		if(monster.hp < 1){
			monsterDeathTime += Time.deltaTime;
			shake.GetComponent<ShakeObj>().trigger = false;
			monsterDeathTimeActivation = true;
		}

		if(monster.hp < 1 && monsterDeathTime >= 0.75f){
			randomNumber = Random.Range(1,72);
			monsterFadeIn = true;
			monsterFadeOut = true;
			monster.monsterHpMaxCalculation ();
			formulaMoney ();

			if(level % 5 == 0 && stage == stageL){
				backgroundScript.backgroundNumber++;
				if(backgroundScript.backgroundNumber == backgroundScript.backgroundList.Length){
					backgroundScript.backgroundNumber = 0;
				}
			}

			if(!beforeBossTraining){
			    stage++;
				actualizarStage ();
			} 
			actualizarStage ();

			//monedaCayendo();
			monsterDeathTime = 0f;
			monsterDeathTimeActivation = false;
		}

		if (monsterDeathTime >= 0.75f) {
			backgroundChangeActivation = true;
			stageChangeActivation = true;
		} else {
			backgroundChangeActivation = false;
			stageChangeActivation = false;
		}
	}
		
	// Metodo para el ataque critico
	void criticAtk(){monster.hp = monster.hp - player.criticAttack;}// Calculo del dano critico
	// Metodo para el ataque normal
	void normalAtk(){monster.hp = monster.hp - player.totalAttack;}// Calculo del dano
	// Metodo para actualizar la barra de vida
	public void actualizarBarraDeVida(){HealthBar.size = monster.hp / monster.hpMax;}// Calculo para la barra de vida

	// Metodo para calcular el dano del enemigo
	void danoEnemigo () {
		if (critic >= randomCriticNumber) {
			criticAtk ();
			criticTMdamageView ();

		} else {
			normalAtk ();
			TMdamageView ();
		}
		actualizarHp ();
		actualizarBarraDeVida ();
	}

	// Metodo para cambiar la escala tanto en "x" como en "y" de un GameObject
	void cambiarEscala (GameObject gamObj, float valorX, float valorY) {
		var scaleTransform = gamObj.transform.localScale;
		scaleTransform.x = valorX;
		scaleTransform.y = valorY;
		gamObj.transform.localScale = scaleTransform;
	}

	// Metodo para mostrar el stage o si es una boss fight y tambien mostrar el boton
	//de salir o no de una boss fight
	void controlOfTheStage (){
		//si stage es igual al limite
		if(stage == stageL){
			stageControl.SetActive (false);// desactivame stageControl "10/10"
			bossStageControl.SetActive (true);// activame bossStageControl "Boss"
			trainingControl.SetActive (false);// desactivame texto de training
			if(!monsterDeathTimeActivation){
				bossBtn2.SetActive (true);// activame boton de boss "Leave Fight"
			}
		}
		//si stage no es igual al limite
		if(stage != stageL){
			stageControl.SetActive (true);// activame stageControl
			bossStageControl.SetActive (false);// desactivame bossStageControl
			trainingControl.SetActive (false);// desactivame texto de training

			bossBtn.SetActive (false);// desactivame boton 1 de boss "Boss Fight"
			bossBtn2.SetActive (false);// desactivame boton 2 de boss "Leave Fight"
		}
		//si stage no es igual al limite y beforeBossTraining esta activada
		if(stage != stageL && beforeBossTraining){
			stageControl.SetActive (false);// desactivame stageControl "10/10"
			trainingControl.SetActive (true);// activame texto de training

			bossBtn2.SetActive (false);// desactivame boton 2 de boss "Leave Fight"
			if(!monsterDeathTimeActivation){
				bossBtn.SetActive (true);// activame boton 1 de boss "Boss Fight"
			}
		}
	}

	// Metodo para encontrarse un enemigo cada 10 oleadas
	void bossEnemigo () {
		// Si el stage alcanzo el limite ex: "10/10" y el residuo de level/5 = 0,
		//entonces se activa un encuentro con un boss y se efectua el calculo de su respectiva vida
		if (stage == stageL && level % 5 != 0 && bossEncounter == true) {
			monster.bossHpMaxCalculation ();
			bossEncounter = false;  

		}
		// Si el stage no es igual al limite se desactiva el encuentro con un boss
		if(stage != stageL){
			bossEncounter = true;
		}
	}

	// Metodo para encontrarse con un mega boss
	void megaBossEnemigo () {
		// Si el residuo de level/5 es 0 y stage alcanza el limite entonces se activa
		//un encuentro con un mega boss
		if (level % 5 == 0 && stage == stageL && megaBossEncounter == true) {
			monster.megaBossHpMaxCalculation ();
			megaBossEncounter = false;  

		}
		// Si el residuo de level/5 no es 0 y stage no alcanza el limit se desactiva el encuentro
		// con un mega boss
		if(level % 5 != 0 && stage != stageL){
			megaBossEncounter = true;
		}
		// Pequena condicional para cambiar la escala si es un mega boss
		if (level % 5 == 0 && stage == stageL) {
			cambiarEscala (enemy, 2f, 2f);
		} else {
			cambiarEscala (enemy,1.5f,1.5f);
		}
	}

	// Metodo para activar el aura del boss
	void auraBossActivate(){
		if (stage == stageL) {
			bossAura.Play ();
		} else {
			bossAura.Stop ();
		}
	}

	// Metodo para mostrar la alerta de Boss cuando stage llega al limite
	void bossAlertMovement () {
		if(stage == stageL && level % 5 != 0){
			bossAlertCam.SetActive(true);
		}
		if(stage != stageL){
			bossAlertCam.SetActive(false);
		}
	}// TMbossAlertMovemet End

	// Metodo final para animacion de Mega Boss alert
	void megaBossAlertMovement () {
		if(level % 5 == 0 && stage == stageL){
			megaBossAlertCam.SetActive (true);
		}
		if(level % 5 != 0 && stage != stageL){
			megaBossAlertCam.SetActive (false);
		}
	}

	// Metodo para mostrar el dano causado al enemigo con una pulsacion/toque
	void TMdamageView () {
		//if(monsterDeathTime < 0.01){
			if(Input.GetKeyDown (KeyCode.A) || playerTouch){
				damShow = true;
			}
			if(damShow){
				Instantiate (dmgText);
				damShow = false;
			}
		//}
	}// TMdamageView End

	// Metodo para mostrar el dano critico causado al enemigo con una pulsacion/toque
	void criticTMdamageView () {
		//if(!monsterDeathTimeActivation){
			if(Input.GetKeyDown (KeyCode.A) || playerTouch){
				criDamShow = true;
			}
			if(criDamShow){
				Instantiate (criDmgText);
				criDamShow = false;
			}
		//}
	}// criticTMdamageView End

	// Metodo para cambiar la position de los Scroll
	void scrollPosition (Scrollbar Variable, string pos, float value){
		var scroll = Variable.handleRect.position;
		if(pos == "x"){ scroll.x = value;}
		if(pos == "y"){ scroll.y = value;}
		if(pos == "z"){ scroll.z = value;}
		Variable.handleRect.position = scroll;
	}

	// Metodo para cambiar la position de los TextMesh
	void textMeshPosition (TextMesh Variable, string pos, float value){
		var scroll = Variable.transform.position;
		if(pos == "x"){ scroll.x = value;}
		if(pos == "y"){ scroll.y = value;}
		if(pos == "z"){ scroll.z = value;}
		Variable.transform.position = scroll;
	}

	// Metodo para la barra de tiempo 
	void barraDeTiempo () {
		if(stage == stageL && bossTimeActivation == false){
			scrollPosition (TimeBar, "z", 2);
			//textMeshPosition (TMbossTime, "z", 2);
			bossTimeText.SetActive(true);
			relojSprite.SetActive (true);
			TimeBar.size = bossTime;
			bossTime -= Time.deltaTime;
			TimeBar.size = bossTime / bossTimeLimit;
			actualizarBossTime ();
			if(bossTime <= 0 && !monsterDeathTimeActivation){
				stage--;
				bossTime = bossTimeLimit;
				TimeBar.size = bossTime;
				monster.monsterHpMaxCalculation ();
				//formulaVida ();
				actualizarStage ();
				actualizarBossTime ();
				beforeBossTraining = true;
				bossTimeActivation = true;
			}
		}
		if(stage != stageL){
			scrollPosition (TimeBar, "z", -3);
			//textMeshPosition (TMbossTime, "z", -3);
			bossTimeText.SetActive(false);
			relojSprite.SetActive (false);
			bossTime = bossTimeLimit;
			bossTimeActivation = false;
		}
	}// barraDeTiempo End

	void gettingUraniumFromMonsters () {
		if(level > 79 && level % 5 == 0 && monsterDeathTimeActivation){
			player.uranium++;
		}
	}

	// Metodo para deteccion de ataque de companero y actualize tanto
	//vida como barra de vida
	void partnerAtkDetection () {
		if(partnerAtkActivation == true){
			actualizarHp ();
			actualizarBarraDeVida ();
		}
	}

	// Metodo para no mostrar numeros negativos en la vida de los monstruos
	void makingMonsterHp0 (){
		if(monster.hp < 0){
			monster.hp = 0;
		}
	}

	// Metodo para instanciar la animacion de "Tap"
	public void tapAnimationActivation () {
		Instantiate (tapAnimation);
	}

	//
	void settingAbilitiesButtons () {
		if (player.level >= 100) {
			ability01UseBtn.SetActive (true);
			settingTurnOnColor (ability01Colors);

			ability01TextColors [0].color = levelPointsColor;
			ability01TextColors [1].color = damagePointsColor;
			ability01TextColors [2].color = levelCostColor;
		}/* else if (player.level >= 200) {
			ability01UseBtn.SetActive (true);		
		} else if (player.level >= 300) {
			ability01UseBtn.SetActive (true);
		}*/ else if (player.level >= 400) {
			ability04UseBtn.SetActive (true);
			settingTurnOnColor (ability04Colors);

			ability04TextColors [0].color = levelPointsColor;
			ability04TextColors [1].color = damagePointsColor;
			ability04TextColors [2].color = levelCostColor;
		}/* else if (player.level >= 500) {
			ability01UseBtn.SetActive (true);
		}*/ else {
			// ability01
			ability01UseBtn.SetActive (false);
			settingTurnOffColor (ability01Colors);
			settingTurnOffTextColor (ability01TextColors);

			// ability04
			ability04UseBtn.SetActive (false);
			settingTurnOffColor (ability04Colors);
			settingTurnOffTextColor (ability04TextColors);
		}
	}

	// Metodo para igualar las variables del script de guardado a las variables del juego a cada frame
	void passingVariablesToSave () {
		gameStatus.level = level;
		gameStatus.stage = stage;
		gameStatus.stageL = stageL;
		gameStatus.randomNumber = randomNumber;
		gameStatus.beforeBossTraining = beforeBossTraining;
	}

	// prueba
	void abc () {
		if(Input.GetKeyDown(KeyCode.H)){
			player.uranium += 50;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!monsterDeathTimeActivation){
			if (Input.GetKeyDown (KeyCode.A)  || playerTouch) {
				randomCriticNumber = Random.Range (1,100);
				//Debug.Log (randomCriticNumber);
				danoEnemigo ();
				blood.Play ();
				blood2.Play ();
				shake.GetComponent<ShakeObj>().trigger = true;

				// Activando los metodos de reproducir los sistemas de particulas de sangre
				blood.Play ();
				blood2.Play ();
			}
		}

		if(Input.GetKeyDown (KeyCode.A) || playerTouch){
			player.taps++;
			tapShot.Play();
		}

		conteoStageLevel ();
		muerteEnemigo ();
		bossEnemigo ();
		megaBossEnemigo ();
		bossAlertMovement ();
		megaBossAlertMovement ();
		barraDeTiempo ();
		partnerAtkDetection ();
		calculoPartnersDPS ();
		controlOfTheStage ();
		makingMonsterHp0 ();
		gettingUraniumFromMonsters ();
		//auraBossActivate ();
		abc();
		settingAbilitiesButtons ();

		actualizarMoney ();
		actualizarTabPlayerMoney ();
		actualizarTabPlayerUranium ();

		passingVariablesToSave ();

		actualizarEveryAtkText ();

		gameStatus.Save ();// Para guardar la partida a cada frame
	}// Update End
}// monsterHp.cs End
