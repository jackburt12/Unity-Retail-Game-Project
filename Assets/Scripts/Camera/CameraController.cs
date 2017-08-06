using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private GameObject camera;
	private Vector3 offset;

	// Use this for initialization
	void Start () {

		camera = GameObject.Find ("Main Camera");

		camera.GetComponent<Camera> ().orthographicSize = 5.5f;
		camera.transform.position = new Vector3 (0, 0, -10);
	
		offset = camera.transform.position - gameObject.transform.position;
		offset.y = offset.y -10;

	}
	
	// Update is called once per frame
	void LateUpdate () {

		camera.transform.position = (gameObject.transform.position + offset)/4f;

	}
}
