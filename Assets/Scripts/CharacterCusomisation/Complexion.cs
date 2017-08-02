using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Complexion : MonoBehaviour {

	private string[] strings = new string[] { "Complexion 1", "Complexion 2", "Complexion 3", "Complexion 4", "Complexion 5" };
	private Text text;
	private int currentPosition = 0;
	private GameObject character;


	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		text.text = "Complexion";

		character = GameObject.Find ("Character");

	}

	void Update() {

		if (currentPosition == 0) {
			character.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);	
		} else if (currentPosition == 1) {
			character.GetComponent<SpriteRenderer> ().color = new Color (0.85f, 0.85f, 0.85f, 1);
		} else if (currentPosition == 2) {
			character.GetComponent<SpriteRenderer> ().color = new Color (0.7f, 0.7f, 0.7f, 1);
		} else if (currentPosition == 3) {
			character.GetComponent<SpriteRenderer> ().color = new Color (0.55f, 0.55f, 0.55f, 1);
		} else {
			character.GetComponent<SpriteRenderer> ().color = new Color (0.4f, 0.4f, 0.4f, 1);

		}

	}

	public void NextString() {

		if (currentPosition == (strings.Length - 1)) {

			text.text = strings [0];
			currentPosition = 0;

		} else {
			text.text = strings [currentPosition + 1];
			currentPosition++;
		}
	}

	public void PreviousString() {

		if (currentPosition == 0) {

			text.text = strings [strings.Length - 1];
			currentPosition = strings.Length - 1;

		} else {
			text.text = strings [currentPosition - 1];
			currentPosition--;
		}
	}
}
