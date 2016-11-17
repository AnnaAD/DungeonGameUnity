using UnityEngine;
using System.Collections;

public class GreenSlime : Enemy {

	
	// Update is called once per frame
	void Update (){
		transform.LookAt(player.transform);
		rBody.velocity = transform.forward * 3;


		transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

	}
		
		
}
