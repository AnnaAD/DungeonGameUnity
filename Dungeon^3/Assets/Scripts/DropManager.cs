using UnityEngine;
using System.Collections;

public class DropManager : MonoBehaviour {
	private ArrayList drops;

	// Use this for initialization
	void Start () {
		drops = new ArrayList();
	}
	
	public void getDrop(double enemyLevel) {

	}

	public void addDrop(GameObject drop) {
		drops.Add(drop);
	}


}
