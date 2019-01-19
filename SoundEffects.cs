using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour {

	public AudioSource[] soundEffects;
	public Slider soundEffectsSlider;
	public bool stoppingEffects = false;

	// Use this for initialization
	void Start () {
		
	}

	// Metodo para accionar el mute para los efectos de sonido
	public void muteEffects () {
		for (int i = 0; i < soundEffects.Length; i++){
			if (stoppingEffects) {
				soundEffects [i].mute = true;
			} else {
				soundEffects [i].mute = false;
			}
		}
	}

	// Metodo para poder bajar/subir el volumen de los efectos con el slider de efectos
	public void effectsVolume () {
		for (int i = 0; i < soundEffects.Length; i++){
			soundEffects [i].volume = soundEffectsSlider.value;
		}
	}
	
	// Update is called once per frame
	void Update () {
		effectsVolume ();
		muteEffects ();
	}
}
