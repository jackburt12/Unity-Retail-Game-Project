using UnityEngine;
using System.Collections;

public class MoveObjectEven : MonoBehaviour {

	private bool clicked = false;
	private bool hoverOver = false;
	private Animator anim;
	private bool flag = false;
	private GameObject gridObj;
	private bool collid = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		gridObj = GameObject.Find("GridSelection");
	}

	// Update is called once per frame
	void Update () {

		GetComponent<Renderer> ().sortingOrder = (int)(transform.position.y * -10);

		if (clicked == true && Input.GetKeyDown (KeyCode.Mouse0) && flag == true && collid == false) {
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
			gridObj.GetComponent<GridSelection> ().setClicked (false);
			clicked = false;
			Cursor.visible = true;
			flag = false;
		}

		if (hoverOver == true) {

			if (Input.GetKeyDown (KeyCode.Mouse0) && clicked != true && flag == true) {
				clicked = true;
				GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.5f);

				gridObj.GetComponent<GridSelection> ().setClicked (true);


			}
		}

		if (clicked == true) {

			hoverOver = false;

			GetComponent<Renderer> ().sortingOrder = 1000;

			if (Input.GetKeyDown (KeyCode.Mouse1)) {
				anim.SetBool ("Click", true);
			}
			if (Input.GetKeyUp (KeyCode.Mouse1)) {
				anim.SetBool ("Click", false);
			}

			float x, y;

			x = Input.mousePosition.x;
			y = Input.mousePosition.y;

			Vector3 currentPos = Camera.main.ScreenToWorldPoint (new Vector3 (x ,y , 10.0f));

			currentPos.x = (Mathf.RoundToInt(currentPos.x));
			currentPos.y = Mathf.RoundToInt(currentPos.y);

			Cursor.visible = false;

			transform.position = currentPos;

			if (collid == true) {
				GetComponent<SpriteRenderer> ().color = new Color (1, 0.5f, 0.5f, 0.5f);
			} else {
				GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.5f);
			}



		}


		flag = true;


	}

	public void OnMouseOver () {
		hoverOver = true;



	}

	public void OnMouseExit() {
		if(clicked != true) {
			hoverOver = false;
		}
	}

	public bool getClicked() {
		return clicked;
	}

	public void OnCollisionStay2D (Collision2D col) {
		collid = true;
	}

	public void OnCollisionExit2D (Collision2D col) {
		collid = false;
	}


}
