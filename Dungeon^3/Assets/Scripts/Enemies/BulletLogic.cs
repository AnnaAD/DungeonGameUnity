using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {
	public int damage;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col) {
		//Debug.Log("colliding with: " + col.gameObject);
		if(col.gameObject.tag == "Player") {
			GameObject.Find("Health").gameObject.GetComponent<PlayerHealth>().UpdateHealth(-damage);
			Destroy(gameObject);
		}
	}
}
