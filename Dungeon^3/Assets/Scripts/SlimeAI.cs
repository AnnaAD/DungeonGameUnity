using UnityEngine;
using System.Collections;

public class SlimeAI : MonoBehaviour {
	public int health = 10;
	private Rigidbody rBody;
	private GameObject player;
	private bool colliding = false;
	private GameObject playerHealth;
	private GameObject slime;

	// Use this for initialization
	void Start () {
		slime  = Resources.Load("Prefabs/Slime") as GameObject;
		rBody = GetComponent<Rigidbody> ();
		player = GameObject.Find("Player");
		playerHealth = GameObject.Find("Text");
	}
	
	// Update is called once per frame
	void Update (){
		transform.LookAt(player.transform);
		rBody.velocity = transform.forward * 3;


		transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

	}

	public void Damage(int number) {
		health -= number;
		Debug.Log(health);
		if (health <= 0) {
			GameObject tempSlime = Instantiate(slime, transform.position, Quaternion.identity) as GameObject;
			tempSlime.name = "Slime";
			tempSlime = Instantiate(slime, transform.position, Quaternion.identity) as GameObject;
			tempSlime.name = "Slime";

			Destroy(gameObject);
		}
	}

	void OnCollisionStay (Collision col) {
		if (col.gameObject.name == "Player") {
			playerHealth.GetComponent<PlayerHealth>().UpdateHealth(-1);
		}
	}
		
}
