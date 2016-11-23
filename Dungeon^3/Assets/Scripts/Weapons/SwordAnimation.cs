using UnityEngine;
using System.Collections;

public class SwordAnimation : MonoBehaviour {
	

	
	 void Update(){
	 if (Input.GetMouseButtonDown(1))
     {
         GetComponent<Animator>().SetTrigger("RightClick");
     }
	}
	 
	
}
