using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play()
	{
		Application.LoadLevel ("dungeon");
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
