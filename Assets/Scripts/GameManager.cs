using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject noah;
	public GameObject moses;
	public GameObject methusala;
	public GameObject abraham;
	public GameObject david;

	public static bool noahAlive;
	public static bool mosesAlive;
	public static bool methusalaAlive;
	public static bool abrahamAlive;
	public static bool davidAlive;

	public int demonsKilled = 0;
	public float timer = 60.0f;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	void Start () {
		demonsKilled = 0;
		noahAlive = true;
		mosesAlive = true;
		methusalaAlive = true;
		abrahamAlive = true;
		davidAlive = true;
	}
	
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			SceneManager.LoadScene ("EndGameMenu");
		}
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
