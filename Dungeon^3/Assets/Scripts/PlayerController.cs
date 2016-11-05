using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector3 camForward;
	private Transform cam;
	private Vector3 move;
	private Plane plane =  new Plane(Vector3.up, Vector3.zero);
	private Vector3 moveDirection = Vector3.zero;

	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public float speed = 5.0F;

	void Start() {

	}

	void Update() {

		cam = Camera.main.transform;
		camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
		CharacterController controller = GetComponent<CharacterController>();
		float inputX = Input.GetAxis("Horizontal");
		float inputZ = Input.GetAxis("Vertical");
		moveDirection = (inputZ*camForward + inputX*cam.right).normalized;
		moveDirection *= speed;
		moveDirection.y = 0;
		controller.Move(moveDirection * Time.deltaTime);


		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float ent = 100.0f;
		if (plane.Raycast(ray, out ent)) {
			//Debug.Log("Plane Raycast hit at distance: " + ent);
			Vector3 hitPoint = ray.GetPoint(ent);
			hitPoint.y = transform.position.y;
			transform.LookAt(hitPoint);
			Debug.DrawRay (ray.origin, ray.direction * ent, Color.green);
		} else {
			Debug.DrawRay (ray.origin, ray.direction * 10, Color.red);

		}


		if (Input.GetMouseButtonDown(0)) {
			Fire();
		}

		transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
	}

	public void Fire() {
		// Create the Bullet from the Bullet Prefab
		GameObject bullet = Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation) as GameObject;

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 1.5f);  
	}
		
}
