using UnityEngine;
using System.Collections;

public class PurpleSlime : Enemy {

	public void loadResources() {

	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(player.transform);

		Debug.Log(Vector3.Distance(player.transform.position,transform.position));
		if(Vector3.Distance(player.transform.position,transform.position) > 2f) {
			rBody.velocity = transform.forward * 3;
		} else {
			rBody.velocity = Vector3.zero;
		}


		transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

	}
}
