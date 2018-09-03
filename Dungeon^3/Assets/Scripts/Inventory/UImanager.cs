using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {
	public bool isPaused;
	public GameObject menu;
	// Use this for initialization
	void Start () {
		
        Debug.Log("Menu: "+menu);
        menu.SetActive (false);
        isPaused = false;
        /*GameObject button = GameObject.Find("ResumeButton");
        button.GetComponent<Button>().onClick.AddListener(TogglePause);
	    */
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
            //Pauses game
			isPaused = true;
			Time.timeScale = 0.0f;
            Debug.Log(menu);
			menu.SetActive (true);
		} else {

            // Unpauses game
            isPaused = false;
            Time.timeScale = 1.0f;  
            menu.SetActive(false);
        }
	}

    public void Endgame()
	{
		Application.Quit ();
	}
}
