using UnityEngine;
using System.Collections;

public class TapHappen : MonoBehaviour {

	private TapButton tapButton;
	public monsterHp mainScript;

	// Use this for initialization
	void Start () {
		tapButton = GameObject.Find("TapButtonCode").GetComponent<TapButton> ();
		mainScript = mainScript.GetComponent<monsterHp>();
	}

	// Update is called once per frame
	void Update () {
		if(tapButton.makeTap){
			mainScript.playerTouch = true;
		}
		if(!tapButton.makeTap){
			mainScript.playerTouch = false;
		}
	}
}