using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {
	Rigidbody rigidbody;
    
	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find("Player");
		rigidbody = GetComponent<Rigidbody>();
		Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>(),true);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter (Collision col) {
		rigidbody.constraints = RigidbodyConstraints.None;
		if(col.gameObject.tag == "Enemy") {
			Debug.Log("Damage");
			col.gameObject.GetComponent<Enemy>().Damage(1);
		}
	}
}
