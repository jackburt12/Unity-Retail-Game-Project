using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HairColour : MonoBehaviour {
	private string[] strings = new string[] { "Light Brown", "Dark Brown", "Black", "Grey", "Blonde", "Red", "Blue", "Purple", "Green"};
	private Text text;
	private int currentPosition = 0;
	private GameObject hairSprite;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		text.text = "Hair Colour";

		hairSprite = GameObject.Find("HairSprite");

	}

	void Update() {

		if (currentPosition == 0) {
			hairSprite.GetComponent<SpriteRenderer> ().color = new Color (0.5f, 0.35f, 0.3f, 1);	
		} else if (currentPosition == 1) {
			hairSprite.GetComponent<SpriteRenderer> ().color = new Color (0.25f, 0.15f, 0.15f, 1);
		} else if (currentPosition == 2) {
			hairSprite.GetComponent<SpriteRenderer> ().color = new Color (0.1f, 0.1f, 0.1f, 1);
		} else if (currentPosition == 3) {
			hairSprite.GetComponent<SpriteRenderer> ().color = new Color (0.8f,0.8f,0.8f,1);
		} else if (currentPosition == 4) {
			hairSprite.GetComponent<SpriteRenderer> ().color = new Color (1, 0.95f, 0.7f, 1);
		} else if (currentPosition == 5) {
			hairSprite.GetComponent<SpriteRenderer> ().color = new Color (0.85f, 0.4f, 0, 1);
		} else if (currentPosition == 6) {
			hairSprite.GetComponent<SpriteRenderer> ().color = new Color (0.25f, 0.4f, 0.75f, 1);
		} else if (currentPosition == 7) {
			hairSprite.GetComponent<SpriteRenderer> ().color = new Color (0.45f, 0.35f, 0.6f, 1);
		} else if (currentPosition == 8) {
			hairSprite.GetComponent<SpriteRenderer> ().color = new Color (0.5f, 0.8f, 0.6f, 1);
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
