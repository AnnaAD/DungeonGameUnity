using UnityEngine;
using System.Collections;

public class UImanager : MonoBehaviour {
	public bool isPaused;
	public GameObject menu;
	// Use this for initialization
	void Start () {
		//menu = GameObject.Find ("PauseMenu");
		//menu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Cancel")){
			TogglePause ();
		}

	}

	public void TogglePause()
	{
		if (!isPaused) {
			isPaused = true;
			Time.timeScale = 0.0f;
			menu.SetActive (true);
		} else {
			isPaused = false;
			Time.timeScale = 1.0f;
			menu.SetActive (false);
		}
	}

	public void Endgame()
	{
		Application.Quit ();
	}
}
