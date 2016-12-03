using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Sword : Equipment {
	public float damage;
	public static Sprite[] sprites; 
	public static float[] damages;
	// Use this for initialization
	public Sword (int tier,GameObject inventorySlotObject) : base(tier,inventorySlotObject) {
		
		gameObject.GetComponent<Image> ().sprite = sprites [tier];//Resources.Load<Sprite>("Images/Swords/TestSword");
		damage=damages[tier];


	}
	public void OnEnable()
	{
		sprites = Resources.LoadAll<Sprite>("Images/Swords");
		damages = new float[] {1f,2f};
	}

}

public class Bow : Equipment {
	public float damage;
	public static Sprite[] sprites; 
	public static float[] damages;
	// Use this for initialization
	public Bow (int tier,GameObject inventorySlotObject) : base(tier,inventorySlotObject) {

		gameObject.GetComponent<Image> ().sprite = sprites [tier];//Resources.Load<Sprite>("Images/Swords/TestSword");
		damage=damages[tier];


	}
	public void OnEnable()
	{
		sprites = Resources.LoadAll<Sprite>("Images/Bows");
		damages = new float[] {};
	}

}

public class Armor : Equipment {
	public float protection;
	public static Sprite[] sprites; 
	public static float[] protections;
	// Use this for initialization
	public Armor (int tier,GameObject inventorySlotObject) : base(tier,inventorySlotObject) {

		gameObject.GetComponent<Image> ().sprite = sprites [tier];//Resources.Load<Sprite>("Images/Swords/TestSword");
		protection=protections[tier];


	}
	public void OnEnable()
	{
		sprites = Resources.LoadAll<Sprite>("Images/Armors");
		protections = new float[] {};
	}

}