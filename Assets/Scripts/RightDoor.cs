using UnityEngine;
using System.Collections;

public class RightDoor : MonoBehaviour {

	private bool isOpen = false;
	private float speed;

	// Use this for initialization
	void Start () {
	
		speed = 0.1f;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.O)) {
			if (isOpen == false) {
				//isOpen = true;
				if (transform.position.x < 0.8) {
					transform.Translate (Vector2.right * speed);
				} else {
					isOpen = true;
				}

			} else {
				//isOpen = false;

				if (transform.position.x > 0) {
					transform.Translate (Vector2.left * speed);
				} else {
					isOpen = false;
				}
			}

		}

	}
}
