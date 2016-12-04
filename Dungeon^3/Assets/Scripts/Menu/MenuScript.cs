using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public void Play() {
		Debug.Log("clicked play");
		EditorSceneManager.LoadScene("dungeon");
	}

	public void Endgame() {
		Debug.Log("clicked quit");
		Application.Quit();
	}
}
