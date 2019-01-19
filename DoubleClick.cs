using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DoubleClick : MonoBehaviour, IPointerClickHandler {

	private int tap;
	private float interval = 1.5f;
	private bool readyForDoubleTap;

	public GameObject makeItMultiple;

	// Use this for initialization
	void Start () {
	
	}

	// Metodo evento para cada vez que se haga click en el boton
	public void OnPointerClick(PointerEventData eventData){
		tap++;
		//Debug.Log (tap);

		if(tap == 1){ // Si fue presionado 1 vez empieza la corutina
			// done

			StartCoroutine("DoubleTapInterval");
		}
		else if (tap > 1 && readyForDoubleTap) { // Si fue presionado mas de una vez y readyForDoublTap es verdadera
			makeItMultiple.SetActive(true);//Vuelveme el panel de botones x10/x100 On

			tap = 0;// Vuelve tap = 0
			readyForDoubleTap = false;// vuelve readyForDoubleTap = falso
		}

		if(!readyForDoubleTap){// Si readyForDoubleTap es falso vuelveme tap = 0
			tap = 0;
		}
	}

	// Corutina para que si no se hace doble click antes del intervalo de tiempo "interval"
	//mantenga readyForDoubleTap falso de lo contrario vuelve readyForDoubleTap verdadera
	IEnumerator DoubleTapInterval () {
		readyForDoubleTap = true;
		yield return new WaitForSeconds (interval);
		readyForDoubleTap = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (readyForDoubleTap);	
	}
}
