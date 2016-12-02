using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	public static bool inventoryOpen;
	public GameObject inventoryBackground;
	public GameObject inventoryButton;
	public void Start(){
		inventoryOpen = true;
		toggleInventory ();

	}
	public void toggleInventory()
	{	
		if(inventoryOpen){
			inventoryButton.GetComponent<Transform>().Translate( new Vector3 (0f, -180.4f, 0f));
			inventoryBackground.SetActive (false);
			inventoryOpen = false;

		} else {
			inventoryButton.GetComponent<Transform> ().Translate(new Vector3 (0f, 180.4f, 0f));

			inventoryBackground.SetActive (true);
			inventoryOpen = true;
		}
	}
}
