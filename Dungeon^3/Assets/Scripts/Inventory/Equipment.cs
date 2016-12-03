using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Equipment : Item {
	private bool isEquipped;
	public int tier;
	public Equipment(int tier,GameObject inventorySlotObject)
	{
		this.tier = tier;
		gameObject = Object.Instantiate(Resources.Load<GameObject>("prefabs/ItemObject"));
		gameObject.GetComponent<Transform>().SetParent (inventorySlotObject.GetComponent<Transform>());
		gameObject.GetComponent<Transform> ().localPosition = new Vector3 (0f, 0f, 0f);

	}

}
