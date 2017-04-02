using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour {


	void OnTriggerExit2D(Collider2D c){
		Debug.Log ("Object left");
		if (c.gameObject.GetComponent<PlayerFollower> ()) {
			c.gameObject.SetActive (false);
			AudioManager.PlayVariedEffect ("WilhelmScream");
		}
	}
}
