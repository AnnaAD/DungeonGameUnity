using UnityEngine;
using System.Collections;

public class TrapdoorTrigger : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		//Debug.Log("colliding with: " + col.gameObject);
		if(col.gameObject.tag == "Player") {
			Debug.Log("player");
			col.gameObject.GetComponent<PlayerController>().Fall(transform);
		}
	}
}
