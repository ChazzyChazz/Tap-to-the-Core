using System;
using UnityEngine;
using System.Collections;

public class NumbersConverters : MonoBehaviour {

	// Metodo para conversion de numeros en "Tiempo"
	public string numbersTimeFormat (float num) {
		TimeSpan time = TimeSpan.FromSeconds (num);

		string str;

		if (num < 3600) {
			str = string.Format ("{0:00}:{1:00}",
				time.Minutes,
				time.Seconds);
		} else {
			str = string.Format ("{0:00}:{1:00}:{2:00}",
				time.Hours,
				time.Minutes,
				time.Seconds);
		}
		
		return str;
	}// numbersTimeFormat End

	// Metodo para conversion de numeros grandes
	public string numbersBigFormat (float num) {
		float numStr;
		string suffix;

		// Si num es menor de 1,000 muestra el valor tal cual
		if (num < 1000f) {//1,000
			//999
			numStr = num;
			suffix = "";
		} 
		// Si num es menor a 1,000,000 muestra por ejemplo 900,000 = 900K
		else if (num < 1000000f) {//1,000,000
			//999K = 999,999
			numStr = num / 1000f;// num/1K
			suffix = "K";
		} 
		// Si num es menor a 1,000,000,000 muestra por ejemplo 900,000,000 = 900m
		else if (num < 1000000000f) {//1,000,000,000
			//999M = 999,999,999
			numStr = num / 1000000f;// num/1M
			suffix = "M";
		} 
		// Si num es menor a 1,000,000,000,000 muestra por ejemplo 900,000,000,000 = 900B
		else if (num < 1000000000000f) {//1,000,000,000,000
			//999b = 999,999,999,999
			numStr = num / 1000000000f;// num/1B
			suffix = "B";
		} 
		// Si num es menor a 1,000,000,000,000,000 muestra por ejemplo 900,000,000,000,000 = 900T
		else if (num < 1000000000000000f) {//1,000,000,000,000,000
			//999t = 999,999,999,999,999
			numStr = num / 1000000000000f;// num/1T
			suffix = "T";
		} 
		// Si num es mayor a 1,000,000,000,000,000,000 muestra por ejemplo 900,000,000,000,000,000 = 900aa
		else if (num < 1000000000000000000f){
			//999aa = 999,999,999,999,999,999
			numStr = num / 1000000000000000f;// num/1aa
			suffix = "aa";
		}
		// Si num es mayor a 1,000,000,000,000,000,000,000 muestra por ejemplo 900,000,000,000,000,000,000 = 900ab
		else if (num < 1000000000000000000000f){
			//999ab = 999,999,999,999,999,999,999
			numStr = num / 1000000000000000000f;// num/1ab
			suffix = "ab";
		}
		// Si num es mayor a 1,000,000,000,000,000,000,000,000 muestra por ejemplo 900,000,000,000,000,000,000,000 = 900ac
		else if (num < 1000000000000000000000000f){
			//999ac = 999,999,999,999,999,999,999,999
			numStr = num / 1000000000000000000000f;// num/1ac
			suffix = "ac";
		}
		// Si num es mayor a 1,000,000,000,000,000,000,000,000,000 muestra por ejemplo 900,000,000,000,000,000,000,000,000 = 900ad
		else if (num < 1000000000000000000000000000f){
			//999ad = 999,999,999,999,999,999,999,999,999
			numStr = num / 1000000000000000000000000f;// num/1ad
			suffix = "ad";
		}
		// Si num es mayor a 1,000,000,000,000,000,000,000,000,000,000 muestra por ejemplo 900,000,000,000,000,000,000,000,000,000 = 900ae
		else{
			//999ae = 999,999,999,999,999,999,999,999,999,999
			numStr = num / 1000000000000000000000000000f;// num/1ad
			suffix = "ae";
		}

		if (num > 1000) {
			return numStr.ToString ("###.##") + suffix;
		} else {
			return numStr.ToString ("###") + suffix;
		}

	}// numberFormat End
}
