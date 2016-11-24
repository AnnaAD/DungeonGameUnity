using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public bool isPaused;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Cancel")){
			togglePause ();
		}
	}

	public void togglePause()
	{
		if (!isPaused) {
			isPaused = true;
			Time.timeScale = 0.0f;
		} else {
			isPaused = false;
			Time.timeScale = 1.0f;
		}
	}
}
