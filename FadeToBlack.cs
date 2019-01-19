using UnityEngine;
using System.Collections;

public class FadeToBlack : MonoBehaviour {

	public MonstersBehavior monstersSprites;
	public monsterHp mainScript;

	// Use this for initialization
	void Start () {
	
	}

	IEnumerator fadeToBlack () {
		for(float f = 1f; f >= 0f; f -= 1f){
			Color c = monstersSprites.monstersList[monstersSprites.monsterId].GetComponent<Renderer>().material.color;
			c.r = f;
			c.g = f;
			c.b = f;
			monstersSprites.monstersList[monstersSprites.monsterId].GetComponent<Renderer>().material.color = c;
			yield return null;
		}
	}

	void backToNormal () {
		Color c = monstersSprites.monstersList[monstersSprites.monsterId].GetComponent<Renderer>().material.color;
		c.r = 1;
		c.g = 1;
		c.b = 1;
		monstersSprites.monstersList[monstersSprites.monsterId].GetComponent<Renderer>().material.color = c;
	}
	
	// Update is called once per frame
	void Update () {
		if (mainScript.monsterDeathTimeActivation) {
			StartCoroutine ("fadeToBlack");
		} else {
			backToNormal ();
			//StartCoroutine("backToNormal");
		}	
	}
}
