using UnityEngine;
using System.Collections;

public class StopBgMusic : MonoBehaviour {

	public AudioSource bgMusic;
	private StopBgMusicButton stopBgMusicBtn;
	private bool playOnlyOnce = true;

	// Use this for initialization
	void Start () {
		stopBgMusicBtn = GameObject.Find("BgMusicButtonCode").GetComponent<StopBgMusicButton> ();
		bgMusic = bgMusic.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		if(stopBgMusicBtn.turning && playOnlyOnce){
			bgMusic.Play ();
			playOnlyOnce = false;
		}
		if(!stopBgMusicBtn.turning){	
			bgMusic.Stop ();
			playOnlyOnce = true;
		}	
	}
}
