using UnityEngine;
using System.Collections;

public class TrapdoorTrigger : MonoBehaviour {

	void OnCollisionEnter (Collision col) {
		Debug.Log("colliding with: " + col.gameObject);
		if(col.gameObject.tag == "Player") {
			Debug.Log("player");
		}
	}
}
