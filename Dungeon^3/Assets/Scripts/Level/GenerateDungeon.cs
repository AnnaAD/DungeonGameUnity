using UnityEngine;
using System.Collections;

public class GenerateDungeon : MonoBehaviour {

	public GameObject rOneDoor;
	public GameObject rTwoOppDoor;
	public GameObject rTwoAdjDoor;
	public GameObject rThreeDoor;
	public GameObject rFourDoor;
	public GameObject hall;

	public int maxRooms;
	public float fadeMultiplier;


	//X++ is north
	//X-- is south
	//Z++ is west
	//Z-- is east

	void Start () {
		Generate();
	}
	
	void Generate() {
		Instantiate(rFourDoor, new Vector3(0,0,0), Quaternion.identity);
		generateRoom(0, 10, Quaternion.identity);
		generateRoom(0, -10, Quaternion.Euler(new Vector3(0,180,0)));
		generateRoom(10, 0, Quaternion.Euler(new Vector3(0,90,0)));
		generateRoom(-10, 0, Quaternion.Euler(new Vector3(0,-90,0)));

	}

	//Recursive function that generates a room and calls generate room for each side that needs to be generated!
	private void generateRoom(float x, float z, Quaternion rotation) {

		int roomType = Mathf.RoundToInt(Random.value * 5);
		if (roomType == 0) {
			Instantiate(rOneDoor, new Vector3(x,0,z), rotation);
		} else if (roomType == 1) {
			Instantiate(rTwoOppDoor, new Vector3(x,0,z), rotation);
			generateRoom(-10, 0, Quaternion.identity);
			generateRoom(-10, 0, Quaternion.identity);
		} else if(roomType == 2) {
			//Instantiate(rTwoAdjDoor, new Vector3(x,0,z), rotation);
			//generateRoom(-10, 0, Quaternion.identity);
			//generateRoom(-10, 0, Quaternion.identity);
		} else if (roomType == 3) {
			Instantiate(rThreeDoor, new Vector3(x,0,z), rotation);
			generateRoom(-10, 0, Quaternion.identity);
			generateRoom(-10, 0, Quaternion.identity);
		} else {
			Instantiate(rFourDoor, new Vector3(x,0,z), rotation);
			generateRoom(-10, 0, Quaternion.identity);
			generateRoom(-10, 0, Quaternion.identity);
		}
	}

}


