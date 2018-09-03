using UnityEngine;
using System.Collections;
public class Inventory : MonoBehaviour {
	public GameObject[] slots = new GameObject[12];
	public Item[] items;
	private bool down;
	private int slotDragged;
	private Transform startParent;
	private GameObject player;
    [SerializeField] private Animator buttonAnimator;

	// Use this for initialization
	void Start () {
        
        player = GameObject.Find("Player");
		//Debug.Log(player);
		slotDragged = -1;
		//slots = new GameObject[12];
		/*for (int i = 1; i <= slots.Length; i++) {
			slots [i-1] = GameObject.Find ("Slot (" + i+ ")");
			Debug.Log(GameObject.Find("Slot (" + i+ ")"));
			Debug.Log(slots[i-1]);
		}*/

		items = new Item[12];
        //Debug.Log(items [0].damage);		
        items[0] = new Sword(0, slots[0]);
		items [1] = new Bow (0, slots [1]);
		AdjustSword ();
	}

	void OnLevelWasLoaded() {
        player = GameObject.Find("Player");
        // Prevents an error of this running before start
        if (items.Length > 0)
        {
            AdjustSword();
        }
	}

	// Update is called once per frame
	void Update () {
		HandleDragging ();
		//print (GetSword ().GetDamage());

	}
	//Checks all the slots to see if the object is within maxDistance of them.
    // Returns 0-11 for a slot, -1 for no slot, or -2 to drop the item
	private int CheckSlots(GameObject item, int maxDistance)
	{
        Transform itemTransform = item.GetComponent<Transform>();
        for (int i = 0; i < slots.Length; i++) {
			Transform slotTransform = slots [i].GetComponent<Transform> ();
			if (Mathf.Abs (slotTransform.position.x - itemTransform.position.x) < maxDistance && Mathf.Abs (slotTransform.position.y - itemTransform.position.y) < maxDistance) {
				return(i);
			}
		}
        if (Vector3.Distance(itemTransform.position, slots[0].GetComponent<Transform>().position) > 150)  {
            // When the item is so far away it should be dropped
            return -2;
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
            if (slot >= 0 
            && ((slot != 0 || items[slotDragged].GetType() == typeof(Sword)) && (slotDragged != 0 || (items[slot] == null || items[slot].GetType() == typeof(Sword))))
            && ((slot != 1 || items[slotDragged].GetType() == typeof(Bow)) && (slotDragged != 1 || (items[slot] == null || items[slot].GetType() == typeof(Bow))))
            && ((slot != 2 || items[slotDragged].GetType() == typeof(Armor)) && (slotDragged != 2 || (items[slot] == null || items[slot].GetType() == typeof(Armor))))) {
                SwitchItems(slotDragged, slot);
            } else if (slot == -2 && items[slotDragged].GetType() == typeof(Sword)) {
                Debug.Log("Item dropped far away from first slot");
                Debug.Log("SlotDragged " + slotDragged + " + items[slotDragged] " + items[slotDragged] + " prefab " + items[slotDragged].GetDropPrefab());
                Instantiate(items[slotDragged].GetDropPrefab() as GameObject, player.GetComponent<Transform>().position, Quaternion.identity);
                Destroy(items[slotDragged].gameObject);
                items[slotDragged] = null;
                AdjustSword();
            } else  {
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
	public void SwitchItems(int item1,int item2) {
		items [item1].gameObject.GetComponent<Transform> ().SetParent (slots [item2].GetComponent<Transform> (), false);
        // Switches the items within the array
		Item temp = items [item2];
		items [item2] = items [item1];
		items [item1] = temp;
        // All items are children of the slots they're in. This updates that to match.
		if (items [item1] != null) {
			items [item1].gameObject.GetComponent<Transform> ().SetParent (slots [item1].GetComponent<Transform> (), false);
		}
		items [item2].gameObject.GetComponent<Transform> ().localPosition = new Vector2 (0f, 0f);
        // If the items are swords, updates the player's sword model
		if (item1 == 0 || item2 == 0) {
			AdjustSword ();
		}
	}

    // Adds item to inventory
    public void AddItem(int itemID, string type) {
        // Iterates through last 8 inventory spaces
        for (int i = 4; i < items.Length; i++) {
            // Open Space
            if(items[i] == null) {
                buttonAnimator.SetTrigger("StartAnimationTrigger");
                if(type == "sword") {
                    items[i] = new Sword(itemID, slots[i]);
                    return;
                }
            }
        }
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


    //Updates the player's sword model to match the one equipped
	public void AdjustSword() {
		//Debug.Log (player.transform.GetChild (0) );
		if(player.transform.GetChild(0).GetChild(0).childCount > 0) {
			Destroy(player.transform.GetChild(0).GetChild(0).GetChild(0).gameObject);
		}
		if(GetSword()!=null){
			GameObject sword=Instantiate(GetSword().GetPrefab(),player.transform.GetChild(0).GetChild(0)) as GameObject;
			sword.transform.localPosition = new Vector3 (0f, 0f, 0f);
			sword.transform.localRotation = Quaternion.Euler (0f, 0f, 0f);
		}
	}
}
