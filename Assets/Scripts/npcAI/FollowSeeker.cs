using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSeeker : MonoBehaviour {

	private GameObject player;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Test Seeker");
	}
	
	// Update is called once per frame
	void LateUpdate () {

		transform.position = (player.transform.position);

	}
}
