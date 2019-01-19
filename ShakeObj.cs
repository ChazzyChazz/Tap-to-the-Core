using UnityEngine;
using System.Collections;

public class ShakeObj : MonoBehaviour {
	
	public bool trigger = false;
	public MonstersBehavior monstersSprites;

	// Use this for initialization
	void Start () {
		monstersSprites = monstersSprites.GetComponent<MonstersBehavior> ();
	}

	// Metodo para hacer "parpadear" a los monstruos al ser danados
	IEnumerator blinkActivation () {
		if (trigger == true) {
			for (int i = 4; i >= 0; i--) {
				
				if (i % 2 == 0) {
					monstersSprites.monstersList[monstersSprites.monsterId].GetComponent<SpriteRenderer> ().enabled = true;
				} else {
					monstersSprites.monstersList[monstersSprites.monsterId].GetComponent<SpriteRenderer> ().enabled = false;
				}
				yield return null;
			}
		}
	}

	void makingTriggerTrue(){
		trigger = true;
	}

	void makingTriggerFalse(){
		trigger = false;
	}
	
	// Update is called once per frame
	void Update () {


		StartCoroutine ("blinkActivation");
		//makingTriggerTrue ();
		makingTriggerFalse();
	}
}
