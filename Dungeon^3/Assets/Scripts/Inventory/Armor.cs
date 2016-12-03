using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Armor : Equipment {
	public float protection;
	public static Sprite[] sprites; 
	// Use this for initialization
	public Armor (int tier,GameObject inventorySlotObject) : base(tier,inventorySlotObject) {
		
		gameObject.GetComponent<Image>().sprite=Resources.Load<Sprite>("Images/TestSword");


	}
}
