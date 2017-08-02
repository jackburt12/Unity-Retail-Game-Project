using UnityEngine;
using System.Collections;

public class GridSelection : MonoBehaviour {

	private bool clicked = false;

	// Use this for initialization
	void Start () {

		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.0f);

	}
	
	// Update is called once per frame
	void Update () {
	
		if (clicked) {
			//GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.5f);
		}

		if (clicked) {

			if(GetComponent<SpriteRenderer> ().color == new Color(1,1,1,0f)) {
				StartCoroutine ("FadeIn");
			} else if (GetComponent<SpriteRenderer> ().color == new Color(1,1,1,0.35f)) {
				StartCoroutine ("FadeOut");
			}
		}

		if (!clicked) {
			StopCoroutine ("FadeIn");
			StopCoroutine ("FadeOut");
			GetComponent<SpriteRenderer> ().color = new Color(1,1,1,0);
		}


	}

	public void setClicked(bool val) {
		this.clicked = val;
	}

	IEnumerator FadeOut() {
	
		for (float f = 0.35f; f >= 0; f -= 0.005f) {
			Color c = new Color (1, 1, 1, 1);
			c.a = f;
			GetComponent<SpriteRenderer> ().color = c;
			yield return null;
		}

	}

	IEnumerator FadeIn() {

		for (float f = 0.0f; f <= 0.35f; f += 0.005f) {
			Color c = new Color (1, 1, 1, 1);
			c.a = f;
			GetComponent<SpriteRenderer> ().color = c;
			yield return null;
		}
	}


}
