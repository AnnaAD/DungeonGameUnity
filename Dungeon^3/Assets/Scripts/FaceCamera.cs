using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		Vector3 cam = Camera.main.transform.position;
		transform.LookAt(new Vector3(cam.z, cam.y, cam.z));
		transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
	}
}
