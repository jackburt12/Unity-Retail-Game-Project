using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour {

	private float speed = 0.004f;

	// Use this for initialization
	void Start (){

		transform.position = new Vector3 (0, -9, 0);

	}

	// Update is called once per frame
	void Update () {
		
		while (transform.position.y < 0) {
			MoveUp ();
		}

		GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -10);

	}

	void MoveUp() {
		transform.Translate(Vector2.up * speed);

	}
}
