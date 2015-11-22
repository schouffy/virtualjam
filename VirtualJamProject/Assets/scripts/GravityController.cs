using UnityEngine;
using System.Collections;

public class GravityController : MonoBehaviour {
	public float moveSpeed = 6; // move speed
	public float turnSpeed = 90; // turning speed (degrees/second)
	public float lerpSpeed=10; // smoothing speed
	public float gravity =10; // gravity acceleration
	public bool isgrounded;
	public float deltaGround = 0.2f; // character is grounded up to this distance
	public LayerMask Track;

	
	private Vector3 surfaceNormal; // current surface normal
	private Vector3 myNormal; // character normal
	private float distGround; // distance from character position to ground
	private float vertSpeed = 0; // vertical jump current speed 
	private Rigidbody ImSoHard;
	private Collider Mycollider;


	void Start(){
		Mycollider =GetComponent<Collider>();
		ImSoHard =GetComponent<Rigidbody>();
		myNormal = transform.up; // normal starts as character up direction 
		ImSoHard.freezeRotation = true; // disable physics rotation
		// distance from transform.position to ground
		distGround = Mycollider.bounds.extents.y - Mycollider.bounds.center.y;  
	}
	
	void FixedUpdate(){
		// apply constant weight force according to character normal:
		ImSoHard.AddForce(-gravity*ImSoHard.mass*myNormal);
	}
	
	void Update(){
		// jump code - jump to wall or simple jump
		Ray ray;
	
		
		// movement code - turn left/right with Horizontal axis:
		transform.Rotate(0, Input.GetAxis("Horizontal")*turnSpeed*Time.deltaTime, 0);
		// update surface normal and isGrounded:

		RaycastHit hit;
		Debug.DrawRay(transform.position, -transform.up, Color.red, 15f);
		if (Physics.Raycast(transform.position, -transform.up, out hit, 15f, Track.value))
		{
			surfaceNormal = hit.normal;
			Debug.DrawRay(transform.position, surfaceNormal, Color.yellow, 15f);
		}else
		{
			//surfaceNormal = Vector3.up;
		}


		
		myNormal = Vector3.Lerp(myNormal, surfaceNormal, lerpSpeed*Time.deltaTime);
		// find forward direction with new myNormal:
		var myForward = Vector3.Cross(transform.right, myNormal);
		// align character to the new myNormal while keeping the forward direction:
		var targetRot = Quaternion.LookRotation(myForward, myNormal);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, lerpSpeed*Time.deltaTime);
		// move the character forth/back with Vertical axis:
		//transform.Translate(0, 0, Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime); 
		ImSoHard.AddForce(transform.TransformDirection( 0,0, Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime*150));
	}


}
