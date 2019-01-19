using UnityEngine;
using System.Collections;

public class FadeByY : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("destroyer",0.60f);
		StartCoroutine ("fadeObject");	
	}

	// Metodo para destruir el texto
	void destroyer () {
		Destroy (gameObject);
	}

	// Metodo para agregarle movimiento al texto
	void textMovement () {
		this.GetComponent<Rigidbody2D> ().AddForce(new Vector2(0,75));
	}

	// Metodo para "desvanecer el objeto"
	IEnumerator fadeObject () {
		yield return new WaitForSeconds(0.40f);

		for(float f = 1f; f >= 0; f -= 0.1f){
			Color c = GetComponent<Renderer>().material.color;
			c.a = f;
			GetComponent<Renderer>().material.color = c;

			yield return null;
		}
	}

	// Update is called once per frame
	void Update () {
		textMovement ();
	}
}
