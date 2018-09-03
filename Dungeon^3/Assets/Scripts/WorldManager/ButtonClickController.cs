using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickController : MonoBehaviour {

    public void OnPauseClick() {
        GameObject.Find("WorldManager").GetComponent<UImanager>().TogglePause();
    }
}
