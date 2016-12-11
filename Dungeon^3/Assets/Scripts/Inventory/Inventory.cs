﻿using UnityEngine;
using System.Collections;
public class Inventory : MonoBehaviour {
	public GameObject[] slots;
	public Item[] items;
	private bool down;
	private int slotDragged;
	private Transform startParent;
	// Use this for initialization
	void Start () {
		slotDragged = -1;

		slots = new GameObject[12];
		for (int i = 1; i <= slots.Length; i++) {
			slots [i-1] = GameObject.Find ("Slot (" + i+ ")");
		}
		items = new Item[12];
		items[0] = new Sword (0, slots [0]);
		Debug.Log(items [0].damage);		
		items [1] = new Bow (0, slots [1]);
	}

	// Update is called once per frame
	void Update () {
		HandleDragging ();


	}
	//Checks all the slots to see if the object is within maxDistance of them.
	private int CheckSlots(GameObject item,int maxDistance)
	{
		for (int i = 0; i < slots.Length; i++) {
			Transform trans1 = slots [i].GetComponent<Transform> ();
			Transform trans2 = item.GetComponent<Transform> ();
			if (Mathf.Abs (trans1.position.x - trans2.position.x) < maxDistance && Mathf.Abs (trans1.position.y - trans2.position.y) < maxDistance) {
				return(i);
			}
		}
		return -1;
	}

	private void HandleDragging()
	{
		//There are 3 cases,when the item is being dragged, when the item being dragged is just released, when no item is being dragged
		if (slotDragged != -1 && slots [slotDragged].GetComponent<ClickDetection> ().isDown) {
			//Sets item to mouse position
			items [slotDragged].gameObject.GetComponent<Transform> ().position = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		} else if (slotDragged != -1 ) {
			//slot is the slot the item is being dragged into, 0-11 or -1 for no slot
			int slot = CheckSlots (items [slotDragged].gameObject, 20);
			//Checks to see if it is being dragged into a valid slot
			if (slot != -1 
			&&((slot!=0||items[slotDragged].GetType()==typeof(Sword) )&&(slotDragged!=0||(items[slot]==null||items[slot].GetType()==typeof(Sword) )))
			&&((slot!=1||items[slotDragged].GetType()==typeof(Bow) )&&(slotDragged!=1||(items[slot]==null||items[slot].GetType()==typeof(Bow))))
			&&((slot!=2||items[slotDragged].GetType()==typeof(Armor) )&&(slotDragged!=2||(items[slot]==null||items[slot].GetType()==typeof(Armor))))) {
				SwitchItems (slotDragged, slot);
			} else {
				//Puts the item back in the original slot
				items [slotDragged].gameObject.GetComponent<Transform> ().SetParent (slots [slotDragged].GetComponent<Transform> (), false);
				items [slotDragged].gameObject.GetComponent<Transform> ().localPosition = new Vector2 (0f, 0f);
			}
			slotDragged = -1;
		} else {
			//searches through the slots array to see if any slot is being clicked on
			for (int i = 0; i < slots.Length; i++) {
				if (items [i] != null && slots [i].GetComponent<ClickDetection> ().isDown) {
					slotDragged = i;
					items [slotDragged].gameObject.GetComponent<Transform> ().SetParent (GameObject.Find ("Canvas").GetComponent<Transform> (), true);
				}

			}
		}
	}
	//Switches the two items at indices item1 item2
	public void SwitchItems(int item1,int item2)
	{
		items [item1].gameObject.GetComponent<Transform> ().SetParent (slots [item2].GetComponent<Transform> (), false);
		Item temp = items [item2];
		items [item2] = items [item1];
		items [item1] = temp;
		if (items [item1] != null) {
			items [item1].gameObject.GetComponent<Transform> ().SetParent (slots [item1].GetComponent<Transform> (), false);
		}
		items [item2].gameObject.GetComponent<Transform> ().localPosition = new Vector2 (0f, 0f);
	}

	public Item GetSword(){
		return items [0];
	}

	public Item GetBow(){
		return items [1];
	}

	public Item GetArmor(){
		return items [2];
	}
}
