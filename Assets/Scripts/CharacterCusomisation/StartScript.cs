using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour {

	public Canvas popup;
	public Canvas error;
	public Text charName;
	public InputField nameInput;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onPressed() {

		if (!nameInput.text.Equals ("") && nameInput.text != null) {

			charName.GetComponent<Text> ().text = nameInput.text;

			popup.enabled = true;
		} else {
			
			error.enabled = true;

		}




	}
}
