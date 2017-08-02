using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoeColour : MonoBehaviour {

	private string[] strings = new string[] { "White", "Grey", "Black", "Red", "Pink", "Purple", "Blue", "Cyan", "Green", "Lime", "Yellow", "Orange", "Brown"};
	private Text text;
	private int currentPosition = 12;
	private GameObject shoesSprite;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		text.text = "Shoe Colour";

		shoesSprite = GameObject.Find("ShoesSprite");

	}

	void Update() {

		if (currentPosition == 0) {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);				//white
		} else if (currentPosition == 1) {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.6f, 0.6f, 0.6f, 1);	//grey
		} else if (currentPosition == 2) {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.3f, 0.3f, 0.3f, 1);	//black
		} else if (currentPosition == 3) {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.9f, 0.4f, 0.4f, 1);	//red
		} else if (currentPosition == 4) {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.9f, 0.65f, 0.65f, 1);	//pink
		} else if (currentPosition == 5) {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.45f, 0.35f, 0.6f, 1);	//purple
		} else if (currentPosition == 6) {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.25f, 0.4f, 0.75f, 1);	//blue
		} else if (currentPosition == 7) {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.35f, 0.85f, 0.8f, 1);	//cyan
		} else if (currentPosition == 8) {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.5f, 0.8f, 0.6f, 1);	//green
		} else if (currentPosition == 9) {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.7f, 0.9f, 0.45f, 1);	//lime
		} else if (currentPosition == 10) {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.9f, 0.9f, 0.45f, 1);	//yellow
		} else if (currentPosition == 11) {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (1, 0.75f, 0.4f, 1);		//orange
		} else {
			shoesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.4f, 0.32f, 0.3f, 1);	//brown
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
