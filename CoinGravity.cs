using UnityEngine;
using System.Collections;

public class CoinGravity : MonoBehaviour {

	private float randomNumber,
	              randomNumber1,
	              randomNumber2,
	              forceNumber;

	// Use this for initialization
	void Start () {
		randomForce();

		Invoke ("addingGravityForce",0.8f);
		Invoke ("stoppingVelocity",3.5f);
	}

	// Metodo para generar la fuerza del viento de forma random
	public void randomForce (){
		randomNumber = Random.Range(1,10);
		randomNumber1 = Random.Range(-15,-50);
		randomNumber2 = Random.Range(15,50);

		if (randomNumber > 5) {
			forceNumber = randomNumber1;
		}
		if(randomNumber <= 5) {
			forceNumber = randomNumber2;
		}
		//Debug.Log (forceNumber+" Force");
		//Debug.Log (randomNumber+" Rnumber");
	}

	// Metodo para anadir fuerza de viento
	void addingWindForce (){
		GetComponent<Rigidbody2D> ().AddForce (new Vector2(forceNumber,0));
	}

	// Metodo para anadir fuerza de gravedad
	void addingGravityForce (){
		GetComponent<Rigidbody2D> ().gravityScale = 25;
	}

	// Metodo para detener la velocidad
	void stoppingVelocity (){
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		GetComponent<Rigidbody2D> ().angularVelocity = 0f;
	}

	// Metodo para ignorar colision de objetos de la misma capa de colision
	void ignoringCollisionOfSameLayer () {
		Physics2D.IgnoreLayerCollision (9,9);
	}
	
	// Update is called once per frame
	void Update () {
		addingWindForce ();
		ignoringCollisionOfSameLayer ();
	}
}
