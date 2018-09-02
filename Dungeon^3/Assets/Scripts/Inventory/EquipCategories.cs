using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Sword : Equipment {
	new public float damage;
    new public string type;
    new public GameObject prefab;

    //These arrays represent the images in the Images/Swords folder and the damages corresponding to each sword
    //The indices represent a specific type of sword, when adding new swords make sure to 
    //add the location and the damage at the same location
    public static string [] spriteLocations = new string[] {"sword","gemSword","hammer","gemHammer"};
    public static float[] damages = damages = new float[] { 5f, 6f, 6f, 10f };
    public static string[] prefabs = new string[] { "sword", "gemSword", "hammer", "gemHammer" };


	// Use this for initialization
	public Sword (int tier,GameObject inventorySlotObject) : base(tier,inventorySlotObject) {
		
		gameObject.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Images/Swords/"+spriteLocations[tier]);
		damage=damages[tier];
		type = "sword";
		prefab = Resources.Load("Prefabs/Weapons/Swords/" + prefabs[tier]) as GameObject;
		Debug.Log(prefab);
		Debug.Log ("Prefabs/Weapons/Swords/" + prefabs [tier]);
	}

	public override float GetDamage(){
		return damage;
	}

	public override GameObject GetPrefab(){
		return prefab;
	}

    public static ArrayList GetSwords() {
        ArrayList output = new ArrayList();
        for (int i = 0; i < prefabs.Length; i++) {
            output.Add(Resources.Load("Prefabs/Weapons/Pickups/" + spriteLocations[i]+"Pickup"));
        }
        return output;
    }

}

public class Bow : Equipment {
	new public float damage;
	public static string[] spriteLocations;
	public static float[] damages;
	public string[] prefab;
	// Use this for initialization
	new public string type;
	public Bow (int tier,GameObject inventorySlotObject) : base(tier,inventorySlotObject) {

		gameObject.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/Bows/"+spriteLocations [tier]);
		damage=damages[tier];
		type = "bow";

	}
	public void OnEnable()
	{
		spriteLocations = new string[]{ "bow" };
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
	public string[] prefab;

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