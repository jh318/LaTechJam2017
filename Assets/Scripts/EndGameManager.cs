using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.noahAlive == false) {
			gameObject.GetComponent<MainGameUIController> ().followerAlive1.gameObject.SetActive (false);
		}
	}
}
