using UnityEngine;
using System.Collections;

public class ChestController : MonoBehaviour {

	Animator animator;
	private bool chestOpen;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		chestOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)) {
			if(chestOpen == false) {
				animator.SetTrigger("Open");
				Debug.Log("trying to open");
				chestOpen = true;
			} else {
				animator.SetTrigger("Close");
				Debug.Log("trying to close");
				chestOpen = false;
			}
		}
	}
}
