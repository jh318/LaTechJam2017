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
	public float holySprayTime = 10;
	public ParticleSystem waterSpray;

	private ParticleSystem waterSprayInstance;

	private float holySprayDistance;
	private float holySprayChange;

	private SpriteRenderer playerSprite; 
	private Rigidbody2D body;
	private bool m_isAxisInUse = false;
	private ParticleSystem ps;
	public bool enabled;



	private void Start()
	{
		playerSprite = GetComponentInChildren<SpriteRenderer>();
		body = GetComponent<Rigidbody2D>();
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		//StartCoroutine("ReduceSprayDistance");
		ps = GetComponent<ParticleSystem>();

	}



	void Update(){
		float moveHorizontal = Input.GetAxis(xAxis);
		float moveVert = Input.GetAxis(yAxis);
		body.velocity = new Vector3 (moveHorizontal, moveVert, 0) * speed;
		waterSpray.startLifetime = sprayDistanceMax;


		float aimHorizontal = Input.GetAxis ("RightStickX");
		float aimVertical = Input.GetAxis ("RightStickY");
		transform.right = new Vector2 (aimHorizontal, aimVertical);
		//Debug.Log ("x" + aimHorizontal);
		//Debug.Log ("y" + aimVertical);

		//if(Input.GetAxisRaw ("RightTrigger")!= 0){
			//Debug.Log ("Right Trigger pressed");

			if( Input.GetAxisRaw("RightTrigger") > 0)
			{
				if(m_isAxisInUse == false)
				{
					Debug.Log ("RT " +Input.GetAxisRaw ("RightTrigger"));
					Debug.Log ("Right Trigger pressed");

					/*waterSprayInstance = waterSpray;
					Instantiate (
					waterSprayInstance, 
					gameObject.GetComponentInChildren<HeadingController> ().transform.position, 
					Quaternion.identity
					);*/
					//waterSprayInstance.Play ();

					m_isAxisInUse = true;
				}
			}
			if ( Input.GetAxisRaw("RightTrigger") == 0)
			{
				Debug.Log("Trigger Reset" + Input.GetAxisRaw("RightTrigger"));
				//waterSprayInstance.Stop();
				//var emission = ps.emission;
			//emission.enabled = !(enabled);
				m_isAxisInUse = false;
			waterSpray.Stop ();

			}  
		Debug.Log ("RT " +Input.GetAxisRaw ("RightTrigger"));

	}


	void FixedUpdate(){
		if (Input.GetAxisRaw ("RightTrigger") > 0) {
			sprayWater ();
			waterSpray.Play ();
			//waterSprayInstance.Play ();
			//var emission = ps.emission;
			//emission.enabled = enabled;
		}
			
	}

	IEnumerator ReduceSprayDistance(){
		holySprayDistance = (sprayDistanceMax - sprayDistanceMin) / holySprayTime;
		holySprayChange = sprayDistanceMax;
		for (float i = 0; i < holySprayTime && holySprayChange >= sprayDistanceMin; i += Time.deltaTime) {
			holySprayChange -=  holySprayDistance;
			//Debug.Log (holySprayChange);
			yield return new WaitForSeconds(1);
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
