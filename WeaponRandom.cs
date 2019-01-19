using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponRandom : MonoBehaviour {

	//
	public float weaponUnlockCostBase;
	public float weaponUnlockCost;
	public GameObject[] weaponsButtonList;

	//
	public Player player;
	public monsterHp mainScript;
	public GameStatus gameStatus;

	// Lista a usar para el guardado de los numeros random sin repetir
	public List<int> usedValues = new List<int> ();

	// Use this for initialization
	void Start () {
		weaponUnlockCostBase = 3;
		weaponUnlockCost = weaponUnlockCostBase;

		actualizarTextWeaponUnlockCost ();
	}

	//
	void actualizarTextWeaponUnlockCost () {
		mainScript.actualizarTabWeaponUnlockCost ();
	}

	// Metodo para obtener un grupo de numeros random sin repeticion
	// Note: no usar numeros negativos
	int randomNumberWithoutRepeating (int min, int max) {
		int a = 0;
		while(a == 0 && usedValues.Count < max){
			a = Random.Range(min, max + 1);
			if (!usedValues.Contains (a)) {
				usedValues.Add (a);
			} else {
				a = 0;
			}
		}
		return a;
	}

	// Metodo para activar el boton respectivamente con el numero aleatoria que salga
	void settingButtonNumber (int num) {
		for(int i = 0; i < weaponsButtonList.Length; i++){
			if(num >= 0){
				weaponsButtonList [num].SetActive (true);
			}
		}
	}

	//
	void unlockWeaponCalculation () {
		weaponUnlockCost += usedValues.Count * 3; 
	}

	// Metodo final para hacer aparecer el arma correspondiente
	public void weaponRandomAppear () {
		//Debug.Log (weaponsButtonList.Length);
		if(player.uranium >= weaponUnlockCost){
			player.uranium -= weaponUnlockCost;

			int i;
			i = randomNumberWithoutRepeating (1, weaponsButtonList.Length);
			int weaponToActive = i - 1;
			settingButtonNumber (weaponToActive);
			unlockWeaponCalculation ();

			actualizarTextWeaponUnlockCost ();
			//Debug.Log (weaponToActive);
			//Debug.Log (usedValues.Count);
		}
	}

	void makingButtonsActiveIfAlreadyHaveSaved () {
		for (int i = 0; i < usedValues.Count; i++) {
			settingButtonNumber (usedValues[i] - 1);
			//Debug.Log (usedValues[i] - 1);
		}
	}

	void passingVariablesToSave () {
		//gameStatus.weaponButtonList = weaponsButtonList;
		gameStatus.usedValues = usedValues;
	}
	
	// Update is called once per frame
	void Update () {
		makingButtonsActiveIfAlreadyHaveSaved ();
		passingVariablesToSave ();
		//weaponRandomAppear ();
	}
}
