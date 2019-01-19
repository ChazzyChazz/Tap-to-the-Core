using UnityEngine;
using System.Collections;

public class tapAnimation : MonoBehaviour {

	public float disappearTime = 0.33f;

	// Use this for initialization
	void Start () {
		sameUbicationAsPointer ();
		playTapAnimation ();
		Invoke ("destroyer",disappearTime);
	}

	// Metodo para "aparecer" la animacion de tap
	void playTapAnimation () {
		var thisPoss = this.gameObject.transform.position;
		thisPoss.z = 3;
		this.gameObject.transform.position = thisPoss;
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
	}

	// Metodo para "desaparecer" la animacion de tap
	/*void stopTapAnimation () {
		var thisPoss = this.gameObject.transform.position;
		thisPoss.z = -2;
		this.gameObject.transform.position = thisPoss;
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}*/

	// Metodo para ubicar este gameObject en la misma posicion que el puntero
	public void sameUbicationAsPointer () {
		var mausePoss = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		var aniPoss = this.transform.position;
		aniPoss.x = mausePoss.x;
		aniPoss.y = mausePoss.y;
		this.transform.position = aniPoss;
		//Debug.Log ("x-"+aniPoss.x+" "+"y-"+aniPoss.y);
	}

	//
	void destroyer () {
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
