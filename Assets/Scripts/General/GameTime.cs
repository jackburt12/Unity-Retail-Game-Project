using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTime : MonoBehaviour {

	public int day = 0;
	public double hours = 0;
	public double mins = 0;
	private Text timeText;

	public bool pauseTime = false;


	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!pauseTime) {
			mins = (mins + (Time.smoothDeltaTime * 15));

			if (mins >= 60) {
				mins = 0;
				hours++;
			}

			timeText.text = (hours.ToString("00") + ":" + mins.ToString("00"));
		}
			
	}

	public double getHours() {
		return hours;
	}


}
