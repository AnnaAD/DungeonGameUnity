using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
/**
 * Handles all events caused by animations.
 * Code placed here so that the next level and the death happen only after animations complete
 * */
public class EndOfAnimationEventHandler : MonoBehaviour {
	public void nextLevel() {
        GameObject.Find("WorldManager").GetComponent<LevelManager>().nextLevel();
	}

    public void endOfDeathAnimation()
    {
        //TODO: Stop playerHealth from dropping
        GameObject.Find("WorldManager").GetComponent<LevelManager>().endGame();
    }
}
