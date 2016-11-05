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
	}
}
