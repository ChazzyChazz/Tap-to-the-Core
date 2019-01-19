using UnityEngine;
using System.Collections;

public class OptionsButton : MonoBehaviour {

	public bool showMenu;
	public AudioSource openMenu;
	public AudioSource closeMenu;

	// Use this for initialization
	void start () {
		openMenu = openMenu.GetComponent<AudioSource> ();
		closeMenu = closeMenu.GetComponent<AudioSource> ();
	}

	public void buttonShowMenu () {
		if(!showMenu){
			showMenu = true;
			openMenu.Play ();
		}
		else if(showMenu){
			showMenu = false;
			closeMenu.Play ();
		}
		//Debug.Log (showMenu);
	}
}
