using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject noah;
	public GameObject moses;
	public GameObject methusala;
	public GameObject abraham;
	public GameObject david;

	public bool noahAlive;
	public bool mosesAlive;
	public bool methusalaAlive;
	public bool abrahamAlive;
	public bool davidAlive;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	void Start () {
		
	}
	
	void Update () {
		if (!noah.gameObject.GetComponent<PlayerFollower> ().isActiveAndEnabled) {
			noahAlive = false;
		}
		if (!moses.gameObject.GetComponent<PlayerFollower> ().isActiveAndEnabled) {
			mosesAlive = false;
		}
		if (!methusala.gameObject.GetComponent<PlayerFollower> ().isActiveAndEnabled) {
			methusalaAlive = false;
		}
		if (!abraham.gameObject.GetComponent<PlayerFollower> ().isActiveAndEnabled) {
			abrahamAlive = false;
		}
		if (!david.gameObject.GetComponent<PlayerFollower> ().isActiveAndEnabled) {
			davidAlive = false;
		}
	}
}
