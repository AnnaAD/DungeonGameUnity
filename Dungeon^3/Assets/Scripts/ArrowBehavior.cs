using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {
	Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter (Collision col) {
		rigidbody.constraints = RigidbodyConstraints.None;
		//TODO: Eventually change this to tag of 'enemy' or something
		if(col.gameObject.name == "Slime") {
			col.gameObject.GetComponent<SlimeAI>().Damage(1);
		}
	}
}
