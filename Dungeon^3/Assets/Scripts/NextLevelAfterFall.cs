using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevelAfterFall : MonoBehaviour {
	public void nextLevel() {
		SceneManager.LoadScene("dungeon");
	}
}
