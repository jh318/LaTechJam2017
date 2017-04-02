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
		if (c.gameObject.GetComponent<EnemyController> ()) {
			c.gameObject.SetActive (false);
			AudioManager.PlayEffect (AudioManager.instance.clips [Random.Range (3, 18)]);
			GameManager.instance.demonsKilled++;
		}
	}
}
