using UnityEngine;
using System.Collections;

public class SwordAnimation : MonoBehaviour {
	

	public bool isSwinging;
	public void Start()
	{
		isSwinging = false;
	}
	 public void Swing(){
	 if (Input.GetMouseButtonDown(1))
     {
         GetComponent<Animator>().SetTrigger("RightClick");
     }
	}

	public void toggleIsSwinging()
	{
		if (isSwinging) {
			isSwinging = false;
		} else {
			isSwinging = true;
		}
	}
	 
	
}
