using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomisationScript : MonoBehaviour {

	private GameObject player;
	private GameObject iris;
	private GameObject shoes;

	private GameObject hair1, hair2, hair3;
	private GameObject top1, top2, top3;
	private GameObject trouser1, trouser2;

	private List<string> gameObjectNames = new List<string> ();


	// Use this for initialization
	void Start () {
		
		player = gameObject;

		/*
		iris = GameObject.Find ("Iris");
		shoes = GameObject.Find ("Shoes");
		hair1 = GameObject.Find ("Hair1");
		hair2 = GameObject.Find ("Hair2");
		hair3 = GameObject.Find ("Hair3");
		top1 = GameObject.Find ("Tshirt");
		top2 = GameObject.Find ("LongSleeve");
		top3 = GameObject.Find ("DressShirt");
		trouser1 = GameObject.FindGameObjectWithTag ("TrousersTag");
		trouser2 = GameObject.Find ("Shorts");
		*/

		GameObject[] playerItems = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject g in playerItems) {

			if (g.name == "Iris") {
				iris = g;
			} else if (g.name == "Shoes") {
				shoes = g;
			} else if (g.name == "Hair1") {
				hair1 = g;
			} else if (g.name == "Hair2") {
				hair2 = g;
			} else if (g.name == "Hair3") {
				hair3 = g;
			} else if (g.name == "Tshirt") {
				top1 = g;
			} else if (g.name == "LongSleeve") {
				top2 = g;
			} else if (g.name == "DressShirt") {
				top3 = g;
			} else if (g.name == "Trousers") {
				trouser1 = g;
			} else if (g.name == "Shorts") {
				trouser2 = g;
			}

		}



		List<GameObject> hairList = new List<GameObject> ();

		hairList.Add (hair1);
		hairList.Add (hair2);
		hairList.Add (hair3);

		List<GameObject> topList = new List<GameObject> ();

		topList.Add (top1);
		topList.Add (top2);
		topList.Add (top3);

		List<GameObject> trouserList = new List<GameObject> ();

		trouserList.Add (trouser1);
		trouserList.Add (trouser2);

		string hairColourString = PlayerPrefs.GetString ("HairColour");

		foreach (GameObject o in hairList) {
			o.SetActive (false);
			o.GetComponent<SpriteRenderer>().color = stringToColour (hairColourString);
		}

		string shirtColourString = PlayerPrefs.GetString ("ShirtColour");

		foreach (GameObject o in topList) {
			o.SetActive (false);
			o.GetComponent<SpriteRenderer> ().color = stringToColour (shirtColourString);
		}

		string trouserColourString = PlayerPrefs.GetString ("TrousersColour");

		foreach (GameObject o in trouserList) {
			o.SetActive (false);
			o.GetComponent<SpriteRenderer> ().color = stringToColour (trouserColourString);
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

		string chosenTrousers = PlayerPrefs.GetString ("Trousers");

		if (chosenTrousers.Equals ("Trousers")) {
			trouser1.SetActive (true);
		} else if (chosenTrousers.Equals ("Shorts")) {
			trouser2.SetActive (true);
		}
	


		string complexionString = PlayerPrefs.GetString ("Complexion");
		string eyeColourString = PlayerPrefs.GetString ("EyeColour");
		string shoesColourString = PlayerPrefs.GetString ("ShoesColour");


		player.GetComponent<SpriteRenderer>().color = stringToColour (complexionString);
		iris.GetComponent<SpriteRenderer>().color = stringToColour (eyeColourString);
		shoes.GetComponent<SpriteRenderer> ().color = stringToColour (shoesColourString);

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
