using UnityEngine;
using System.Collections;

public class StopSoundEffectsButton : MonoBehaviour {

	public GameStatus gameStatus;

	public bool turning;

	// Use this for initialization
	void Start () {
		//turning = true;	
	}

	//
	public void turningSoundEffectsOnOff () {
		if(turning){
			turning = false;
		}
		else if (!turning){
			turning = true;
		}
	}

	void passingVariablesToSave () {
		gameStatus.soundEffectsTurning = turning;
	}
	
	// Update is called once per frame
	void Update () {
		passingVariablesToSave ();	
	}
}
