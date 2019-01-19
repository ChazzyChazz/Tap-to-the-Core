using UnityEngine;
using System.Collections;

public class StopBgMusicButton : MonoBehaviour {

	public GameStatus gameStatus;

	public bool turning;

	// Use this for initialization
	void Start () {
		//turning = true;
	}

	//
	public void turningMusicOnOff () {
		if(turning){
			turning = false;
		}
		else if (!turning){
			turning = true;
		}
	}

	//
	void passingVariablesToSave () {
		gameStatus.BgMusicTurning = turning;
	}
	
	// Update is called once per frame
	void Update () {
		passingVariablesToSave ();	
	}
}
