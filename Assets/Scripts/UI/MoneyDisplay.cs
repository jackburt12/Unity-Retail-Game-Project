using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		string moneyText = "£" + PlayerPrefs.GetInt ("Money").ToString();
		gameObject.GetComponent<Text> ().text = moneyText;
	}
}
