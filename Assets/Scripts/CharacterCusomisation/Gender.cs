using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gender : MonoBehaviour {

	private string[] strings = new string[] { "Male", "Female" };
	private Text text;
	private int currentPosition = 0;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		text.text = strings [0];

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
