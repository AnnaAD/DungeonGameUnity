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

		}
		if (col.gameObject.layer==8) {
			Explode ();

		}
	}

	public void Explode(){
		gameObject.SetActive (false);
		Vector3 pos = this.GetComponent<Transform> ().position;
		//for (int i = 80; i > 55; i-=5) {
		for (int j = 0; j < 6; j++) {
			GameObject shrapnel = GameObject.Instantiate (bulletPrefab,
				new Vector3(2f*Mathf.Cos((1/3)*Mathf.PI*j),pos.y,-2f*Mathf.Sin((1/3)*Mathf.PI*j)),

				                      Quaternion.Euler (0, 60 * j, 0)) as GameObject;
			shrapnel.GetComponent<Transform> ().Translate (shrapnel.GetComponent<Transform> ().forward * 3f, Space.Self);
			shrapnel.GetComponent<Rigidbody> ().velocity = shrapnel.GetComponent<Transform> ().forward * 5f;
			shrapnel.GetComponent<BulletLogic> ().damage = 5;
			print ("created gameObject shrapnel. Rotation: " + shrapnel.GetComponent<Transform> ().eulerAngles + " Velocity: " + shrapnel.GetComponent<Rigidbody> ().velocity+ "Position: "+shrapnel.GetComponent<Transform>().position);
		}
			//}	
		Destroy (gameObject);

	}
	

}