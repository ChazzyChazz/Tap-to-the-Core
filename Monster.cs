using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	public monsterHp mainScript;

	// Variables estado de los monstruos
	public float hpMax;// controla los puntos de vida maximos de los monstruos
	public float hp;// controla los puntos de vida de los monstruos
	public float hpBase = 18.5f;
	public float money;// controla el dinero que dara al ser derrotado el monstruo
	public float baseMoney;
	//public float money;// controla el dinero que sueltan los monstruos al ser derrotados
	public float healthLerpSpeed = 2f;

	// Use this for initialization
	void Start () {
		monsterHpMaxCalculation ();
		baseMoney = 1f;
		money = baseMoney;
		//monsterHpCalculation ();
	}

	// Metodo para calcular la vida actual del monstruo
	void monsterHpCalculation () {
		hp = hpMax;
	}

	// Metodo para calcular la vida maxima del monstruo
	public void monsterHpMaxCalculation () {
		hpMax = 18.5f * Mathf.Pow (1.57f, Mathf.Min (mainScript.level, 156f)) * Mathf.Pow (1.17f,Mathf.Max(mainScript.level - 156f, 0.5f));
		monsterHpCalculation ();
		mainScript.actualizarHp ();
		mainScript.HealthBar.size = hpMax;
		//mainScript.HealthBar.size = Mathf.Lerp(mainScript.HealthBar.size, hpMax, Time.deltaTime * healthLerpSpeed);
	}

	// Metodo para calcular la vida maxima del monstruo
	public void bossHpMaxCalculation () {
		hpMax = (18.5f * Mathf.Pow (1.57f, Mathf.Min (mainScript.level, 156f)) * Mathf.Pow (1.17f,Mathf.Max(mainScript.level - 156f, 0.5f))) *10;
		monsterHpCalculation ();
		mainScript.actualizarHp ();
		mainScript.HealthBar.size = hpMax;
	}

	// Metodo para calcular la vida maxima del monstruo
	public void megaBossHpMaxCalculation () {
		hpMax = (18.5f * Mathf.Pow (1.57f, Mathf.Min (mainScript.level, 156f)) * Mathf.Pow (1.17f,Mathf.Max(mainScript.level - 156f, 0.5f))) *20;
		monsterHpCalculation ();
		mainScript.actualizarHp ();
		mainScript.HealthBar.size = hpMax;
	}

	// Metodo para calcular la vida maxima de boss/megaBoss al presionar el boton de training area
	public void boss_megaBoss_HpMaxCalculation () {
		if(mainScript.level % 5 == 0 && mainScript.stage == mainScript.stageL){
			hpMax = (18.5f * Mathf.Pow (1.57f, Mathf.Min (mainScript.level, 156f)) * Mathf.Pow (1.17f,Mathf.Max(mainScript.level - 156f, 0.5f))) *20;
		}else if (mainScript.level % 5 != 0 && mainScript.stage == mainScript.stageL) {
			hpMax = (18.5f * Mathf.Pow (1.57f, Mathf.Min (mainScript.level, 156f)) * Mathf.Pow (1.17f,Mathf.Max(mainScript.level - 156f, 0.5f))) *10;
		}
		monsterHpCalculation ();
		mainScript.actualizarHp ();
		mainScript.HealthBar.size = hpMax;
	}

	// Metodo para calcular el dinero a soltar al ser derrotado el monstruo
	void monsterMoneyCalculation () {
		if(mainScript.level % 5 == 0 && mainScript.stage == mainScript.stageL){
			money = ((Mathf.Pow (baseMoney * Mathf.Pow (mainScript.level * 1.025f, baseMoney * 1.035f), 1.058f)) * mainScript.level) * 25f;
		}else if(mainScript.level % 5 != 0 && mainScript.stage == mainScript.stageL){
			money = ((Mathf.Pow (baseMoney * Mathf.Pow (mainScript.level * 1.025f, baseMoney * 1.035f), 1.058f)) * mainScript.level) * 10f;
		}else{
			money = (Mathf.Pow (baseMoney * Mathf.Pow (mainScript.level * 1.025f, baseMoney * 1.035f), 1.058f)) * mainScript.level;
		}
		//Debug.Log (money);
	}
	
	// Update is called once per frame
	void Update () {
		monsterMoneyCalculation ();
	}
}
