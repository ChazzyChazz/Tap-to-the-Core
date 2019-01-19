using UnityEngine;
using System.Collections;

public class StopSoundEffects : MonoBehaviour {

	private StopSoundEffectsButton stopSEButton;
	public SoundEffects soundEffects;
	private bool playOnlyOnce;

	// Use this for initialization
	void Start () {
		stopSEButton = GameObject.Find("SoundEffectsButtonCode").GetComponent<StopSoundEffectsButton> ();
		playOnlyOnce = true;
	}

	// Update is called once per frame
	void Update () {
		if(stopSEButton.turning && playOnlyOnce){
			soundEffects.stoppingEffects = false;// Play();
			playOnlyOnce = false;
		}
		if(!stopSEButton.turning){	
			soundEffects.stoppingEffects = true;// Stop();
			playOnlyOnce = true;
		}	
	}
}
