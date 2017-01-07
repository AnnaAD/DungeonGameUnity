using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Sword : Equipment {
	new public float damage;
	public static string [] spriteLocations;
	public static float[] damages;
	new public string type;
	// Use this for initialization
	public Sword (int tier,GameObject inventorySlotObject) : base(tier,inventorySlotObject) {
		
		gameObject.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Images/Swords/"+spriteLocations[tier]);
		damage=damages[tier];
		type = "sword";
	}
	public void OnEnable()
	{
		//These arrays represent the images in the Images/Swords folder and the damages corresponding to each sword
		//The indices represent a specific type of sword, when adding new swords make sure to 
		//add the location and the damage at the same location
		spriteLocations=new string[] {"sword","TestSword"}; 
		damages = new float[] {5f,6f};
	}

	public override float GetDamage(){
		return damage;
	}

}

public class Bow : Equipment {
	new public float damage;
	public static string[] spriteLocations;
	public static float[] damages;
	// Use this for initialization
	new public string type;
	public Bow (int tier,GameObject inventorySlotObject) : base(tier,inventorySlotObject) {

		gameObject.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Bows/"+spriteLocations [tier]);
		damage=damages[tier];
		type = "bow";

	}
	public void OnEnable()
	{
		spriteLocations = new string[]{ "testbow1" };
		damages = new float[] {1f};
	}

	public override float GetDamage()
	{
		return damage;
	}
}

public class Armor : Equipment {
	public float protection;
	public static string[] spriteLocations; 
	public static float[] protections;
	// Use this for initialization
	public Armor (int tier,GameObject inventorySlotObject) : base(tier,inventorySlotObject) {

		gameObject.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Armors/" + spriteLocations [tier]);
		protection=protections[tier];


	}
	public void OnEnable()
	{

		protections = new float[] {};
		spriteLocations = new string[]{ };
	}

}