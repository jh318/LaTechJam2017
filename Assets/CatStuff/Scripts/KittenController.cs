using UnityEngine;
using System.Collections;

public class KittenController : MonoBehaviour {

	public float speed;

	private Rigidbody2D body;
	private Vector3 randomDirection;
	public Sprite[] catSprites;

	void Awake(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = catSprites[Random.Range (0, 9)];
	}

	void Start(){
		body = GetComponent<Rigidbody2D> ();
		//randomDirection = RandomDirectionNumberGenerator();
		StartCoroutine ("ChangeDirection");
	}

	void FixedUpdate(){
		body.velocity = randomDirection * speed;
		if (body.velocity.x == 0 && body.velocity.y == 0) {
			randomDirection = RandomDirectionNumberGenerator();
		}
	}
		
	Vector3 RandomDirectionNumberGenerator(){
		int x = Random.Range (-1, 2);
		int y = Random.Range(-1,2);
		int z = 0;
		while (x == 0 && y == 0) { // Generate new values if x  and y are 0
			x = Random.Range (-1, 2);
			y = Random.Range(-1,2);
		}
		Vector3 randomDirection = new Vector3((float)x, (float)y, (float)z);
		//Debug.Log (randomDirection);
		return randomDirection;
	}

	/**void OnCollisionEnter2D(Collision2D collision){
		randomDirection = RandomDirectionNumberGenerator();
	}*/

	IEnumerator ChangeDirection () {
		while (enabled) {
			yield return new WaitForSeconds (2);
			randomDirection = RandomDirectionNumberGenerator();

		}
	}
}