using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {
	Rigidbody rigidbody;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		rigidbody = GetComponent<Rigidbody>();
		Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>(),true);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter (Collision col) {
		rigidbody.constraints = RigidbodyConstraints.None;
		if(col.gameObject.tag == "Enemy") {
			float bowmanship = player.GetComponent<PlayerStats> ().bowmanship;
			float itemdamage = GameObject.Find ("PlayerModel").GetComponent<Inventory> ().GetBow().GetDamage();
			Debug.Log("Damage. Bowmanship: "+bowmanship+" Bow Item Damage:"+itemdamage);
			col.gameObject.GetComponent<Enemy>().Damage((itemdamage*(.7f+(bowmanship*.05f)))); 
		}
	}


}
