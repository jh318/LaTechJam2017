using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject prefab;
	public bool spawnEnabled = true;
	public float radius = 3;
	public float spawnTime = 3;

	void Start(){
		StartCoroutine ("SpawnTimer");
	}

	IEnumerator SpawnTimer(){
		while (spawnEnabled) {
			Vector3 spawnPosition = transform.position + (Vector3)Random.insideUnitCircle * radius;
			Instantiate (prefab, spawnPosition, Quaternion.identity);
			if (prefab.GetComponent<KittenController> () == true) {
				Debug.LogWarning ("Cat spawned");
				GameManager.instance.catCount++;
			}
			yield return new WaitForSeconds (spawnTime);
		}
	}

	void OnDrawGizmos () {
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
