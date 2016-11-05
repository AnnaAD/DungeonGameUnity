using UnityEngine;
using System.Collections;

public class SlimeAI : MonoBehaviour {
	public int health = 100;
	private Rigidbody rBody;
	private GameObject Player;


	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody> ();
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update (){
		transform.LookAt(player);
		rBody.velocity = transform.forward * 6;

		transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

	}

	public void Damage(int number) {
		health -= number;
		Debug.Log(health);
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
