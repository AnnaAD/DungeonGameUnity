using UnityEngine;
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
		items [1] = new Bow (0, slots [1]);
	}
	
	// Update is called once per frame
	void Update () {

		if (slotDragged!=-1&&slots [slotDragged].GetComponent<ClickDetection> ().isDown) {
			items [slotDragged].gameObject.GetComponent<Transform> ().position = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		} else if (slotDragged!=-1&&!slots [slotDragged].GetComponent<ClickDetection> ().isDown) {
			int slot = checkSlots (items [slotDragged].gameObject, 20);
			if (slot != -1) {
				items [slotDragged].gameObject.GetComponent<Transform> ().SetParent(slots [slot].GetComponent<Transform> (),false);
				Item temp = items [slot];
				items [slot] = items [slotDragged];
				items [slotDragged] = temp;
				if(items[slotDragged]!=null){
					items [slotDragged].gameObject.GetComponent<Transform> ().SetParent(slots [slotDragged].GetComponent<Transform> (),false);
				}
				items [slot].gameObject.GetComponent<Transform> ().localPosition = new Vector2 (0f, 0f);
			} else {
				items [slotDragged].gameObject.GetComponent<Transform>().SetParent(slots[slotDragged].GetComponent<Transform>(),false);
				items [slotDragged].gameObject.GetComponent<Transform> ().localPosition = new Vector2 (0f, 0f);
			}
			slotDragged = -1;
		}else{
			for(int i=0;i<slots.Length;i++)
			{
				if (items[i]!=null&&slots [i].GetComponent<ClickDetection> ().isDown) {
					slotDragged = i;
					items [slotDragged].gameObject.GetComponent<Transform> ().SetParent (GameObject.Find ("Canvas").GetComponent<Transform> (), true);
					return;
				}

			}
		}
	}

	private int checkSlots(GameObject item,int maxDistance)
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
}
