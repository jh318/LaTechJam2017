using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour {

	void OnCollisionExit2D(Collision2D c){
		gameObject.SetActive (false);
		//PlayerController.player.loseFollower();
		PlayerController.player.followerCount--;
	}
}
