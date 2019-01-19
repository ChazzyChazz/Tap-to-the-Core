using UnityEngine;
using System.Collections;

public class TapButton : MonoBehaviour {

	public bool makeTap = false;

	public void doingTap () {
			makeTap = true;
	}

	// Update is called once per frame
	void Update () {
		makeTap = false;
	}
}
