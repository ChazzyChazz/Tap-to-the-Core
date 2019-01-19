using UnityEngine;
using System.Collections;

public class Blinker : MonoBehaviour {

	public GameObject[] objectsToBlink;

	private int objectId;

	// Use this for initialization
	void Start () {
		objectId = 0;	
	}

	void gettingObjectId () {
		for(int i = 0; i < objectsToBlink.Length; i++){
			objectId = i;
		}
	}

	// Metodo para hacer "parpadear"
	IEnumerator blinkActivation () {
		for (int i = 20; i >= 0; i--) {

			if (i % 2 == 0) {
				objectsToBlink [objectId].SetActive (true);
			} else {
				objectsToBlink [objectId].SetActive (false);
			}
			yield return new WaitForSeconds(0.1f);
		}
	}

	public void activatingBlink () {
		StartCoroutine ("blinkActivation");
	}
	
	// Update is called once per frame
	void Update () {
		gettingObjectId ();	
	}
}
