using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoaderDeuce : MonoBehaviour {

	public string catchButton = "Catch";


	void Update(){

		if (Input.GetButtonDown(catchButton))
		{
			SceneManager.LoadScene ("MasterScene");
		}
	}
}