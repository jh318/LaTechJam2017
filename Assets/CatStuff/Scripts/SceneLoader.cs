using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour {

	public string sceneToLoad;	


	void Update(){
		if (Input.GetButtonDown ("Jump") || Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.JoystickButton7)) {
			LoadScene (sceneToLoad);
		}
	}


	public void LoadScene(string scene){
		SceneManager.LoadScene (scene);
	}
}
