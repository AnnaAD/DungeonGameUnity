using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    // Names of every level in order they are called (automate this somehow?)
    string [] levels = {"level01","level02","bosslevel" };
    // index of current level
    private int currentLevel;
	// Use this for initialization
	void Awake () {
        currentLevel = 0;
        //Instantiates Canvas if it doesn't already exist
        if (GameObject.Find("Canvas") == null){
            GameObject canvas = Instantiate((GameObject)Resources.Load<GameObject>("Prefabs/Canvas"));
        }
	}
	
	public void nextLevel() {
        currentLevel++;
        // Loads next scene in array "levels"
        UnityEngine.SceneManagement.SceneManager.LoadScene(levels[currentLevel]);
    }

    public void endGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("deathmenu");
        Object.Destroy(GameObject.Find("Canvas"));
        Object.Destroy(this.gameObject);
    }
}
