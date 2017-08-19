using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBakery : MonoBehaviour {

	public bool clicked = false;
	private bool hoverOver = false;
	private Animator anim;
	private bool flag = false;
	private GameObject gridObj;
	private bool collid = false;
	private bool topLeft, topRight, bottomLeft, bottomRight = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		gridObj = GameObject.Find("GridSelection");
		AdjustCollider ();
	}

	// Update is called once per frame
	void Update () {

		GetComponent<Renderer> ().sortingOrder = (int)(transform.position.y * -10);

		if (clicked == true && Input.GetKeyDown (KeyCode.Mouse0) && flag == true && collid == false) {
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
			clicked = false;
			Cursor.visible = true;
			flag = false;
		}

		if (hoverOver == true) {

			if (Input.GetKeyDown (KeyCode.Mouse0) && clicked != true && flag == true) {
				clicked = true;
				GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.5f);



			}
		}

		if (clicked == true) {

			if (transform.position.x > 7f) {
				collid = true;
			} else if (transform.position.x < -7f) {
				collid = true;
			} else if (transform.position.y > 4f) {
				collid = true;
			} else if (transform.position.y < -4f) {
				collid = true;
			} else {
				collid = false;
			}

			hoverOver = false;

			gridObj.GetComponent<GridSelection> ().setClicked (true);

			GetComponent<Renderer> ().sortingOrder = 1000;

			float x, y;

			x = Input.mousePosition.x;
			y = Input.mousePosition.y;

			Vector3 currentPos = Camera.main.ScreenToWorldPoint (new Vector3 (x ,y , 10.0f));

		//	currentPos.x = (Mathf.RoundToInt(currentPos.x));
		//	currentPos.y = Mathf.RoundToInt(currentPos.y);

			if (currentPos.x >= 0) {
				//right
				if (currentPos.y >= 0) {
					if (!topRight) {
						StopAllCoroutines ();
						StartCoroutine ("TopRight");
					}
				} else if (!bottomRight) {
					StopAllCoroutines ();
					StartCoroutine ("BottomRight");
				}
			} else {
				//left
				if (currentPos.y >= 0) {
					if (!topLeft) {
						StopAllCoroutines ();
						StartCoroutine ("TopLeft");
					}
				} else if (!bottomLeft) {
					StopAllCoroutines ();
					StartCoroutine ("BottomLeft");
				}
			}

			Cursor.visible = false;

			if (collid == true) {
				GetComponent<SpriteRenderer> ().color = new Color (1, 0.5f, 0.5f, 0.5f);
			} else {
				GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.5f);
			}



		}

		gridObj.GetComponent<GridSelection> ().setClicked (false);

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

	IEnumerator TopLeft() {
		topLeft = true;
		topRight = false;
		bottomLeft = false;
		bottomRight = false;

		SetAllAnimBoolsFalse ();

		transform.position = new Vector3 (-5f, 4f);

		anim.SetBool ("BackLeft", true);


		while (true) {
			if (Input.GetKeyDown (KeyCode.Mouse1)) {
				if (anim.GetBool ("BackLeft") == true) {
					transform.position = new Vector3 (-7f, 2f);

					anim.SetBool ("BackLeft", false);
					anim.SetBool ("LeftBack", true);
					yield return new WaitForEndOfFrame();

					AdjustCollider ();

				} else {
					transform.position = new Vector3 (-5f, 4f);

					anim.SetBool ("BackLeft", true);
					anim.SetBool ("LeftBack", false);
					yield return new WaitForEndOfFrame();

					AdjustCollider ();

				}
			}
			yield return null;
		}
	}
	IEnumerator TopRight() {

		topLeft = false;
		topRight = true;
		bottomLeft = false;
		bottomRight = false;

		SetAllAnimBoolsFalse ();
		anim.SetBool ("BackRight", true);

		transform.position = new Vector3 (5f, 4f);
		while (true) {
			if (Input.GetKeyDown (KeyCode.Mouse1)) {
				if (anim.GetBool ("BackRight") == true) {
					transform.position = new Vector3 (7f, 2f);

					anim.SetBool ("BackRight", false);
					anim.SetBool ("RightBack", true);
					yield return new WaitForEndOfFrame();
					AdjustCollider ();

				} else {
					transform.position = new Vector3 (5f, 4f);

					anim.SetBool ("BackRight", true);
					anim.SetBool ("RightBack", false);
					yield return new WaitForEndOfFrame();

					AdjustCollider ();

				}
			}
			yield return null;
		}
	}
	IEnumerator BottomLeft() {

		topLeft = false;
		topRight = false;
		bottomLeft = true;
		bottomRight = false;

		SetAllAnimBoolsFalse ();
		anim.SetBool ("FrontLeft", true);
		transform.position = new Vector3 (-5f, -3f);

		while (true) {
			if (Input.GetKeyDown (KeyCode.Mouse1)) {
				transform.position = new Vector3 (-7f, -1.5f);

				if (anim.GetBool ("FrontLeft") == true) {
					anim.SetBool ("FrontLeft", false);
					anim.SetBool ("LeftFront", true);
					yield return new WaitForEndOfFrame();

					AdjustCollider ();

				} else {
					transform.position = new Vector3 (-5f, -3f);

					anim.SetBool ("FrontLeft", true);
					anim.SetBool ("LeftFront", false);
					yield return new WaitForEndOfFrame();

					AdjustCollider ();

				}
			}
			yield return null;
		}
	}
	IEnumerator BottomRight() {

		topLeft = false;
		topRight = false;
		bottomLeft = false;
		bottomRight = true;

		SetAllAnimBoolsFalse ();
		anim.SetBool ("FrontRight", true);

		transform.position = new Vector3 (5f, -3f);
		while (true) {
			if (Input.GetKeyDown (KeyCode.Mouse1)) {
				transform.position = new Vector3 (7f, -1.5f);

				if (anim.GetBool ("FrontRight") == true) {
					anim.SetBool ("FrontRight", false);
					anim.SetBool ("RightFront", true);
					yield return new WaitForEndOfFrame();

					AdjustCollider ();
				} else {
					transform.position = new Vector3 (5f, -3f);

					anim.SetBool ("FrontRight", true);
					anim.SetBool ("RightFront", false);
					yield return new WaitForEndOfFrame();

					AdjustCollider ();

				}
			} 
			yield return null;
		}
	}

	public void SetAllAnimBoolsFalse() {
		anim.SetBool ("RightFront", false);
		anim.SetBool ("LeftFront", false);
		anim.SetBool ("FrontRight", false);
		anim.SetBool ("FrontLeft", false);
		anim.SetBool ("RightBack", false);
		anim.SetBool ("LeftBack", false);
		anim.SetBool ("BackRight", false);
		anim.SetBool ("BackLeft", false);

	}

	public void AdjustCollider() {
		Vector2 size = gameObject.GetComponent<SpriteRenderer> ().sprite.bounds.size;
		size.x = size.x - 0.5f;
		size.y = size.y - 0.5f;

		gameObject.GetComponent<BoxCollider2D> ().size = size;
		//gameObject.GetComponent<BoxCollider2D>().offset
	}
}
