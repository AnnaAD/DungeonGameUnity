using UnityEngine;
using System.Collections;

public class SwordController: MonoBehaviour {
	GameObject pivotPoint;

	// Use this for initialization
	void Start () {
		pivotPoint = GameObject.Find("Pivot point");
	}

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision col) {
		print ("Colliding");
		print ("Swrd swing: " + pivotPoint.GetComponent<SwordAnimation>().isSwinging);
		print ("col: " + col.gameObject.tag );
		if (col.gameObject.tag == "Enemy" && pivotPoint.GetComponent<SwordAnimation>().isSwinging) {
			Item sword = GameObject.Find ("Player").GetComponent<Inventory> ().GetSword() ;
			if (sword == null) {
				return;
			}
			float swordsmanship = GameObject.Find ("Player").GetComponent<PlayerStats> ().swordsmanship;
			print (sword.GetDamage ());
			col.gameObject.GetComponent<Enemy>().Damage(sword.GetDamage()*(.7f+swordsmanship*.05f));
		}
	}
}
