using UnityEngine;
using System.Collections;

// Class dedicated to making the buttons on the inventory and stat windows work
// Should be attached to a class containing all elements of a UI Window like Stats and Inventory (both under Canvas)
// Use by putting in the action attribute of button
public class PopupManager : MonoBehaviour {
	public bool windowOpen;
    [SerializeField] Animator buttonAnimator;
    public void Start(){
		windowOpen = true;
        //In scene, window is open, this makes it closed at the start of game
		toggleWindow ();
	}

	public void toggleWindow()
	{	//Slides entire object up or down just enough to hide only button or all but button
		if(windowOpen){
            //Closes Window
            this.GetComponent<Transform>().Translate( new Vector3 (0f, -174.4f, 0f));
			windowOpen = false;
            buttonAnimator.SetBool("EndAnimationBoolean", false);
        } else {
            // Opens Window
			this.GetComponent<Transform>().Translate(new Vector3 (0f, 174.4f, 0f));
			windowOpen = true;
            // Ends animation for a new item or stat in the button
           buttonAnimator.SetBool("EndAnimationBoolean", true);
        }

	}

}
