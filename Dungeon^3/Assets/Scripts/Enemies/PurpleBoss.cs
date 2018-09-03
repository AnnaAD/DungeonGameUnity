using UnityEngine;
using System.Collections;

public class PurpleBoss : Enemy {
	private float timeSincePhaseChange;
	public GameObject explodingBullet;
	public GameObject bulletPrefab;
	private float timeSinceFire;
	public int phase;
	public float timeBetweenLargeShots;
	public float timeBetweenSmallShots;
	public GameObject purpleSlime;
	public GameObject fastSlime;
	public GameObject motherSlime;
	// Use this for initialization
	void Start (){
		base.Start ();
		timeSincePhaseChange = 0;
		phase = 0;
		timeSinceFire = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (CanSeePlayer())
        {
            //Keeps the right movement
            transform.LookAt(player.transform);
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0f;
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
            transform.position = new Vector3(transform.position.x, .75f, transform.position.y);
            //toggles phase
            if (timeSincePhaseChange > 25)
            {
                phase++;
                timeSincePhaseChange = 0;
            }
            //handles phase dependent behavior, mostly shooting
            if (phase == 0)
            {
                if (timeSinceFire > timeBetweenSmallShots)
                {
                    Fire();
                    timeSinceFire = 0;
                }
            }
            else if (phase == 1)
            {
                GameObject.Instantiate(motherSlime, transform.position + new Vector3(Random.Range(1f, 2.5f), 0f, Random.Range(1f, 2.5f)), Quaternion.identity);
                // GameObject.Instantiate(motherSlime,transform.position+new Vector3(Random.Range(1f,2.5f),0f,Random.Range(1f,2.5f)),Quaternion.identity);
                phase = 2;
            }
            else if (phase == 2)
            {
                if (timeSinceFire > timeBetweenLargeShots)
                {
                    FireLargeBullet();
                    timeSinceFire = 0;
                }
            }
            else if (phase == 3)
            {
                //GameObject.Instantiate(purpleSlime,transform.position+new Vector3(Random.Range(1f,2.5f),0f,Random.Range(1f,2.5f)),Quaternion.identity);
                GameObject.Instantiate(purpleSlime, transform.position + new Vector3(Random.Range(1f, 2.5f), 0f, Random.Range(1f, 2.5f)), Quaternion.identity);
                //GameObject.Instantiate(fastSlime,transform.position+new Vector3(Random.Range(1f,2.5f),0f,Random.Range(1f,2.5f)),Quaternion.identity);
                GameObject.Instantiate(fastSlime, transform.position + new Vector3(Random.Range(1f, 2.5f), 0f, Random.Range(1f, 2.5f)), Quaternion.identity);
                phase = 0;
            }
        }
		//increments timers
		timeSinceFire += Time.deltaTime;
		timeSincePhaseChange += Time.deltaTime;

	}

	public void Fire(){
		//creates a small bullet
		GameObject bullet=GameObject.Instantiate(bulletPrefab,transform.position+transform.forward-new Vector3(0f,.2f,0f),transform.rotation) as GameObject;
		bullet.GetComponent<Rigidbody> ().velocity = transform.forward * 10f;
		bullet.GetComponent<BulletLogic> ().damage = 3;
		Destroy (bullet, 1.5f);
	}

	public void FireLargeBullet(){
		//Creates a large bullet that points towards the player
		GameObject bullet = GameObject.Instantiate (explodingBullet);
		bullet.transform.position = transform.position + transform.forward;
		bullet.transform.LookAt (player.transform);
		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 8f;
		Destroy (bullet, 10f);
	}
}
