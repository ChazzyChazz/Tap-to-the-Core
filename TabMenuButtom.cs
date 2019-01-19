using UnityEngine;
using System.Collections;

public class TabMenuButtom : MonoBehaviour {

	public bool showTabMenu;

	public void buttonShowTabMenu () {
		if(!showTabMenu){
			showTabMenu = true;
		}
		else if(showTabMenu){
			showTabMenu = false;
		}
		//Debug.Log (showMenu);
	}
}