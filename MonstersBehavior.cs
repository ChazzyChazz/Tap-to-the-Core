using UnityEngine;
using System.Collections;

public class MonstersBehavior : MonoBehaviour {

	public monsterHp mainScript;

	public GameObject[] monstersList;

	public string[] monstersName;

	public int monsterId = 0;

	// Use this for initialization
	void Start () {
	
	}

	// Metodo para seleccionar el monstruo a mostrar de forma eficaz
	void triggeringMonster (int num1, int num2, int num3) {
		for(int i = 0; i < monstersList.Length; i++){
			for (int j = 0; j < monstersName.Length; j++) {
				if (mainScript.randomNumber <= num2 && mainScript.randomNumber >= num1) {
					monstersList [num3].SetActive (true);
					//monstersList[num3].GetComponent<SpriteRenderer>().enabled = true;
					monsterId = num2 / 3;// para saber el monstruo ya que el random es 3 numeros para cada monstruo
					mainScript.actualizarMonstersName (monstersName[num3]);
				} else {
					monstersList [num3].SetActive (false);
					//monstersList[num3].GetComponent<SpriteRenderer>().enabled = false;
				}
			}
		}// fin del ciclo for
	}

	// metodo para activar al monstruo ejemplo si el numero random es entre 4-6 saldra el monstruo 2...
	void activatingMonsters () {
		triggeringMonster (1,3,1);// monstruo 01
		triggeringMonster (4,6,2);// monstruo 02
		triggeringMonster (7,9,3);// monstruo 03
		triggeringMonster (10,12,4);// monstruo 04
		triggeringMonster (13,15,5);// monstruo 05
		triggeringMonster (16,18,6);// monstruo 06
		triggeringMonster (19,21,7);// monstruo 07
		triggeringMonster (22,24,8);// monstruo 08
		triggeringMonster (25,27,9);// monstruo 09
		triggeringMonster (28,30,10);// monstruo 10
		triggeringMonster (31,33,11);// monstruo 11
		triggeringMonster (34,36,12);// monstruo 12
		triggeringMonster (37,39,13);// monstruo 13
		triggeringMonster (40,42,14);// monstruo 14
		triggeringMonster (43,45,15);// monstruo 15
		triggeringMonster (46,48,16);// monstruo 16
		triggeringMonster (49,51,17);// monstruo 17
		triggeringMonster (52,54,18);// monstruo 18
		triggeringMonster (55,57,19);// monstruo 19
		triggeringMonster (58,60,20);// monstruo 20
		triggeringMonster (61,63,21);// monstruo 21
		triggeringMonster (64,66,22);// monstruo 22
		triggeringMonster (67,69,23);// monstruo 23
		triggeringMonster (70,72,24);// monstruo 24
	}
	
	// Update is called once per frame
	void Update () {
		activatingMonsters ();	
	}
}
