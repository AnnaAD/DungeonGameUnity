using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector3 camForward;
	private Transform cam;
	private Vector3 move;
	public float damping = 1;
	public float gravity = 100.0F;

	private Plane plane =  new Plane(Vector3.up, Vector3.zero);


	private Rigidbody rBody;

	public float speed = 5.0F;
	private Vector3 moveDirection = Vector3.zero;

	void Start() {
		rBody = GetComponent<Rigidbody>();
	}

	void Update() {



		cam = Camera.main.transform;
		camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
		CharacterController controller = GetComponent<CharacterController>();
		float inputX = Input.GetAxis("Horizontal");
		float inputZ = Input.GetAxis("Vertical");
		moveDirection = (inputZ*camForward + inputX*cam.right).normalized;
		moveDirection *= speed;
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float ent = 100.0f;
		if (plane.Raycast(ray, out ent)) {
			Debug.Log("Plane Raycast hit at distance: " + ent);
			Vector3 hitPoint = ray.GetPoint(ent);
			hitPoint.y = transform.position.y;
			transform.LookAt(hitPoint);
			Debug.DrawRay (ray.origin, ray.direction * ent, Color.green);
		} else {
			Debug.DrawRay (ray.origin, ray.direction * 10, Color.red);

		}


		/* 
		Vector3 pos = new Vector3(Input.mousePosition.x - 500,0,Input.mousePosition.y - 300);

		transform.LookAt(Vector3.Scale(Camera.main.ScreenToWorldPoint(Input.mousePosition) , noY));
		transform.LookAt(pos);

		Ray ray = Camera.main.ScreenPointToRay(new Vector3(200, 200, 0));
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

		//TODO: This kind of works... Think about actually fixing the problem though...


		Debug.Log(Input.mousePosition);
		Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		if(Input.GetMouseButtonDown(0)) {
			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphere.transform.position = pos;
		}
		Debug.Log(Vector3.Scale(Camera.main.ScreenToWorldPoint(Input.mousePosition) , noY));

		*/

	}
		
}
