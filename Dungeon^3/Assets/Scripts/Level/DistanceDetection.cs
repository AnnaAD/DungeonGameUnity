using UnityEngine;
using System.Collections;

public class DistanceDetection : MonoBehaviour {
	public GameObject trapdoor;
	public GameObject player;
	public float triggerDistance;
	public Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Transform trans1 = player.GetComponent<Transform>();
		Transform trans2 = trapdoor.GetComponent<Transform>();
		if (Mathf.Abs (trans1.position.x - trans2.position.x) < triggerDistance && Mathf.Abs (trans1.position.y - trans1.position.y)<triggerDistance) {
			animator.SetTrigger ("open");
		}
	}
}
