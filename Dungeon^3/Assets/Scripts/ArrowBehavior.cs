using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {
	private int lifeCount;
	// Use this for initialization
	void Start () {
		lifeCount = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(lifeCount >= 0) {

		} else {
			Destroy(gameObject);
		}
	}
}
