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
    void OnCollisionEnter(Collision col)
    {

        //TODO: Eventually change this to tag of 'enemy' or something
        if (col.gameObject.name == "Slime" && pivotPoint.GetComponent<SwordSwing>().isStabbing)
        {
            col.gameObject.GetComponent<SlimeAI>().Damage(4);
        }
    }
}
