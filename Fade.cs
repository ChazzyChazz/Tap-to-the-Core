using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	//public monsterHp scriptPrincipal;

	//private float valorNum = 0f;

	// Use this for initialization
	void Start () {
	
	}

	IEnumerator fadeObject () {
		for(float f = 1f; f >= 0; f -= 0.1f){
			Color c = GetComponent<Renderer>().material.color;
			c.a = f;
			GetComponent<Renderer>().material.color = c;
			yield return null;
		}
	}

	/*IEnumerator fadeInObject () {
		for(float f = 1f; f >= 0; f += 1f){
			Color c = GetComponent<Renderer>().material.color;
			c.a = f;
			GetComponent<Renderer>().material.color = c;
			yield return null;
		}
	}*/

	// Update is called once per frame
	void Update () {
		/*if(scriptPrincipal.GetComponent<monsterHp>().monsterFadeIn == true){
		   StartCoroutine ("fadeObject");
		}*/

		/*if(scriptPrincipal.GetComponent<monsterHp>().monsterFadeOut == true){
			valorNum += Time.deltaTime;
			//Debug.Log (valorNum);
			if(valorNum >= 0.50f){
		        StartCoroutine ("fadeInObject");
				valorNum = 0f;
				//Debug.Log (valorNum);
				scriptPrincipal.GetComponent<monsterHp> ().monsterFadeOut = false;
			}
		}*/
	
	}
}
