using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


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
	public float sprayDegredationRate = 0.5f;
	public float pumpRate = 1.0f;
	public GameObject[] followersList;

	private ParticleSystem waterSprayInstance;

	private float holySprayDistance;
	private float holySprayChange = 10;
	private bool m_isAxisInUse = false;
	float aimHorizontal;
	float aimVertical;
	public int followerCount;

	private SpriteRenderer playerSprite; 
	//private Rigidbody2D body;

	void Awake(){
		if (player == null) {
			player = this;
		}
		followerCount = followersList.Length;

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
				AudioManager.PlayVariedEffect ("spray1SFX");
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
			holySprayChange += pumpRate;
			AudioManager.PlayVariedEffect ("pump1SFX");
		}

		Debug.Log ("RT " +Input.GetAxisRaw ("RightTrigger"));

		if (followerCount <= 0) {
			SceneManager.LoadScene ("EndGameMenu");
		}

	}


	void FixedUpdate()
	{
		if (Input.GetAxisRaw ("RightTrigger") > 0) {
			sprayWater ();
			waterSpray.Play ();
		}
			
	}

	void OnCollisionExit2D(Collision2D c){
		if (c.gameObject.GetComponent<EnemyController> ()) {
			loseFollower ();
			AudioManager.PlayVariedEffect ("WilhelmScream");
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
			yield return new WaitForSeconds(sprayDegredationRate);
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

	public void loseFollower(){
			for (int i = 0; i < followersList.Length; i++) {
				if (followersList [i].gameObject.GetComponent<PlayerFollower> () && followersList [i].gameObject.GetComponent<PlayerFollower> ().isActiveAndEnabled) {
					followersList [i].gameObject.SetActive (false);
					Debug.Log ("lost follower");
					followerCount--;
					break;
				}
				if (followerCount <= 0) {
					Debug.Log ("nobody left");
					if (followerCount <= 0) {
						StartCoroutine ("LostAllFollowers");
					}
				}
			}
		}

	IEnumerator LostAllFollowers(){
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene ("EndGameMenu");

	}

}