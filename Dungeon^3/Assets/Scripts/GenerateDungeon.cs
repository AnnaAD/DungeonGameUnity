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

	private int counter;

	//X++ is north
	//X-- is south
	//Z++ is west
	//Z-- is east

	void Start () {
		counter = 0;
		Generate();
	}
	
	void Generate() {
		generateRoom(0,0,1f);
	}

	//Recursive function that generates a room and calls generate room for each side that needs to be generated!
	private void generateRoom(float x, float z, float fade) {
		

		float branchFactor = Random.value;

		GameObject room = Instantiate(rFourDoor, new Vector3(x, 0f, z), Quaternion.identity) as GameObject;
		room.name = "Room" + counter;

		if(Random.value < 0.2 * fade + branchFactor) {
			counter++;
			generateRoom(x + 10, z, fade * fadeMultiplier);
			if(counter > maxRooms) {
				return;
			}
		}
		if(Random.value < 0.2 * fade + branchFactor) {
			counter++;
			generateRoom(x - 10, z, fade * fadeMultiplier);
			if(counter > maxRooms) {
				return;
			}
		}
		if(Random.value < 0.2 * fade + branchFactor) {
			counter++;
			generateRoom(x, z+10, fade * fadeMultiplier);
			if(counter > maxRooms) {
				return;
			}
		}
		if(Random.value < 0.2 * fade + branchFactor) {
			counter++;
			generateRoom( x, z-10, fade * fadeMultiplier);
			if(counter > maxRooms) {
				return;
			}
		}
	}
}


