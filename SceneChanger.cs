using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// This Script is just to change the Scenes across the game
public class SceneChanger : MonoBehaviour {

	#region Variables

	//Variables

	[SerializeField] private string sceneName;

	#endregion Variables

	#region Methods

	//Methods

	// Use this for initialization
	void Start () {
		
		// Scene 01
		if(SceneManager.GetSceneByName("CompanyNameScene").isLoaded){
			
			Invoke ("changeScene", 4.0f);

		}

	}

	public void changeScene () {
		
		//SceneManager.LoadScene (sceneName);
		SceneLoader.instance.LoadSpecificScene(sceneName);

	}

	#endregion Methods
}