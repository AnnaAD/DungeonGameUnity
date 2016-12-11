using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {
    GameObject pivotPoint;

	// Use this for initialization
	void Start () {
        pivotPoint = GameObject.Find("Pivot point");
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag == "Enemy" && pivotPoint.GetComponent<SwordAnimation>().isSwinging) {
			float swordDamage = GameObject.Find ("PlayerModel").GetComponent<Inventory> ().GetSword ().GetDamage ();
			float swordsmanship = GameObject.Find ("Player").GetComponent<PlayerStats> ().swordsmanship;
			col.gameObject.GetComponent<Enemy>().Damage(swordDamage*(.7f+swordsmanship*.05f));
        }
    }
}
