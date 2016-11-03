using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector3 camForward;
	private Transform cam;
	private Vector3 move;
	public float damping = 1;
	public float gravity = 100.0F;

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


		Vector3 pos = new Vector3(Input.mousePosition.x - 500,0,Input.mousePosition.y - 300);

		//transform.LookAt(Vector3.Scale(Camera.main.ScreenToWorldPoint(Input.mousePosition) , noY));
		transform.LookAt(pos);

		//TODO: This kind of works... Think about actually fixing the problem though...


		/*

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
