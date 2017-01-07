using UnityEngine;
using System.Collections;

public class ExplodingBulletLogic : MonoBehaviour {
	public GameObject bulletPrefab;		

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
		}
		if (col.gameObject.layer==8) {
			Explode ();
		}
	}

	public void Explode(){
		Vector3 pos = this.GetComponent<Transform> ().position;
		//Creates 8 bullet objects in a semicircle and a velocity going out. 
		for (int j = 0; j < 8; j++) {
			GameObject shrapnel = GameObject.Instantiate (bulletPrefab,
				new Vector3(.5f*Mathf.Sin(Mathf.Deg2Rad*45*j),pos.y,.5f*Mathf.Cos(Mathf.Deg2Rad*45*j)),
				    Quaternion.Euler (0, 45 * j, 0)) as GameObject;
			shrapnel.GetComponent<Rigidbody> ().velocity = shrapnel.GetComponent<Transform> ().forward * 5f;
			shrapnel.GetComponent<BulletLogic> ().damage = 5;
		}
		Destroy (gameObject);
	}

}