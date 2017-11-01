using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

	private bool isOpen = false;
	private float speed = 0.05f;

	private GameObject leftDoor;
	private GameObject rightDoor;

	// Use this for initialization
	void Start () {
	
		leftDoor = GameObject.Find ("InnerDoorLeft");
		rightDoor = GameObject.Find ("InnerDoorRight");

	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator OpenDoors() {

		isOpen = true;
		
		while (leftDoor.transform.position.x > -0.8) {
			leftDoor.transform.Translate (Vector2.left * speed);

			rightDoor.transform.Translate (Vector2.right * speed);


			yield return null;
		}

	}

	IEnumerator CloseDoors() {

		isOpen = false;

		while (leftDoor.transform.position.x < -0.05) {
			leftDoor.transform.Translate (Vector2.right * speed);

			rightDoor.transform.Translate (Vector2.left * speed);

			yield return null;
		}

	}

	void OnTriggerStay2D (Collider2D other) {
		StopCoroutine ("CloseDoors");
		StartCoroutine ("OpenDoors");
	}

	void OnTriggerExit2D (Collider2D other) {
		StopCoroutine ("OpenDoors");
		StartCoroutine ("CloseDoors");
	}

}
