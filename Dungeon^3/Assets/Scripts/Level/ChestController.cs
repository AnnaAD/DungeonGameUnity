using UnityEngine;
using System.Collections;

public class ChestController : MonoBehaviour {

	Animator animator;
	private bool chestOpen;
    [SerializeField] private float chestRange;
	[SerializeField] private GameObject player;
    [SerializeField] private GameObject keyText;
    [SerializeField] private float chestLevel;

    private bool opened;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		chestOpen = false;
		player = GameObject.Find("Player");
        opened = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(player.transform.position,transform.position) < chestRange) {
			keyText.SetActive(true);
			if(Input.GetKeyDown(KeyCode.E)) {
				if(chestOpen == false) {
					animator.SetTrigger("Open");
					Debug.Log("trying to open");
					chestOpen = true;
                    if (!opened) {
                        Vector3 dropPosition = transform.position + transform.forward.normalized*-1;
                        DropManager.MakeDrop(dropPosition, chestLevel,true);
                    }
                    opened = true;
				} else {
					animator.SetTrigger("Close");
					Debug.Log("trying to close");
					chestOpen = false;
				}
			}
		} else {
			keyText.SetActive(false);
		}
	}
}
