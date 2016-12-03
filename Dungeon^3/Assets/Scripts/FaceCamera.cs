using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		Vector3 cam = Camera.main.transform.position;
		transform.LookAt(new Vector3(0, cam.y, 0));
		transform.rotation.Set(transform.rotation.x + 90, transform.rotation.y + 180, transform.rotation.z, transform.rotation.w+ 90);
	}
}
