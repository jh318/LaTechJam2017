using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public float speed = 3;
	public float lookAhead = 1;
	public float score;

	Rigidbody2D _body;
	public Rigidbody2D body{
		get{
			if (_body == null) {
				_body = GetComponent<Rigidbody2D> ();
			}
			return _body; 
		}
	}

	void Start(){
		//score = Random.Range(1.0f, 10.0f);
	}

	void Update () {
		Vector2 target = (Vector2)PlayerController.player.transform.position + PlayerController.player.body.velocity * lookAhead;
		Vector2 heading = (target - (Vector2)transform.position).normalized;
		body.velocity = heading * speed;

		if (body.velocity.sqrMagnitude > 0.1f) {
			transform.right = body.velocity;
		}
	}
}