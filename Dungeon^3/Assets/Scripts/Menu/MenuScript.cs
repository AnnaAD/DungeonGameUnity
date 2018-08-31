using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {
    
	public void Play() {
		Debug.Log("clicked play");
		SceneManager.LoadScene("level01");
	}

	public void Endgame() {
		Debug.Log("clicked quit");
		Application.Quit();
	}
}
