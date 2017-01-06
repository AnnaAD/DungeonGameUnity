using UnityEngine;
using System.Collections;

public class ExplodingBulletLogic : MonoBehaviour {
	public GameObject bulletPrefab;		
	// Use this for initialization
	void Start () {
		//bulletPrefab = GameObject.Find ("SlimeBullet");
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col) {
		Debug.Log("colliding with: " + col.gameObject);
		if (col.gameObject.tag == "Player") {
			GameObject.Find ("Health").gameObject.GetComponent<PlayerHealth> ().UpdateHealth (-25);
			Explode ();
			Destroy (gameObject);
		}
		if (col.gameObject.tag=="Level") {
			Explode ();
			Destroy (gameObject);
		}
	}

	public void Explode(){
		for (int i = 80; i > 55; i-=5) {
			for (int j = 1; j < 7; j++) {
				GameObject shrapnel=GameObject.Instantiate (bulletPrefab,
					this.GetComponent<Transform>().position,
					Quaternion.Euler(-i,360/j,0)) as GameObject;
				shrapnel.GetComponent<Transform> ().Translate ( shrapnel.GetComponent<Transform> ().forward*.2f);
				shrapnel.GetComponent<Rigidbody> ().velocity = shrapnel.GetComponent<Transform> ().forward*.3f;

			}
		}
		Destroy (gameObject);
	}
	

}