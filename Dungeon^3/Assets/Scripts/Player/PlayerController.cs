using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector3 camForward;
	private Transform cam;
	private Vector3 move;
	private Plane plane =  new Plane(Vector3.up, Vector3.zero);
	private Vector3 moveDirection = Vector3.zero;
	public GameObject worldManager;
	public GameObject bulletPrefab;
	private GameObject pivotPoint;
	public Transform bulletSpawn;
	public float speed = 5.0F;
	public float arrowSpeed = 9f;
	private CharacterController controller;
	private Animator animator;
	private bool falling;
    // How long player has been falling in ticks
	private int fallCount;
	[SerializeField] Inventory inventoryObject;

	void Start() {
		worldManager = GameObject.Find ("WorldManager");
		pivotPoint = GameObject.Find ("Pivot point");
		cam = Camera.main.transform;
		camForward = Vector3.Scale (cam.forward, new Vector3 (1, 0, 1)).normalized;
		controller = GetComponent<CharacterController>();
		animator = GetComponentInChildren<Animator>();
		animator.enabled = false;
        Debug.Log(GameObject.Find("Inventory"));
		inventoryObject = GameObject.Find("Inventory").GetComponent<Inventory>();
	}

	void Update() {
		if (!worldManager.GetComponent<UImanager>().isPaused && !animator.enabled) {
			float inputX = Input.GetAxisRaw ("Horizontal");
			float inputZ = Input.GetAxisRaw ("Vertical");
			moveDirection = (inputZ * camForward + inputX * cam.right).normalized;
			moveDirection *= speed;
			moveDirection.y = 0;
				controller.Move (moveDirection * Time.deltaTime);
            // Movement
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float ent = 100.0f;
			if (plane.Raycast (ray, out ent)) {
				//Debug.Log("Plane Raycast hit at distance: " + ent);
				Vector3 hitPoint = ray.GetPoint (ent);
				hitPoint.y = transform.position.y;
				transform.LookAt (hitPoint);
				//Debug.DrawRay (ray.origin, ray.direction * ent, Color.green);
			} else {
				//Debug.DrawRay (ray.origin, ray.direction * 10, Color.red);

			}

			if (Input.GetMouseButtonDown (0)) {
				if(inventoryObject.GetBow() != null) {
					Fire ();
				}
			}
			if (Input.GetMouseButtonDown (1)) {
				pivotPoint.GetComponent<SwordAnimation>().Swing();
			}
            // Resets y position to .5f
			transform.position = new Vector3 (transform.position.x, 0.5f, transform.position.z);
		
		} else if (!worldManager.GetComponent<UImanager> ().isPaused && falling) {
			controller.Move(transform.forward * 0.05f);
			fallCount++;
			if(fallCount > 20) {
				falling = false;
			}

		}
	}

	public void Fire() {
		// Create the Bullet from the Bullet Prefab
		GameObject bullet = Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation) as GameObject;

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * arrowSpeed;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 1.5f);  
	}

	public void Fall(Transform trigger) {
		Debug.Log("falling");
		animator.enabled = true;
		animator.SetTrigger("Fall");
		transform.LookAt(new Vector3(trigger.position.x, transform.position.y, trigger.position.z));
		falling = true;
		fallCount = 0;
	}

	public void incrementSpeed(float val){
		speed = speed + val;
	}

    // When player has been killed
   public void killPlayer()
    {
        animator.enabled = true;
        // Tells animation player has been killed
        animator.SetTrigger("StartDeathAnimation");
    }
}
