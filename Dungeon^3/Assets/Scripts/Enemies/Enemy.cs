using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health;
	public int damage;
    public float speed;
    public Rigidbody rBody;
	public GameObject player;
	private GameObject playerHealth;
	private GameObject playerXP;
	private GameObject deathEmitter;
	public int xp;
    [SerializeField] private float sightRange;
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
		//print (this + " died");
		playerXP.GetComponent<PlayerXP>().addXP(xp);
		GameObject instance = Instantiate(deathEmitter,transform.position,Quaternion.identity) as GameObject;
		instance.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer> ().material;

		Destroy(instance,1.5f);
        DropManager.MakeDrop(transform.position,xp,false);
		Destroy(gameObject);
	}

	public bool CanSeePlayer(){
        //print(Vector3.Distance(transform.position, player.transform.position));
        RaycastHit hit;
		if(Physics.Linecast(transform.position, player.transform.position, out hit)) {
            if (hit.collider.gameObject.name == "Player" && Vector3.Distance(transform.position, player.transform.position) < sightRange) {
				return true;
			} else {
				return false;
			}
		}

		//Debug.Log("This shouldn't happen...");
		return true;
	}
}
