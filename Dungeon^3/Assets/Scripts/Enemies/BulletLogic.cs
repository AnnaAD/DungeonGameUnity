using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		Debug.Log("colliding with: " + col.gameObject);
		if(col.gameObject.tag == "Player") {
			GameObject.Find("Text").gameObject.GetComponent<PlayerHealth>().UpdateHealth(-1);
			Destroy(gameObject);
		}
	}
}
