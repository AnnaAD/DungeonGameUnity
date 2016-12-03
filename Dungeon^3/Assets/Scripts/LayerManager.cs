using UnityEngine;
using System.Collections;

public class LayerManager : MonoBehaviour {
	//
	int playerLayer = 9;
	int enemyOnlyLayer = 10;


	// Use this for initialization
	void Start () {
		Physics.IgnoreLayerCollision(playerLayer,enemyOnlyLayer);
		//default layer
		Physics.IgnoreLayerCollision(0, enemyOnlyLayer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
