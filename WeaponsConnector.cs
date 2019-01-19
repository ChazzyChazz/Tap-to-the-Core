using UnityEngine;
using System.Collections;

public class WeaponsConnector : MonoBehaviour {

	//Weapons
	public Weapon01 weapon_01;// Plasma Gun              atk % = 10 x Lv
	public Weapon02 weapon_02;// Rectificator            atk % = 15 x Lv
	public Weapon03 weapon_03;// Plasma Gatling          atk % = 20 x Lv

	// Variables
	public float wholeAttackPorcentToAdd;

	// Use this for initialization
	void Start () {
	
	}

	// Metodo para guardar los valores porcentuales a anadir al ataque del jugador
	public float OverallAtkPorcentToAdd () {
		wholeAttackPorcentToAdd = weapon_01.atributeToGet +
		weapon_02.atributeToGet +
		weapon_03.atributeToGet;

		return wholeAttackPorcentToAdd;
	}

	//
	public void RefreshPorcent () {
		weapon_01.addingAtribute ();
		weapon_02.addingAtribute ();
		weapon_03.addingAtribute ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (OverallAtkPorcentToAdd());
	}
}
