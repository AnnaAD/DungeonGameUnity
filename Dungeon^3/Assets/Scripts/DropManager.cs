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
	
    //enemy level ranges from 10 - 100, 100 being a harder to defeat enemy
    //enemyLevel acts as an added percent chance of having drop
    //enemyLevel then acts as percent chance of iterating through list to next spot. 
    //enemyLevel decreases by i*10%, where i is place in list, giving more likelyhood of stopping at later items
    // Used by Enemy
    // Assume drops has at least 1 item. 
    public static void MakeDrop(Vector3 position, double enemyLevel, bool alwaysDrop) {
        if (!alwaysDrop) {
            // Higher enemy level, higher chance of item. 
            if (Random.Range(0, 100) >= enemyLevel) {
                //Debug.Log("No item dropped");
                return;
            }
        }
        float rand = Random.Range(0, 100);
        // i represents the index of drops to drop. A higher i means a better item. 
        int i = 1;
        //Debug.Log("random: " + rand);
        while (rand <= enemyLevel && i < drops.Count-1) {
            enemyLevel -= i*10;
            i++;
            rand = Random.Range(0, 100);
        }
        // Debug.Log("item: " + i);
        Instantiate(drops[i] as GameObject, position, Quaternion.identity);
	}


}
