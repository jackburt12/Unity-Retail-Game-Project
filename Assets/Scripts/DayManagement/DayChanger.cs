using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayChanger : MonoBehaviour {

	GameObject blackPanel;
	GameObject text;
	GameTime gameTime;
	public AudioClip keySound; 
	AudioSource audio;

	public bool dayStarted = false;

	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource> ();

		blackPanel = GameObject.Find ("BlackPanel");
		text = GameObject.Find ("DayNumber");
		gameTime = GameObject.Find ("GameTime").GetComponent<GameTime>();

		text.GetComponent<Text> ().text = "";

		StartCoroutine ("FadeOut");

	}
	
	// Update is called once per frame
	void Update () {

		if (!dayStarted) {

			switch (gameTime.day) {
			case 0:
			//Prologue p = new Prologue ();
				gameObject.GetComponent<Prologue> ().StartDay ();

				dayStarted = true;
				break;

			case 1:

				gameObject.GetComponent<Day1> ().StartDay ();

				dayStarted = true;
				break;
			}
		}
	}


	IEnumerator FadeIn() {

		gameTime.day++;

		string textString;

		if (gameTime.day == 0) {
			textString = "";
		} else if (gameTime.day == 1) {
			textString = "Prologue";
		} else {
			textString = "Day " + (gameTime.day - 1).ToString ();
		}

		text.GetComponent<Text> ().text = textString;

		for (float f = 0f; f <= 1; f += 0.01f) {
			Color textColour = text.GetComponent<Text> ().color;
			Color panelColour = blackPanel.GetComponent<Image> ().color;
			textColour.a = f;
			panelColour.a = f;
			text.GetComponent<Text> ().color = textColour;
			blackPanel.GetComponent<Image> ().color = panelColour;
			yield return null;
		}

		yield return new WaitForSeconds (1);

		StartCoroutine ("FadeOut");
	}


	IEnumerator FadeOut() {
		if (gameTime.day != 0) {
			StartCoroutine ("BackspaceDay");
			yield return new WaitForSeconds (5);
		} else {
			yield return new WaitForSeconds (2);
		}

		StartCoroutine ("WriteDay");
		yield return new WaitForSeconds (5);

		gameTime.hours = 6;
		gameTime.mins = 45;

		for (float f = 1f; f >= 0; f -= 0.01f) {
			Color textColour = text.GetComponent<Text> ().color;
			Color panelColour = blackPanel.GetComponent<Image> ().color;
			textColour.a = f;
			panelColour.a = f;
			text.GetComponent<Text> ().color = textColour;
			blackPanel.GetComponent<Image> ().color = panelColour;
			yield return null;
		}



	}


	IEnumerator BackspaceDay() {


		string textString;

		if (gameTime.day == 1) {
			textString = "Prologue";
		} else {
			textString = "Day " + (gameTime.day - 1).ToString ();
		}

		text.GetComponent<Text> ().text = textString;
		yield return new WaitForSeconds (2);

			
		string stringToChange = textString;

		for (int i = 0; i <= textString.Length; i++) {
			//stringToChange = stringToChange.Substring (0, stringToChange.Length - 1);
			text.GetComponent<Text> ().text = textString.Substring(0, stringToChange.Length - i);
			if (text.GetComponent<Text> ().text.Length != 0) {
				audio.PlayOneShot (keySound);

			}

			yield return new WaitForSeconds (0.14f);
		}

	}

	IEnumerator WriteDay() {

		string stringToWrite;

		if (gameTime.day == 0) {
			stringToWrite = "Prologue";
		} else {
			stringToWrite = "Day " + gameTime.day;
		}
		string stringToChange = "";

		for (int i = 0; i < stringToWrite.Length; i++) {
			stringToChange = stringToChange + stringToWrite [i];
			text.GetComponent<Text> ().text = stringToChange;


			audio.PlayOneShot (keySound);

			yield return new WaitForSeconds (0.2f);
		}

	}


}
