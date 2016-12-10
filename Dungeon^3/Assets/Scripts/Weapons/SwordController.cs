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
			col.gameObject.GetComponent<Enemy>().Damage(4);
        }
    }
}
