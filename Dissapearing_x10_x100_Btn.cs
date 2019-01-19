using UnityEngine;
using System.Collections;

public class Dissapearing_x10_x100_Btn : MonoBehaviour {

	private float timer = 0;

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);	
	}

	//
	void makeThisDissapear () {
		if(this.gameObject.activeInHierarchy){
			timer += Time.deltaTime;
			if(timer > 5){
				this.gameObject.SetActive (false);
				timer = 0;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		makeThisDissapear ();		
	}
}
