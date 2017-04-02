using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour {


	void OnTriggerExit2D(Collider2D c){
		Debug.Log ("Object left");
		if (c.gameObject.GetComponent<PlayerFollower> ()) {
			c.gameObject.SetActive (false);
			//PlayerController.player.loseFollower();
			AudioManager.PlayVariedEffect ("WilhelmScream");
			PlayerController.player.followerCount--;

		}
	}
}
