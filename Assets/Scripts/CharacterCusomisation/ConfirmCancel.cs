using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmCancel : MonoBehaviour {

	public Canvas canvas;
	public Canvas errorCanvas;
	private PlayerCharacter player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ConfirmCustomisation() {

		//put all customised info into character info script
		//start the main scene

		string name = GameObject.Find ("CharName").GetComponent<Text>().text;

		string hair = GameObject.Find ("Hair").GetComponent<Text> ().text;
		string shirt = GameObject.Find ("Shirt").GetComponent<Text> ().text;
		string trousers = GameObject.Find ("Trousers").GetComponent<Text> ().text;

		Color complexion = GameObject.Find ("Character").GetComponent<SpriteRenderer>().color;
		Color eyeColour = GameObject.Find ("EyesSprite").GetComponent<SpriteRenderer>().color;
		Color hairColour = GameObject.Find ("HairSprite").GetComponent<SpriteRenderer>().color;
		Color shirtColour = GameObject.Find ("TopSprite").GetComponent<SpriteRenderer>().color;
		Color trousersColour = GameObject.Find ("TrousersSprite").GetComponent<SpriteRenderer>().color;
		Color shoesColour = GameObject.Find ("ShoesSprite").GetComponent<SpriteRenderer>().color;

		player = new PlayerCharacter (name, hair, shirt, trousers);

		player.SkinColour = complexion;
		player.EyeColour = eyeColour;
		player.HairColour = hairColour;
		player.ShirtColour = shirtColour;
		player.TrousersColour = trousersColour;
		player.ShoesColour = shoesColour;


		PlayerPrefs.SetString ("Name", player.Name);
		PlayerPrefs.SetString ("Hair", player.Hair);
		PlayerPrefs.SetString ("Shirt", player.Shirt);
		PlayerPrefs.SetString ("Trousers", player.Trousers);

		PlayerPrefs.SetString ("Complexion", player.SkinColour.ToString());
		PlayerPrefs.SetString ("EyeColour", player.EyeColour.ToString());
		PlayerPrefs.SetString ("HairColour", player.HairColour.ToString());
		PlayerPrefs.SetString ("ShirtColour", player.ShirtColour.ToString());
		PlayerPrefs.SetString ("TrousersColour", player.TrousersColour.ToString());
		PlayerPrefs.SetString ("ShoesColour", player.ShoesColour.ToString());

		PlayerPrefs.Save ();

		SceneManager.LoadScene ("MainScene");



	}

	public void CloseCanvas() {

		canvas.enabled = false;
		errorCanvas.enabled = false;

	}
}
