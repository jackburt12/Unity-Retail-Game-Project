using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trousers : MonoBehaviour {

	private string[] strings = new string[] { "Trousers", "Shorts"};
	private Text text;
	private int currentPosition = 0;
	private GameObject trousers;
	private List<Sprite> trousersList = new List<Sprite>();


	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		text.text = strings [0];
		trousers = GameObject.Find ("TrousersSprite");

		Sprite[] trousers1 = Resources.LoadAll<Sprite> ("Clothes/TrousersIdle");
		Sprite[] trousers2 = Resources.LoadAll<Sprite> ("Clothes/ShortsIdle");
	//	Sprite[] trousers3 = Resources.LoadAll<Sprite> ("Clothes/DressShirtIdle");

		trousersList.Add(trousers1[0]);
		trousersList.Add (trousers2 [0]);
	//	trousersList.Add (trousers3 [0]);


	}

	void Update() {

		trousers.GetComponent<SpriteRenderer> ().sprite = trousersList [currentPosition];
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
