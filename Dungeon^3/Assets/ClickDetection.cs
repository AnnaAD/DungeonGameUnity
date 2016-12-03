using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class ClickDetection : MonoBehaviour,IPointerDownHandler, IPointerUpHandler {
	public bool isDown;
	// Use this for initialization
	void Start () {
		isDown = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		isDown = true;
	}

	public void OnPointerUp(PointerEventData eventData){
		isDown = false;
	}

}
