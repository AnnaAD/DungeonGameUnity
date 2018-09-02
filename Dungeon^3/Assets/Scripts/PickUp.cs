using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    [SerializeField] private int itemID;
    [SerializeField] private string itemType;
    private GameObject player;
    [SerializeField] private GameObject keyText;
    [SerializeField] private float pickupRange;
    private Inventory inventory;
    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player");
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log(Vector3.Distance(player.transform.position, transform.position));
        if (Vector3.Distance(player.transform.position, transform.position) < pickupRange) {
            //Debug.Log("set active");
            keyText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) {
                inventory.AddItem(itemID, itemType);
                Destroy(this.gameObject);
            }
        } else {
            keyText.SetActive(false);
        }

       

        //Debug.Log(keyText.active);
    }
}
