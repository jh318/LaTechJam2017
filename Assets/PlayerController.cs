using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float speed;
	public Transform visibleBody;
	public string xAxis = "Horizontal";
	public string yAxis = "Vertical";
	public int holyForce = 10;
	public float sprayDistanceMax = 10;
	public float sprayDistanceMin = 3;


	private SpriteRenderer playerSprite; 
	private Rigidbody2D body;


	private void Start()
	{
		playerSprite = GetComponentInChildren<SpriteRenderer>();
		body = GetComponent<Rigidbody2D>();
	}



	void Update(){
		float moveHorizontal = Input.GetAxis(xAxis);
		float moveVert = Input.GetAxis(yAxis);
		body.velocity = new Vector3 (moveHorizontal, moveVert, 0) * speed;

		float aimHorizontal = Input.GetAxis ("RightStickX");
		float aimVertical = Input.GetAxis ("RightStickY");
		transform.right = new Vector2 (aimHorizontal, aimVertical);
		//Debug.Log ("x" + aimHorizontal);
		//Debug.Log ("y" + aimVertical);
	}

	void FixedUpdate(){
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		RaycastHit2D hit = Physics2D.Raycast (
			gameObject.GetComponentInChildren<HeadingController>().transform.position, 
			transform.right,
			sprayDistanceMax
		);
		if (hit.collider != null) {
			Debug.Log ("hit");
			hit.rigidbody.AddForce (transform.right * holyForce);
		}
	}
}
