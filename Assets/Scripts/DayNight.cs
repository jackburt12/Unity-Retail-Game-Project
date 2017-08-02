using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {

	private string season = "Winter";
	private GameObject clock;

	// Use this for initialization
	void Start () {
		clock = GameObject.Find ("GameTime");

		Color c = new Color (1, 1, 1, 1);
		float f = 0.25f;
		c.r = f * 1.5f;
		c.g = f * 1.5f;
		c.b = f * 2f;
		GetComponent<SpriteRenderer> ().color = c;


	}

	
	// Update is called once per frame
	void Update () {
	
	//	decideBrightness ();
			

	}
		

	IEnumerator ToDark() {

		for (float f = 1f; f >= 0.25; f -= 0.0005f) {
			Color c = new Color (1, 1, 1, 1);
			c.r = f * 1.5f;
			c.g = f * 1.5f;
			c.b = f * 2f;
			GetComponent<SpriteRenderer> ().color = c;
			yield return null;

		}

	}

	IEnumerator ToLight() {
		
		for (float f = 0.25f; f <= 1; f += 0.0005f) {
			Color c = new Color (1, 1, 1, 1);
			c.r = f * 1.5f;
			c.g = f * 1.5f;
			c.b = f * 2f;
			GetComponent<SpriteRenderer> ().color = c;
			yield return null;
		}
	}
	/*
	public void decideBrightness() {

		if (season.Equals ("Spring")) {

			if (clock.GetComponent<GameTime> ().hours == 6) {
				StopCoroutine ("ToDark");
				StartCoroutine ("ToLight");
			}
			if (clock.GetComponent<GameTime> ().hours == 19) {
				StopCoroutine ("ToLight");
				StartCoroutine ("ToDark");
			}

		} else if (season.Equals ("Summer")) {

			if (clock.GetComponent<GameTime> ().hours == 5) {
				StopCoroutine ("ToDark");
				StartCoroutine ("ToLight");
			}
			if (clock.GetComponent<GameTime> ().hours == 20) {
				StopCoroutine ("ToLight");
				StartCoroutine ("ToDark");
			}

		} else if (season.Equals ("Autumn")) {

			if (clock.GetComponent<GameTime> ().hours == 6) {
				StopCoroutine ("ToDark");
				StartCoroutine ("ToLight");
			}
			if (clock.GetComponent<GameTime> ().hours == 19) {
				StopCoroutine ("ToLight");
				StartCoroutine ("ToDark");
			}

		} else if (season.Equals ("Winter")) {

			if (clock.GetComponent<GameTime> ().hours == 8) {
				StopCoroutine ("ToDark");
				StartCoroutine ("ToLight");
			}
			if (clock.GetComponent<GameTime> ().hours == 17) {
				StopCoroutine ("ToLight");
				StartCoroutine ("ToDark");
			}

		}

	} */
}
