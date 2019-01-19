using UnityEngine;
using System.Collections;

public class bossFightAviable : MonoBehaviour {

	public monsterHp mainScript;

	// Use this for initialization
	void Start () {
	
	}

	// Metodo para entrar a la pelea con el boss
	public void bossFightOn () {
			mainScript.randomNumber = Random.Range (1,72);
			mainScript.stage++;
			mainScript.beforeBossTraining = false;
	}

	// Metodo para salir de la pelea con el boss
	public void bossFightOff () {
			mainScript.randomNumber = Random.Range (1,72);
			mainScript.stage--;
			mainScript.beforeBossTraining = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (mainScript.monsterDeathTimeActivation);	
	}
}
