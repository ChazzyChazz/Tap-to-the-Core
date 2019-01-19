using UnityEngine;
using System.Collections;

public class BackButtonActions : MonoBehaviour {

	public GameObject quitPanel;

	// Use this for initialization
	void Start () {
		quitPanel.SetActive (false);	
	}

	// Metodo para volver el panel activo
	public void activatePanel () {
		quitPanel.SetActive (true);
	}

	// Metodo para volver el panel inactivo
	public void desactivatePanel () {
		quitPanel.SetActive (false);
	}

	// Metodo para cerrar la aplicacion
	public void closeApplication () {
		Application.Quit ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			activatePanel ();
		}	
	}
}
