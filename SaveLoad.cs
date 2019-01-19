using UnityEngine;
using System.Collections;

public class SaveLoad : MonoBehaviour {

	public GameStatus gameStatus;

	// Use this for initialization
	void Start () {
	
	}

	public void saveGame () {
		gameStatus.Save ();
	}

	public void loadGame () {
		gameStatus.Load ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
