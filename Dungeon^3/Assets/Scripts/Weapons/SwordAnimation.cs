using UnityEngine;
using System.Collections;

public class SwordAnimation : MonoBehaviour {
	

	
	 public void Swing(){
	 if (Input.GetMouseButtonDown(1))
     {
         GetComponent<Animator>().SetTrigger("RightClick");
     }
	}
	 
	
}
