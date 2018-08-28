using UnityEngine;
using System.Collections;

// Class dedicated to making the buttons on the inventory and stat windows work
public class PopupManager : MonoBehaviour {
	public bool inventoryOpen;
	public GameObject inventoryBackground;
	public GameObject inventoryButton;
	public void Start(){
		inventoryOpen = true;
		toggleInventory ();

	}
	public void toggleInventory()
	{	
		if(inventoryOpen){
			inventoryButton.GetComponent<Transform>().Translate( new Vector3 (0f, -174.4f, 0f));
			inventoryBackground.SetActive (false);
			inventoryOpen = false;

		} else {
			inventoryButton.GetComponent<Transform>().Translate(new Vector3 (0f, 174.4f, 0f));

			inventoryBackground.SetActive (true);
			inventoryOpen = true;
		}
	}
}
