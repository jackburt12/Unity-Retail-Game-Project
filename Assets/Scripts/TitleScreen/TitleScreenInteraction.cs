using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenInteraction : MonoBehaviour {

	private GameObject title, pressToPlay;
	private bool introComplete = false;
	private bool keyPressed = false;

	// Use this for initialization
	void Start () {

		title = GameObject.Find ("Title");
		pressToPlay = GameObject.Find ("PressToPlay");

		StartCoroutine ("CameraZoom");
		StartCoroutine ("CameraMove");

		title.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0f);
		pressToPlay.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0f);

	}
	
	// Update is called once per frame
	void Update () {

		if(Camera.main.transform.position.y <= 0.01 && keyPressed == false) {
			if(pressToPlay.GetComponent<SpriteRenderer> ().color == new Color(1,1,1,0f)) {
				StartCoroutine ("FadeIn");
			} else if (pressToPlay.GetComponent<SpriteRenderer> ().color == new Color(1,1,1,1f)) {
				StartCoroutine ("FadeOut");
			}

			StartCoroutine ("TitleIn");

			introComplete = true;
		}

		if (introComplete == true) {

			if (Input.anyKeyDown) {

				StopCoroutine ("TitleIn");
				StopCoroutine ("FadeIn");
				StartCoroutine ("TitleOut");
				StartCoroutine ("FadeOut");

				keyPressed = true;

				StartCharacterCreation ();

			}


		}


	}

	IEnumerator CameraZoom() {

		for (float f = 4.147793f; f <= 5f; f += 0.003f) {
			Camera.main.orthographicSize = f;
			yield return null;
		}
	}

	IEnumerator CameraMove() {

		for (float f = 0.9f; f >= 0f; f -= 0.0031f) {
			Camera.main.transform.position= new Vector3(transform.position.x, f, transform.position.z);
			yield return null;
		}
	}

	IEnumerator TitleIn() {

		for (float f = 0.0f; f <= 1f; f += 0.05f) {
			Color c = new Color (1, 1, 1, 1);
			c.a = f;
			title.GetComponent<SpriteRenderer> ().color = c;
			yield return null;
		}


	}

	IEnumerator TitleOut() {

		for (float f = 0.0f; f >= 0f; f -= 0.02f) {
			Color c = new Color (1, 1, 1, 1);
			c.a = f;
			title.GetComponent<SpriteRenderer> ().color = c;
			yield return null;
		}

	}

	IEnumerator FadeOut() {

		for (float f = 1f; f >= 0f; f -= 0.02f) {
			Color c = new Color (1, 1, 1, 1);
			c.a = f;
			pressToPlay.GetComponent<SpriteRenderer> ().color = c;
			yield return null;
		}

	}

	IEnumerator FadeIn() {

		for (float f = 0f; f <= 1f; f += 0.02f) {
			Color c = new Color (1, 1, 1, 1);
			c.a = f;
			pressToPlay.GetComponent<SpriteRenderer> ().color = c;
			yield return null;
		}
	}

	public void StartCharacterCreation() {

		SceneManager.LoadScene ("CharacterCreation");

	}
}
