using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public void Play() {
		Debug.Log("clicked play");
		Application.LoadLevel("dungeon");
	}

	public void Endgame() {
		Debug.Log("clicked quit");
		Application.Quit();
	}
}
