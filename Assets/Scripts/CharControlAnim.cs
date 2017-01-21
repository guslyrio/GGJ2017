using UnityEngine;

using System.Collections;
[RequireComponent (typeof (Animator))]

public class CharControlAnim : MonoBehaviour {
	
	private Transform myTransform;              // this transform
	private Vector3 destinationPosition;        // The destination Point
	private float destinationDistance;          // The distance between myTransform and destinationPosition
	public float Speed;                         // Speed at which the character moves
	public float Direction;                    // The Speed the character will move
	public float moveAnimSpeed;                // Float trigger for Float created in Mecanim (Use this to trigger transitions.
	public bool fishing;                	   // Bool trigger for bool created in Mecanim (Use this to trigger transitions.
	public float animSpeed = 1.5f;            // Animation Speed
	public Animator anim;                     // Animator to Anim converter
	public int idleState = Animator.StringToHash("Base Layer.Idle"); // String to Hash conversion for Mecanim "Base Layer"
	public int runState = Animator.StringToHash("Base Layer.Run");  // String to Hash for Mecanim "Base Layer Run"
	public int diggingState = Animator.StringToHash("Base Layer.Digging");
	private AnimatorStateInfo currentBaseState;         // a reference to the current state of the animator, used for base layer
	private Collider col;
	public GameObject shovel;
	public GameObject sandParticles;
	public GameObject chest;
	public GameObject rod;
	public GameObject Splash;
	public Transform leftHand;
	public Transform rightHand;
	public Transform water;
	public GameObject Xspot;

	private float chestDig = 1.0f;

	void Start () {
		Physics.gravity = new Vector3(0,-200f,0); // used In conjunction with RigidBody for better Gravity (Freeze Rotation X,Y,Z), set mass and use Gravity)
		anim = GetComponent<Animator>();
		idleState = Animator.StringToHash("Idle"); // Duplicate added due to Bug
		runState = Animator.StringToHash("Run");
		diggingState = Animator.StringToHash("Digging");
		myTransform = transform;                            // sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position; 
		Xspot.SetActive(false);
		// prevents myTransform reset
	}
	

	
	void FixedUpdate () {
		// keep track of the distance between this gameObject and destinationPosition       
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);

		// Set's speed in reference to distance
		if (currentBaseState.IsName("Digging") == true) {
			//shovel
			shovel.SetActive(true);
			shovel.transform.parent = rightHand;
			shovel.transform.localPosition = Vector3.zero;
			//sand particles
			sandParticles.SetActive(true);
			sandParticles.transform.localPosition = myTransform.position + myTransform.forward;
			//chest
			chest.SetActive(true);
			chest.transform.localPosition = myTransform.position + new Vector3 (myTransform.forward.x, 
			                                                                myTransform.forward.y - chestDig, 
			                                                                myTransform.forward.z);
			if (chestDig > 0) {
				chestDig -= 0.007f;
			}
		}
		else if (currentBaseState.IsName("Fishing") == true) {
			rod.SetActive(true);
			rod.transform.parent = leftHand;
			rod.transform.localPosition = Vector3.zero;
			//adjust rod in players hand
			rod.transform.localPosition += new Vector3(-0.2f, -0.5f, -1);
			//Splash.SetActive(true);
		}
		else {
			shovel.SetActive(false);
			sandParticles.SetActive(false);
			chest.SetActive(false);
			Xspot.SetActive(false);
			//rod.SetActive(false);
			//Splash.SetActive(false);
			chestDig = 1.0f;
		//}

			// To prevent code from running if not needed
			if(destinationDistance > 1.0f){
				Speed = 3f;
				Xspot.transform.position = destinationPosition;
				Xspot.SetActive(true);
				myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, Speed * Time.deltaTime);
			}
			else {
				Speed = 0;
				destinationDistance = 0;
				//myTransform.position = destinationPosition;
			}

			if (Speed > .5f){
				anim.SetFloat ("moveAnimSpeed", 2.0f);}
			else if (Speed < .5f){
				anim.SetFloat ("moveAnimSpeed", 0.0f);
			} // 

			// Moves the Player if the Left Mouse Button was clicked
			if (Input.GetMouseButtonDown(0)&& GUIUtility.hotControl ==0) {
				RaycastHit hitInfo = new RaycastHit();
				Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
				Plane playerPlane = new Plane(Vector3.up, myTransform.position);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float hitdist = 0.0f;
				if (playerPlane.Raycast(ray, out hitdist)) {
					Vector3 targetPoint = ray.GetPoint(hitdist);
					destinationPosition = ray.GetPoint(hitdist);
					Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
					myTransform.rotation = targetRotation;
					if (hitInfo.collider.gameObject.tag == "Island") {
						anim.SetBool("fishing", false);
					}
					else if (hitInfo.collider.gameObject.tag == "Water") {
						anim.SetBool("fishing", true);
						rod.transform.rotation = targetRotation;
						Splash.transform.position = hitInfo.point;
					}
				}			
			}   

			// Moves the player if the mouse button is hold down
			/*else if (Input.GetMouseButton(0)&& GUIUtility.hotControl ==0) {
				Plane playerPlane = new Plane(Vector3.up, myTransform.position);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float hitdist = 0.0f;

				if (playerPlane.Raycast(ray, out hitdist)) {
					Vector3 targetPoint = ray.GetPoint(hitdist);
					destinationPosition = ray.GetPoint(hitdist);
					Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
					myTransform.rotation = targetRotation;
				}
				//  myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
			}*/
		}
	}
}