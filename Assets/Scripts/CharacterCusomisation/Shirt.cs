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


/**
 * 
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomisationScript : MonoBehaviour {

	private GameObject player;
	private GameObject iris;

	private GameObject hair1, hair2, hair3;
	private GameObject top1, top2, top3;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Player");
		iris = GameObject.Find ("Iris");
		hair1 = GameObject.Find ("Hair1");
		hair2 = GameObject.Find ("Hair2");
		hair3 = GameObject.Find ("Hair3");
		top1 = GameObject.Find ("Tshirt");
		top2 = GameObject.Find ("LongSleeve");
		top3 = GameObject.Find ("DressShirt");

		List<GameObject> hairList = new List<GameObject> ();

		hairList.Add (hair1);
		hairList.Add (hair2);
		hairList.Add (hair3);

		List<GameObject> topList = new List<GameObject> ();

		topList.Add (top1);
		topList.Add (top2);
		topList.Add (top3);

		string hairColourString = PlayerPrefs.GetString ("HairColour");
		string topColourString = PlayerPrefs.GetString ("ShirtColour");

		foreach (GameObject o in hairList) {
			o.SetActive (false);
			o.GetComponent<SpriteRenderer>().color = stringToColour (hairColourString);
		}

		foreach (GameObject o in topList) {
			o.SetActive (false);
			o.GetComponent<SpriteRenderer>().color = stringToColour (topColourString);
		}

		string chosenHair = PlayerPrefs.GetString ("Hair");

		if (chosenHair.Equals("Hair 1")) {
			//do nothing because you're super bald
		} else if (chosenHair.Equals("Hair 2")) {
			hair1.SetActive (true);
		} else if (chosenHair.Equals("Hair 3")) {
			hair2.SetActive (true);
		} else if (chosenHair.Equals("Hair 4")) {
			hair3.SetActive (true);
		}
			

		string chosenShirt = PlayerPrefs.GetString ("Shirt");

		if (chosenShirt.Equals ("T-Shirt")) {
			top1.SetActive (true);
		} else if (chosenShirt.Equals ("Long Sleeve T-Shirt")) {
			top2.SetActive (true);
		} else if (chosenShirt.Equals ("Shirt")) {
			top3.SetActive (true);
		}

		//PlayerPrefs.GetString ("Trousers");
	


		string complexionString = PlayerPrefs.GetString ("Complexion");
		string eyeColourString = PlayerPrefs.GetString ("EyeColour");
		string trousersColourString = PlayerPrefs.GetString ("TrousersColour");
		string shoesColourString = PlayerPrefs.GetString ("ShoesColour");

		player.GetComponent<SpriteRenderer>().color = stringToColour (complexionString);
		iris.GetComponent<SpriteRenderer>().color = stringToColour (eyeColourString);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static Color stringToColour(string s) {

		string[] arr1 = s.Split ('(');
		string[] arr2 = arr1 [1].Split (')');
		string[] arr3 = arr2 [0].Split (',');

		Color c = new Color (float.Parse(arr3 [0]), float.Parse(arr3 [1]), float.Parse(arr3 [2]), float.Parse(arr3 [3]));
		return c;


	}
}
**/
