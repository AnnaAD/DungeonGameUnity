﻿using UnityEngine;
using System.Collections;

public class Item : ScriptableObject {
	public GameObject gameObject;
	public string type;
	public float damage;

	public Item()
	{
		type = "item";
		damage = 5f;
	}
	public Item(GameObject inventorySlotObject)
	{
		
		gameObject = Object.Instantiate(Resources.Load<GameObject>("prefabs/ItemObject"));
		gameObject.GetComponent<Transform>().SetParent (inventorySlotObject.GetComponent<Transform>());
		gameObject.GetComponent<Transform> ().localPosition = new Vector3 (0f, 0f, 0f);
	}

	public GameObject getGameObject()
	{
		return gameObject;
	}

	public virtual float GetDamage()
	{	
		return 0;
	}
}
