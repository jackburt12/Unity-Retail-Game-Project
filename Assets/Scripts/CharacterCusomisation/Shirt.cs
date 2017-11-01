using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shirt : MonoBehaviour {

	private string[] strings = new string[] { "T-Shirt", "Long Sleeve T-Shirt", "Shirt" };
	private Text text;
	private int currentPosition = 0;
	private GameObject top;
	private List<Sprite> topList = new List<Sprite>();


	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text> ();
		text.text = strings [0];
		top = GameObject.Find ("TopSprite");

		Sprite[] top1 = Resources.LoadAll<Sprite> ("Clothes/TshirtIdle");
		Sprite[] top2 = Resources.LoadAll<Sprite> ("Clothes/LongSleeveIdle");
		Sprite[] top3 = Resources.LoadAll<Sprite> ("Clothes/DressShirtIdle");

		topList.Add(top1[0]);
		topList.Add (top2 [0]);
		topList.Add (top3 [0]);


	}

	void Update() {

		top.GetComponent<SpriteRenderer> ().sprite = topList [currentPosition];
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