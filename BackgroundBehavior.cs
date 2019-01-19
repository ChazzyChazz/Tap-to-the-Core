using UnityEngine;
using System.Collections;

public class BackgroundBehavior : MonoBehaviour {

	public monsterHp mainScript;
	public GameStatus gameStatus;

	public GameObject[] backgroundList;

	public int backgroundNumber;
	//public float 

	// Use this for initialization
	void Start () {
		backgroundNumber = 0;	
	}

	// Metodo para crear el efecto "Ruleta" con los fondos
	void triggeringBackground (int num1) {
		for(int i = 0; i < backgroundList.Length; i++){
			if (i == num1) {	
				backgroundList [i].SetActive (true);
			} else {
				backgroundList [i].SetActive (false);
			}
		}// fin del ciclo for
	}

	//
	void passingVariablesToSave () {
		gameStatus.backgroundNumber = backgroundNumber;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (backgroundNumber);
		triggeringBackground (backgroundNumber);

		passingVariablesToSave ();
	}
}
