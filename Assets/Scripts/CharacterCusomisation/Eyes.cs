using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eyes : MonoBehaviour {

	private string[] strings = new string[] { "Blue", "Brown", "Green", "Grey", "Hazel" };
	private Text text;
	private int currentPosition = 0;
	private GameObject eyesSprite;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		text.text = "Eye Colour";

		eyesSprite = GameObject.Find("EyesSprite");

	}
		
	void Update() {

		if (currentPosition == 0) {
			eyesSprite.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);	
		} else if (currentPosition == 1) {
			eyesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.5f, 0.25f, 0.1f, 1);
		} else if (currentPosition == 2) {
			eyesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.3f, 1, 0.5f, 1);
		} else if (currentPosition == 3) {
			eyesSprite.GetComponent<SpriteRenderer> ().color = new Color (0.6f,0.6f, 0.6f, 0.75f);
		} else {
			eyesSprite.GetComponent<SpriteRenderer> ().color = new Color (1, 0.7f, 0.2f, 1);

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
