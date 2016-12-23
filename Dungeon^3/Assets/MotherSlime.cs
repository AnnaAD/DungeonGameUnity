using UnityEngine;
using System.Collections;

public class MotherSlime : GreenSlime {
	private bool seen;
	public GameObject SlimePrefab;
	private int children;
	// Use this for initialization
	void Start () {
		base.Start ();
		children = (int)(Random.value * 2f + 4f);
	}
	
	// Update is called once per frame
	void Update () {
		seen = CanSeePlayer ();

		if (seen) {
			Vector3 playerOnPlane = new Vector3 (player.transform.position.x, .75f, player.transform.position.z);
			transform.LookAt (playerOnPlane);
			rBody.velocity = transform.forward * speed;
			transform.position = new Vector3 (transform.position.x, .75f, transform.position.z);

		} else {
			rBody.velocity = transform.forward * 1;
			transform.Rotate (new Vector3 (0, (Random.value * 2) - 1, 0));	
		}

	}

	public void Die (){
		print ("Spawned " + children + " children");
		for(int i = 0; i < 5; i++) {

			GameObject slime = Instantiate(SlimePrefab) as GameObject;
			slime.transform.position = transform.position;
		}
		base.Die ();
	}
}
