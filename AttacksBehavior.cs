using UnityEngine;
using System.Collections;

public class AttacksBehavior : MonoBehaviour {

	// Variables publicas
	public float destroyTime = 5.0f;
	public float forceInX = -1.0f;
	public float forceInY = 0.0f;

	//
	public bool isRoboJake = false;
	public bool isBob = false;
	public bool isDogBot = false;
	public bool isDron = false;
	public bool isLitus = false;
	public bool isSharot = false;
	public bool isMateo = false;
	public bool isBik = false;
	public bool isLaser = false;

	// Use this for initialization
	void Start () {
		//Invoke ("destroyer", destroyTime);
	}

	//
	void destroyer () {
		Destroy (gameObject);
	}

	// Metodo para establecer el movimiento del objeto
	void attackMovement () {
		var objVelocity = this.GetComponent<Rigidbody2D> ().velocity;
		objVelocity.x = forceInX;
		objVelocity.y = forceInY;//AddForce(new Vector2(forceInX,forceInY));
		this.GetComponent<Rigidbody2D> ().velocity = objVelocity;
	}

	// Metodo para detectar la colision del objeto
	void OnTriggerEnter2D (Collider2D col) {
		if(col.gameObject.name == "MonstersColider"){
			Monster monster;
			monster = GameObject.Find ("MonstersList").GetComponent<Monster> ();//monster.GetComponent<Monster> ();

			//
			if(isRoboJake){		
				RoboJake roboJake;
				roboJake = GameObject.Find ("Robo-Jake").GetComponent<RoboJake> ();//roboJake.GetComponent<RoboJake>();
				monster.hp -= roboJake.atk;
			}
			//
			if(isBob){
				Bob bob;
				bob = GameObject.Find ("Bob").GetComponent<Bob> ();
				monster.hp -= bob.atk;
			}
			//
			if(isDogBot){
				DogBotBobby dogBot;
				dogBot = GameObject.Find ("DogBot-Bobby").GetComponent<DogBotBobby> ();
				monster.hp -= dogBot.atk;
			}
			//
			if(isDron){
				Dron dron;
				dron = GameObject.Find ("DronAK-1400").GetComponent<Dron> ();
				monster.hp -= dron.atk;
			}
			//
			if(isLitus){
				Litus litus;
				litus = GameObject.Find ("Litus").GetComponent<Litus> ();
				monster.hp -= litus.atk;
			}
			//
			if(isSharot){
				Sharot sharot;
				sharot = GameObject.Find ("Sharot").GetComponent<Sharot> ();
				monster.hp -= sharot.atk;
			}
			//
			if(isMateo){
				Mateo mateo;
				mateo = GameObject.Find ("Mateo Rodriguez").GetComponent<Mateo> ();
				monster.hp -= mateo.atk;
			}
			//
			if(isBik){
				Bik bik;
				bik = GameObject.Find ("BikKlubber the Merc.").GetComponent<Bik> ();
				monster.hp -= bik.atk;
			}
			//
			if(isLaser){
				Laser laser;
				laser = GameObject.Find ("Laser Automata").GetComponent<Laser> ();
				monster.hp -= laser.atk;
			}
		    Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		attackMovement ();
	}
}
