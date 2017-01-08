using UnityEngine;
using System.Collections;

public class Teleporter : GreenSlime {
	private float timeSinceTeleport;
	// Use this for initialization
	new void Start () {
		base.Start ();
		timeSinceTeleport = 0;
	}

	// Update is called once per frame
	new void Update () {
		base.Update ();
		//transform.LookAt (player.transform);
		timeSinceTeleport += Time.deltaTime;
		if (timeSinceTeleport > 10f) {
			GetComponent<Animator> ().SetTrigger ("Teleport");
			timeSinceTeleport = 0;
		}
	}
	public void OnPreCull(){
		//transform.LookAt (player.transform);
	}
	public void Teleport(){
		transform.position = new Vector3 (player.transform.position.x, .5f, player.transform.position.z);
	}
}
