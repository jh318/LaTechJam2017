using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float speed;
	public Transform visibleBody;
	public string xAxis = "Horizontal";
	public string yAxis = "Vertical";

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

	}
}
