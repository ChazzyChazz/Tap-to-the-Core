using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetAviableToPushButton : MonoBehaviour {
	// Variables de otros scripts
	public Player player;
	public Bob characterBob;
	public RoboJake characterRobo;
	public DogBotBobby characterDogBot;
	public Dron characterDron;
	public Litus characterLitus;
	public Sharot characterSharot;
	public Mateo characterMateo;
	public Bik characterBik;
	public Laser characterLaser;

	public StopBgMusicButton stopBgMusBtn;
	public StopSoundEffectsButton stopEfcBtn;

	public Abilitie01_PlasmaGranade ability01;
	public Abilitie04_GoldShot ability04;

	// Variables tipo Image para los botones de upgrade
	public Image bobBtnImage;
	public Image playerBtnImage;
	public Image roboBtnImage;
	public Image dogBotBtnImage;
	public Image dronBtnImage;
	public Image litusBtnImage;
	public Image sharotBtnImage;
	public Image mateoBtnImage;
	public Image bikBtnImage;
	public Image laserBtnImage;

	// Variables tipo Image para los botones del canvas de menu
	public Image musicOnOff;
	public Image effectsOnOff;

	// Variables tipo Image para los botones de upgrade x10/x100
	public Image playerBtn_x10;
	public Image playerBtn_x100;
	public Image bobBtn_x10;
	public Image bobBtn_x100;
	public Image roboBtn_x10;
	public Image roboBtn_x100;
	public Image dogBotBtn_x10;
	public Image dogBotBtn_x100;
	public Image dronBtn_x10;
	public Image dronBtn_x100;
	public Image litusBtn_x10;
	public Image litusBtn_x100;
	public Image sharotBtn_x10;
	public Image sharotBtn_x100;
	public Image mateoBtn_x10;
	public Image mateoBtn_x100;
	public Image bikBtn_x10;
	public Image bikBtn_x100;
	public Image laserBtn_x10;
	public Image laserBtn_x100;

	// Variables tipo Image para los botones de Abilities
	public Image ability01BtnImage;
	public Image ability01UseBtnImage;
	public Image ability04BtnImage;
	public Image ability04UseBtnImage;
	public Image timeTravelBtnImage;

	// Use this for initialization
	void Start () {
		//
		gettingImgComponent(bobBtnImage, "BobUpgButton");
		gettingImgComponent(playerBtnImage, "PlayerUpgButton");
		gettingImgComponent(roboBtnImage, "RoboUpgButton");
		gettingImgComponent(dogBotBtnImage, "DogBotUpgButton");
		//
		gettingImgComponent(musicOnOff, "ButtonMusic");
		gettingImgComponent(effectsOnOff, "ButtonSounds");	
	}

	// Metodo para agilizar la obtencion del componente image del boton
	void gettingImgComponent (Image varName1, string varName2) {
		varName1 = GameObject.Find (varName2).GetComponent<Image> ();
	}

	// Metodo para agilizar la obtencion de la localizacion de las imagenes
	void gettingSpriteLocation (Image varName1, string varName2){
		varName1.sprite = Resources.Load<Sprite> (varName2);
	}

	// Metodo para cambiar el sprite del boton de upg si esta disponible
	void upgButtonSpriteChange (float varName1, float varName2,Image varName3){
		if ( varName1 <= varName2) {
			gettingSpriteLocation (varName3, "Sprites/UpgBtn/buyBtn1");
		} else {
			gettingSpriteLocation (varName3, "Sprites/UpgBtn/buyBtn2");
		}
	}

	// Metodo para cambiar el sprite de los botones x10/x100 si estan disponibles
	void upgButtonSpriteChange_x10_x100 (float varName1 ,Image varName2){
		if ( varName1 <= player.money) {
			gettingSpriteLocation (varName2, "Sprites/UpgBtn/x10_x100Btn1");
		} else {
			gettingSpriteLocation (varName2, "Sprites/UpgBtn/x10_x100Btn2");
		}
	}

	//
	void ButtonSpriteChangeManual (bool varName1 ,Image varName2, string varName3, string varName4){
		if (varName1) {
			gettingSpriteLocation (varName2, varName3);
		} else {
			gettingSpriteLocation (varName2, varName4);
		}
	}

	//
	void ButtonSpriteChangeManual2 (float varName1, float varName2,Image varName3, string varName4, string varName5){
		if (varName1 < varName2) {
			gettingSpriteLocation (varName3, varName4);
		} else {
			gettingSpriteLocation (varName3, varName5);
		}
	}
	
	// Update is called once per frame
	void Update () {
		upgButtonSpriteChange (player.levelCost, player.money, playerBtnImage);
		upgButtonSpriteChange (characterBob.levelCost, player.money, bobBtnImage);// 01
		upgButtonSpriteChange (characterRobo.levelCost, player.money, roboBtnImage);// 02
		upgButtonSpriteChange (characterDogBot.levelCost, player.money, dogBotBtnImage);// 03
		upgButtonSpriteChange (characterDron.levelCost, player.money, dronBtnImage);// 04
		upgButtonSpriteChange (characterLitus.levelCost, player.money, litusBtnImage);// 05
		upgButtonSpriteChange (characterSharot.levelCost, player.money, sharotBtnImage);// 06
		upgButtonSpriteChange (characterMateo.levelCost, player.money, mateoBtnImage);// 07
		upgButtonSpriteChange (characterBik.levelCost, player.money, bikBtnImage);// 08
		upgButtonSpriteChange (characterLaser.levelCost, player.money, laserBtnImage);// 09

		upgButtonSpriteChange (ability01.levelCost, player.money, ability01BtnImage);
		upgButtonSpriteChange (ability04.levelCost, player.money, ability04BtnImage);
		upgButtonSpriteChange (500, player.level, timeTravelBtnImage);

		ButtonSpriteChangeManual (stopBgMusBtn.turning, musicOnOff, "Sprites/OnOff/musicOn", "Sprites/OnOff/musicOff");
		ButtonSpriteChangeManual (stopEfcBtn.turning, effectsOnOff, "Sprites/OnOff/soundOn", "Sprites/OnOff/soundOff");

		upgButtonSpriteChange_x10_x100 (player.levelCost, playerBtn_x10); // player
		upgButtonSpriteChange_x10_x100 (player.levelCost * 15, playerBtn_x100);// player
		upgButtonSpriteChange_x10_x100 (characterBob.levelCost, bobBtn_x10);// bob
		upgButtonSpriteChange_x10_x100 (characterBob.levelCost * 15, bobBtn_x100);// bob
		upgButtonSpriteChange_x10_x100 (characterRobo.levelCost, roboBtn_x10);// robo
		upgButtonSpriteChange_x10_x100 (characterRobo.levelCost * 15, roboBtn_x100);// robo
		upgButtonSpriteChange_x10_x100 (characterDogBot.levelCost, dogBotBtn_x10);// dogBot
		upgButtonSpriteChange_x10_x100 (characterDogBot.levelCost * 15, dogBotBtn_x100);// dogBot
		upgButtonSpriteChange_x10_x100 (characterDron.levelCost, dronBtn_x10);// dron
		upgButtonSpriteChange_x10_x100 (characterDron.levelCost * 15, dronBtn_x100);// dron
		upgButtonSpriteChange_x10_x100 (characterLitus.levelCost, litusBtn_x10);// litus
		upgButtonSpriteChange_x10_x100 (characterLitus.levelCost * 15, litusBtn_x100);// litus
		upgButtonSpriteChange_x10_x100 (characterSharot.levelCost, sharotBtn_x10);// sharot
		upgButtonSpriteChange_x10_x100 (characterSharot.levelCost * 15, sharotBtn_x100);// sharot
		upgButtonSpriteChange_x10_x100 (characterMateo.levelCost, mateoBtn_x10);// mateo
		upgButtonSpriteChange_x10_x100 (characterMateo.levelCost * 15, mateoBtn_x100);// mateo
		upgButtonSpriteChange_x10_x100 (characterBik.levelCost, bikBtn_x10);// bik
		upgButtonSpriteChange_x10_x100 (characterBik.levelCost * 15, bikBtn_x100);// bik
		upgButtonSpriteChange_x10_x100 (characterLaser.levelCost, laserBtn_x10);// laser
		upgButtonSpriteChange_x10_x100 (characterLaser.levelCost * 15, laserBtn_x100);// laser

		ButtonSpriteChangeManual2 (ability01.cooldownTime, 1f, ability01UseBtnImage, "Sprites/OnOff/GranadeAbilityIconOn", "Sprites/OnOff/GranadeAbilityIconOff");
		ButtonSpriteChangeManual2 (ability04.cooldownTime, 1f, ability04UseBtnImage, "Sprites/OnOff/GoldShotAbilityIconOn", "Sprites/OnOff/GoldShotAbilityIconOff");

	}
}
