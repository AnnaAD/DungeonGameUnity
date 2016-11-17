using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {
    BoxCollider boxcollider;
    GameObject pivotPoint;
	// Use this for initialization
	void Start () {
        boxcollider=GetComponent<BoxCollider>();
        pivotPoint = GameObject.Find("Pivot point");
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag == "Enemy" && pivotPoint.GetComponent<SwordSwing>().isStabbing) {
			col.gameObject.GetComponent<Enemy>().Damage(4);
        }
    }
}
