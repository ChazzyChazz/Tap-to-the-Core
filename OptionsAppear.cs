using UnityEngine;
using System.Collections;

public class OptionsAppear : MonoBehaviour {

	private OptionsButton optionsB;
	public Canvas optionScreen;

	// Use this for initialization
	void Start () {
		optionsB = GameObject.Find("OptionsButtonCode").GetComponent<OptionsButton> ();
		optionScreen = optionScreen.GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		if(optionsB.showMenu){
			optionScreen.enabled = true;
		}
		if(!optionsB.showMenu){
			optionScreen.enabled = false;
		}	
	}
}
