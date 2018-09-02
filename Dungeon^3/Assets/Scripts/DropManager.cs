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
    public static void MakeDrop(Vector3 position, double enemyLevel, bool alwaysDrop) {
        if (!alwaysDrop) {
            if (!(Random.Range(0, 100) <= enemyLevel)) {
                Debug.Log("no item");
                return;
            }
        }
        float rand = Random.Range(0, 100);
        int i = Mathf.RoundToInt(rand);
        Debug.Log("random: " + rand);
        while (rand <= enemyLevel && i < drops.Count-1) {
            enemyLevel -= i*10;
            Debug.Log("random: " + rand);
            i++;
            rand = Random.Range(0, 100);
        }
        Debug.Log("item: " + i);
        Instantiate(drops[i] as GameObject, position, Quaternion.identity);
	}


}
