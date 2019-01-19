using UnityEngine;
using System.Collections;

public class TabMenuAppear : MonoBehaviour {

	private TabMenuButtom TabMButtom;
	public Canvas tabMenuScreen;

	// Use this for initialization
	void Start () {
		TabMButtom = GameObject.Find("TabMenuButtonCode").GetComponent<TabMenuButtom> ();
		tabMenuScreen = tabMenuScreen.GetComponent<Canvas>();
	}

	// Update is called once per frame
	void Update () {
		if(TabMButtom.showTabMenu){
			tabMenuScreen.enabled = true;
		}
		if(!TabMButtom.showTabMenu){
			tabMenuScreen.enabled = false;
		}
	}
}