using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUIController : MonoBehaviour {


	public Text followersAliveListText;
	public Text followerAlive1;
	public Text followerAlive2;
	public Text followerAlive3;
	public Text followerAlive4;
	public Text followerAlive5;

	public Text followersDeadListText;
	public Text followerDead1;
	public Text followerDead2;
	public Text followerDead3;
	public Text followerDead4;
	public Text followerDead5;



	// Use this for initialization
	void Start () {
		followerAlive1.text = "Noah";
		followerAlive2.text = "Moses";
		followerAlive3.text = "Methusala";
		followerAlive4.text = "Abraham";
		followerAlive5.text = "David";

	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.noahAlive == false) {
			followerDead1.text = "Noah";
		}
		if (GameManager.instance.mosesAlive == false) {
			followerDead2.text = "Moses";
		}
		if (GameManager.instance.methusalaAlive == false) {
			followerDead3.text = "Methusala";
		}
		if (GameManager.instance.abrahamAlive == false) {
			followerDead4.text = "Abraham";
		}
		if (GameManager.instance.davidAlive == false) {
			followerDead5.text = "David";
		}
	}
}
