using UnityEngine;
using System.Collections;

public class Item : ScriptableObject {
	public GameObject gameObject;
	public Item()
	{
	}
	public Item(GameObject inventorySlotObject)
	{
		gameObject = Object.Instantiate(GameObject.Find("ItemObject"));
		gameObject.GetComponent<Transform>().SetParent (inventorySlotObject.GetComponent<Transform>());
	}
	// Use this for initialization
	public GameObject getGameObject()
	{
		return gameObject;
	}

}
