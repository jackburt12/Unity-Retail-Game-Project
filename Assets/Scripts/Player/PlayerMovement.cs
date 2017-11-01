using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public bool canMove = true;

    private float speed = 0.04f;
	private bool leftBoundReached, rightBoundReached, topBoundReached, bottomBoundReached;

	void Update () {

		if (canMove) {

			if (transform.position.x >= 7.6f) {
				rightBoundReached = true;
			} else {
				rightBoundReached = false;
			}

			if (transform.position.x <= -7.6f) {
				leftBoundReached = true;
			} else {
				leftBoundReached = false;
			}

			if (transform.position.y >= 5.1f) {
				topBoundReached = true;
			} else {
				topBoundReached = false;
			}

			if (transform.position.y <= -3.55f) {
				bottomBoundReached = true;
			} else {
				bottomBoundReached = false;
			}


			if (Input.GetKey (KeyCode.D) && !rightBoundReached) { 
				transform.Translate (Vector2.right * speed);
			}

			if (Input.GetKey (KeyCode.A) && !leftBoundReached) {
				transform.Translate (-Vector2.right * speed);
			}

			if (Input.GetKey (KeyCode.W) && !topBoundReached) {
				transform.Translate (Vector2.up * speed);
			}

			if (Input.GetKey (KeyCode.S) && !bottomBoundReached) {
				transform.Translate (-Vector2.up * speed);
			}
		}
	    
        GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -10);
	}
}
