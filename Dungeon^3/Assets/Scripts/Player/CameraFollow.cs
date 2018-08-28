using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;       

	//x = -20, y = 24, z = 20
	private Vector3 offset = new Vector3 (-20, 24,20);       

	void Start () {
		player = GameObject.Find("Player");
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}