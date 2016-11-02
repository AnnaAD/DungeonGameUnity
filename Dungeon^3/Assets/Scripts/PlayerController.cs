using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector3 camForward;
	private Transform cam;
	private Vector3 move;

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
		controller.Move(moveDirection * Time.deltaTime);


	}
		
}
