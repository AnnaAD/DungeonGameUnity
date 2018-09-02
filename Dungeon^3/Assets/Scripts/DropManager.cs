using UnityEngine;
using System.Collections;

public class DropManager : MonoBehaviour {
	private static ArrayList drops;

	// Use this for initialization
	void Start () {
		drops = new ArrayList();
        foreach (GameObject g in Sword.GetSwords()) {
            drops.Add(g);
        }
	}
	
    public static void MakeDrop(Vector3 position,double enemyLevel) {
        Instantiate(drops[(Mathf.RoundToInt(Random.Range(0,drops.Count)))] as GameObject, position, Quaternion.identity);
	}


}
