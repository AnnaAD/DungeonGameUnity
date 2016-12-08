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
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
		Transform trans1 = player.GetComponent<Transform>();
		Transform trans2 = trapdoor.GetComponent<Transform>();
		if (Vector3.Distance(trans1.position,trans2.position)<triggerDistance) {
			//Debug.Log("open");
			animator.SetTrigger("open");
		}
	}
}
