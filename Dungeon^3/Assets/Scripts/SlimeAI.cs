using UnityEngine;
using System.Collections;

public class SlimeAI : MonoBehaviour {

	private Rigidbody rBody;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update (){

		float moveX = 0;
		float moveZ = 0;
		GameObject player = GameObject.Find ("Player");
		if (player.transform.position.x > transform.position.x) {
			moveX = 1;
		} else {
			moveX = -1;
		}

		if (player.transform.position.z > transform.position.z) {
			moveZ = 1;
		} else {
			moveZ = -1;
		}

		rBody.velocity = new Vector3 (moveX, 0f, moveZ);


	}
}
