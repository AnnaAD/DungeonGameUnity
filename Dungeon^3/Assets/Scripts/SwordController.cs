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
            if (ticksSinceStart <= 10)
            {
                transform.Rotate(6, 0, 0);
                //transform.Translate(new Vector3(0f,0f,.02f),Space.Player);
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + .03f);
            }
            else if (ticksSinceStart > 10 && ticksSinceStart <= 21)
            {
                transform.Rotate(-6, 0, 0);
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - .03f);
            }
            else
            {
                isStabbing = false;
            }
            ticksSinceStart++;
        }
    
	}

}
