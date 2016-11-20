using UnityEngine;
using System.Collections;

public class GreenSlime : Enemy {
	private Vector3 lastSeen;
	private bool seen;
	private bool checkedLastSeen;
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Debug.DrawRay(transform.position, transform.forward);
		seen = CanSeePlayer();

		if(seen) {
			transform.LookAt(player.transform);
			rBody.velocity = transform.forward * 3;
			transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
			lastSeen = player.transform.position;
			checkedLastSeen = false;
			Debug.Log("seen");
		
		} else {
			//TODO: Fix this as it never actually gets to the lastSeen point
			if(transform.position == lastSeen) {
				checkedLastSeen = true;
			}

			if(checkedLastSeen == false) {
				transform.LookAt(lastSeen);
				rBody.velocity = transform.forward * 3;
				transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
			} else {
				int mode = Mathf.RoundToInt(Random.value * 2);
				//TODO: Better Idle Behavior with turning and wall bouncing

				if(mode == 0) {
					rBody.velocity =  Vector3.zero;
				}

				if(mode == 1) {
					rBody.velocity = transform.forward * 1;
				}
					
					
			}


		}
		Debug.Log(lastSeen);
		Debug.Log(checkedLastSeen);
	}

	private bool CanSeePlayer(){

		RaycastHit hit;
		if(Physics.Linecast(transform.position, player.transform.position, out hit)) {
			if(hit.collider.gameObject.name == "Player") {
				return true;
			} else {
				return false;
			}
		}

		Debug.Log("This shouldn't happen...");
		return false;
	}
}