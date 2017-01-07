using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health;
	public int damage;
	public Rigidbody rBody;
	public GameObject player;
	private GameObject playerHealth;
	private GameObject playerXP;
	private GameObject deathEmitter;
	public int xp;
	// Use this for initialization
	protected void Start () {
		rBody = GetComponent<Rigidbody> ();
		player = GameObject.Find("Player");
		playerHealth = GameObject.Find("Health");
		playerXP = GameObject.Find("XP");
		deathEmitter = Resources.Load("Prefabs/DeathEmitter") as GameObject;
		loadResources();
	}

	public virtual void loadResources(){}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Damage(float number) {
		health -= number;
		if (health <= 0) {
			Die();
		}
	}

	void OnCollisionStay (Collision col) {
		if (col.gameObject.name == "Player") {
			playerHealth.GetComponent<PlayerHealth>().UpdateHealth(-damage);
		}
	}

	public virtual void Die() {
		print ("died");
		playerXP.GetComponent<PlayerXP>().addXP(xp);
		GameObject instance = Instantiate(deathEmitter,transform.position,Quaternion.identity) as GameObject;
		Destroy(instance,1.5f);
		Destroy(gameObject);
	}

	public bool CanSeePlayer(){

		RaycastHit hit;
		if(Physics.Linecast(transform.position, player.transform.position, out hit)) {
			if(hit.collider.gameObject.name == "Player") {
				return true;
			} else {
				return false;
			}
		}

		//Debug.Log("This shouldn't happen...");
		return true;
	}
}
