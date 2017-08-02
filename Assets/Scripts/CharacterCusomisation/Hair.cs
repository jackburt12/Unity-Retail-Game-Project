using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hair : MonoBehaviour {

	private string[] strings = new string[] { "Hair 1", "Hair 2", "Hair 3", "Hair 4"};
	private Text text;
	private int currentPosition = 0;
	private GameObject hair;
	private List<Sprite> hairList = new List<Sprite>();


	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		text.text = strings [0];
		hair = GameObject.Find ("HairSprite");

		Sprite[] hair1 = Resources.LoadAll<Sprite> ("Hair/Hair1/Hair1Idle");
		Sprite[] hair2 = Resources.LoadAll<Sprite> ("Hair/Hair2/Hair2Idle");
		Sprite[] hair3 = Resources.LoadAll<Sprite> ("Hair/Hair3/Hair3Idle");

		hairList.Add (null);
		hairList.Add(hair1[0]);
		hairList.Add (hair2 [0]);
		hairList.Add (hair3 [0]);


	}

	void Update() {

		hair.GetComponent<SpriteRenderer> ().sprite = hairList [currentPosition];
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
