using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {
    public bool isStabbing;
    private int ticksSinceStart;
	// Use this for initialization
	void Start () {
        isStabbing = false;
        ticksSinceStart = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1)&&!isStabbing)
        {
            isStabbing = true;
            ticksSinceStart = 0;
        }
        if(isStabbing)
        {
            if (ticksSinceStart < 20)
            {
                transform.Rotate(3, 0, 0);
            }
            else if (ticksSinceStart >= 20 && ticksSinceStart < 40)
            {
                transform.Rotate(-3, 0, 0);
            }
            else
            {
                isStabbing = false;
            }
            ticksSinceStart++;
        }
    
	}

}
