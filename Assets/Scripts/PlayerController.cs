using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController player;

	Rigidbody2D _body;
	public Rigidbody2D body {
		get{ 
			if (_body == null) {
				_body = GetComponent<Rigidbody2D> ();
			}
			return _body;
		}
	}





	public float speed;
	public Transform visibleBody;
	public string xAxis = "Horizontal";
	public string yAxis = "Vertical";
	public float rotationSpeed = 3;
	public int holyForce = 10;
	public float sprayDistanceMax = 10;
	public float sprayDistanceMin = 3;
	public float holySprayTime = 10;
	public ParticleSystem waterSpray;

	private ParticleSystem waterSprayInstance;

	private float holySprayDistance;
	private float holySprayChange = 10;
	private bool m_isAxisInUse = false;
	float aimHorizontal;
	float aimVertical;

	private SpriteRenderer playerSprite; 
	//private Rigidbody2D body;

	void Awake(){
		if (player == null) {
			player = this;
		}
	}


	void Start()
	{
		playerSprite = GetComponentInChildren<SpriteRenderer>();
		//body = GetComponent<Rigidbody2D>();
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		StartCoroutine("ReduceSprayDistance");
		holySprayDistance = (sprayDistanceMax - sprayDistanceMin) / holySprayTime;
		holySprayChange = sprayDistanceMax;

	}



	void Update(){
		float moveHorizontal = Input.GetAxis(xAxis);
		float moveVert = Input.GetAxis(yAxis);
		body.velocity = new Vector3 (moveHorizontal, moveVert, 0) * speed;
		waterSpray.startLifetime = holySprayChange;

		aimHorizontal = Input.GetAxis ("RightStickX");
		aimVertical = Input.GetAxis ("RightStickY");

		if (aimHorizontal < 0) {
			transform.Rotate (Vector3.forward * rotationSpeed);
		}
		if (aimHorizontal > 0) {
			transform.Rotate (Vector3.forward * -rotationSpeed);
		}
			
	
		//transform.right = new Vector2 (aimHorizontal, aimVertical);



			//Check for Inputs
		if( Input.GetAxisRaw("RightTrigger") > 0)
		{
			if(m_isAxisInUse == false)
			{
				Debug.Log ("RT " +Input.GetAxisRaw ("RightTrigger"));
				m_isAxisInUse = true;
			}
		}
		if ( Input.GetAxisRaw("RightTrigger") == 0)
		{
			Debug.Log("Trigger Reset" + Input.GetAxisRaw("RightTrigger"));
			m_isAxisInUse = false;
			waterSpray.Stop ();
		}  
		if (Input.GetKeyDown(KeyCode.JoystickButton1) && holySprayChange <= sprayDistanceMax) 
		{
			Debug.Log ("B Pressed");
			holySprayChange += 1.0f;
		}

		Debug.Log ("RT " +Input.GetAxisRaw ("RightTrigger"));
	}


	void FixedUpdate()
	{
		if (Input.GetAxisRaw ("RightTrigger") > 0) {
			sprayWater ();
			waterSpray.Play ();
		}
			
	}

	IEnumerator ReduceSprayDistance(){
		while (isActiveAndEnabled) 
		{
			if(Input.GetAxisRaw("RightTrigger") > 0 && holySprayChange >= sprayDistanceMin)
			{
			holySprayChange -=  holySprayDistance;
			//Debug.Log (holySprayChange);
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	void sprayWater(){
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
