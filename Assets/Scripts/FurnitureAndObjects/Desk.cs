using UnityEngine;
using System.Collections;

public class Desk : MonoBehaviour {

	private Sprite sprite1, sprite2, sprite3, sprite4;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
	
		spriteRenderer = GetComponent<SpriteRenderer> ();
		sprite1 = Resources.Load<Sprite>("Desks/Desk1");
		sprite2 = Resources.Load<Sprite>("Desks/Desk2");
		sprite3 = Resources.Load<Sprite>("Desks/Desk3");
		sprite4 = Resources.Load<Sprite>("Desks/Desk4");

	}
	
	// Update is called once per frame
	void Update () {

		//placeholder uses space as a call for changesprite, change
		//for whatever UI call here I guess further down the line
	
		if (Input.GetKeyDown (KeyCode.Space)) {
			ChangeSprite ();
		}
	}

	void ChangeSprite() {

		//not an ideal solution, probably best try an arraylist
		//or somethign when I add more sprites
		if (spriteRenderer.sprite == sprite1) {
			spriteRenderer.sprite = sprite2;
		} else if (spriteRenderer.sprite == sprite2) {
			spriteRenderer.sprite = sprite3;
		} else if (spriteRenderer.sprite == sprite3) {
			spriteRenderer.sprite = sprite4;
		} else if (spriteRenderer.sprite == sprite4) {
			spriteRenderer.sprite = sprite1;
		}

	}
	
}
