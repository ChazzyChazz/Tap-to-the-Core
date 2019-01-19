using UnityEngine;
using System.Collections;

public class MagnetCoins : MonoBehaviour {

	// Variables
	public bool iman = false;
	GameObject attractedTo;
	public float strenghOfAttraction;
	public Monster monster;
	public monsterHp mainScript;
	//GameObject monedaInstancia;

	// Use this for initialization
	void Start () {
		strenghOfAttraction = 10f;
		Invoke ("activateMagnetEffect",4f);
		attractedTo = GameObject.Find ("moneda");
	}

	// Metodo para activar el efecto iman
	void activateMagnetEffect (){
		iman = true;
	} 

	// Metodo para el efecto iman
	void attractionToObject () {
		if(iman){
			Vector3 direction = attractedTo.transform.position - transform.position;
			direction.z = 0;
			GetComponent<Rigidbody2D> ().AddForce (strenghOfAttraction * direction);
		}
	}

	// Metodo para obtener la colission de los objetos
	void OnCollisionEnter2D (Collision2D col){
		if(col.gameObject.name == "moneda"){
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		attractionToObject ();
	}		
}