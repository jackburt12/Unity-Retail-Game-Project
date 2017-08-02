using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextImporter : MonoBehaviour {

	public AudioClip letterSound; 
	AudioSource audio;

	private float typeSpeed = 0.05f;

	private GameObject textBox;
	private Text boxText;
	private GameObject nameTextBox;
	private Text nameText;

	private GameObject dialogueHolder;

	//private TextAsset textFile;
	private string[] textLines;
	private List<string> dialogue = new List<string>();
	private List<string> names = new List<string> ();
	 
	private int currentLine = 0;

	public bool isActive = false;

	private bool isTyping = false;
	private bool cancelTyping = false;

	private GameObject gameTime;


	// Use this for initialization
	void Start () {


		audio = GetComponent<AudioSource> ();

		textBox = gameObject;
		nameTextBox = GameObject.Find ("NameText");
		boxText = textBox.GetComponent<Text>();
		nameText = nameTextBox.GetComponent<Text> ();
		dialogueHolder = GameObject.Find ("DialogueHolder");
		gameTime = GameObject.Find ("GameTime");

	}

	void Update() {
		
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0)) {
			if (!isTyping) {
				currentLine += 1;

				if (currentLine >= dialogue.Count) {
					DisableTextBox ();
				} else {
					StartCoroutine(TextScroll (dialogue [currentLine]));
				}

			} else if(isTyping && !cancelTyping) {
				cancelTyping = true;
			}
		}

	}

	public void LoadTextFile(TextAsset textAsset) {


		textLines = (textAsset.text.Split ('\n'));

		foreach (string s in textLines) {

			string[] temp = s.Split(';');

			string name;

			if (temp [0].Contains ("Player")) {
				name = PlayerPrefs.GetString ("Name");
			} else {
				name = temp [0].Trim();
			}

			//TODO: If text overflows it just doesn't appear, need to fix this by splitting
			//into separate lines depending on when it overflows... fml man

			names.Add (name);
			dialogue.Add (temp [1]);

		}

	}

	public void EnableTextBox() {
		dialogueHolder.SetActive (true);
		isActive = true;
		gameTime.GetComponent<GameTime> ().pauseTime = true;
		StartCoroutine (TextScroll (dialogue [currentLine]));

	}

	public void DisableTextBox() {
		dialogueHolder.SetActive (false);
		isActive = false;
		gameTime.GetComponent<GameTime> ().pauseTime = false;

	}

	IEnumerator TextScroll(string lineOfText) {

		int letter = 0;
		boxText.text = "";
		isTyping = true;
		cancelTyping = false;

		nameText.text = names [currentLine];


		while (isTyping && !cancelTyping && (letter < (lineOfText.Length - 1))) {

			boxText.text += lineOfText [letter];

			PlayLetterSound ();

			letter += 1;
			yield return new WaitForSeconds(typeSpeed);
		}

		boxText.text = lineOfText;
		isTyping = false;
		cancelTyping = false;

	}

	public void PlayLetterSound() {

		audio.PlayOneShot (letterSound);

	}

}
