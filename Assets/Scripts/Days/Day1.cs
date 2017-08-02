using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day1 : MonoBehaviour {

	private GameObject floor;
	private GameObject wall;

	private bool continuePressed = false;
	private List<Sprite> floorList = new List<Sprite>();
	private List<Sprite> wallList = new List<Sprite>();
	private int currentPosition = 0;
	private GameObject welcomePanel;
	private bool welcomeClicked = false;
	private GameObject floorButtons;
	private GameObject wallButtons;
	private bool floorClicked;
	private bool wallClicked;

	private float typeSpeed = 0.01f;

	public AudioClip letterSound; 
	public AudioClip chaching;
	AudioSource audio;

	public void StartDay () {

		floor = GameObject.Find ("PlayArea");

		floorList.Add (Resources.Load<Sprite>("Floors/TileFloor"));
		floorList.Add (Resources.Load<Sprite> ("Floors/MarbleFloor"));
		floorList.Add (Resources.Load<Sprite> ("Floors/WoodenFloor"));
		floorList.Add (Resources.Load<Sprite> ("Floors/WhiteTileFloor"));
		floorList.Add (Resources.Load<Sprite> ("Floors/DarkTileFloor"));

		wall = GameObject.Find ("BackWall");

		wallList.Add(Resources.Load<Sprite>("Walls/YellowWall"));


		StartCoroutine ("Sequence");


	}
	
	public void EndDay () {

		GameObject dayChanger = GameObject.Find ("DayChanger");
		dayChanger.GetComponent<DayChanger> ().StartCoroutine ("FadeIn");
		dayChanger.GetComponent<DayChanger> ().dayStarted = false;

	}

	IEnumerator Sequence() {
		yield return StartCoroutine ("DestroyPlayer");
		yield return new WaitForSeconds (4);
		yield return StartCoroutine ("WelcomePanel");
		yield return StartCoroutine ("ChooseFloor");
		yield return StartCoroutine ("ChooseWall");

	}

	public void FloorChangerRight() {

		if (currentPosition == floorList.Count - 1) {
			currentPosition = 0;
		} else {
			currentPosition++;
		}

		floor.GetComponent<SpriteRenderer> ().sprite = floorList [currentPosition];

	}

	public void FloorChangerLeft() {

		if (currentPosition == 0) {
			currentPosition = (floorList.Count - 1);
		} else {
			currentPosition--;
		}
		floor.GetComponent<SpriteRenderer> ().sprite = floorList [currentPosition];

	}

	public void WallChangerRight() {

		if (currentPosition == wallList.Count - 1) {
			currentPosition = 0;
		} else {
			currentPosition++;
		}

		wall.GetComponent<SpriteRenderer> ().sprite = wallList [currentPosition];

	}

	public void WallChangerLeft() {

		if (currentPosition == 0) {
			currentPosition = (wallList.Count - 1);
		} else {
			currentPosition--;
		}
		wall.GetComponent<SpriteRenderer> ().sprite = wallList [currentPosition];

	}

	IEnumerator DestroyPlayer() {

		yield return new WaitForSeconds (4);

		if (GameObject.Find ("Player(Clone)") != null) {
			GameObject.Destroy(GameObject.Find("Player(Clone)"));
		}

		yield return null;

	}

	IEnumerator WelcomePanel() {

		yield return new WaitForSeconds (8);

		GameObject.Find ("GameTime").GetComponent<GameTime> ().pauseTime = true;
		welcomePanel = (GameObject)Instantiate(Resources.Load("Prefabs/UI/WelcomePanel"), GameObject.Find("Canvas").transform);

		for (float f = 0f; f <= 1f; f += 0.05f) {
			Color c = new Color (1, 1, 1, 0);
			c.a = f;
			welcomePanel.GetComponent<Image>().color = c;
			yield return null;

		}

		audio = welcomePanel.GetComponentInChildren<AudioSource> ();


		yield return StartCoroutine(TextScroll ((Resources.Load("Dialogue/WelcomeDialogue") as TextAsset).text, welcomePanel.GetComponentInChildren<Text> ()));

		welcomePanel.GetComponentInChildren<Button> ().onClick.AddListener (CloseWelcomePanel);

		while (!welcomeClicked) {



			yield return null;

		}

		yield return null;

	}

	public void CloseWelcomePanel() {

		GameObject.Destroy (welcomePanel);
		welcomeClicked = true;

	}

	IEnumerator ChooseFloor() {

		floorButtons = (GameObject)Instantiate(Resources.Load("Prefabs/UI/FloorChangeButtons"), GameObject.Find("Canvas").transform);

			floorButtons.transform.Find("ConfirmButton").GetComponent<Button>().onClick.AddListener (CloseFloor);
			floorButtons.transform.Find("ChangerButtonLeft").GetComponent<Button>().onClick.AddListener (FloorChangerLeft);
		floorButtons.transform.Find ("ChangerButtonRight").GetComponent<Button> ().onClick.AddListener (FloorChangerRight);

		while (!floorClicked) {
			yield return null;
		}

		yield return null;
	}

	public void CloseFloor() {
		audio.PlayOneShot (chaching);
		GameObject.Destroy (floorButtons);
		floorClicked = true;

	}

	public void CloseWall() {
		audio.PlayOneShot (chaching);
		GameObject.Destroy (wallButtons);
		wallClicked = true;

	}

	IEnumerator TextScroll(string lineOfText, Text textArea) {
		textArea.color = new Color(1,1,1,0);
		textArea.text = lineOfText;

		int size;

		int letter = 0;

		yield return new WaitForEndOfFrame ();

		size = textArea.cachedTextGenerator.fontSizeUsedForBestFit;

		textArea.text = "";

		textArea.color = new Color(1,1,1,1);
		bool isTyping = true;
		bool cancelTyping = false;

		textArea.resizeTextForBestFit = false;
		textArea.fontSize = size;


		while (isTyping && !cancelTyping && (letter < (lineOfText.Length - 1))) {

			textArea.text += lineOfText [letter];


			audio.PlayOneShot (letterSound);

			letter += 1;
			yield return new WaitForSeconds(typeSpeed);
		}

		textArea.text = lineOfText;
		isTyping = false;
		cancelTyping = false;

	
		yield return null;
	}

	IEnumerator ChooseWall() {

		wallButtons = (GameObject)Instantiate(Resources.Load("Prefabs/UI/FloorChangeButtons"), GameObject.Find("Canvas").transform);

		wallButtons.transform.Find ("ConfirmButton").GetComponent<Text> ().text = "£750";
		wallButtons.transform.Find ("ChooseFloorText").GetComponent<Text> ().text = "Choose Wall";

		wallButtons.transform.Find("ConfirmButton").GetComponent<Button>().onClick.AddListener (CloseWall);
		wallButtons.transform.Find("ChangerButtonLeft").GetComponent<Button>().onClick.AddListener (WallChangerLeft);
		wallButtons.transform.Find ("ChangerButtonRight").GetComponent<Button> ().onClick.AddListener (WallChangerRight);

		while (!wallClicked) {
			yield return null;
		}

		yield return null;

	}
}
