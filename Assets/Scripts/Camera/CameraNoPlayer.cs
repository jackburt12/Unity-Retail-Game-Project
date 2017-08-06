using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNoPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if(GameObject.Find("Player(Clone)") != null) {

			gameObject.GetComponent<Camera> ().orthographicSize = 8f;
			gameObject.transform.position = new Vector3 (2, 0);

		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
