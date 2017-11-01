using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveObjectEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	private bool clicked = false;
	private bool hoverOver = false;
	private Animator anim;
	private bool flag = false;
	private GameObject gridObj;
	private bool collid = false;

	void Start () {
		anim = GetComponent<Animator>();
		gridObj = GameObject.Find("GridSelection");
	}

	// Update is called once per frame
	void Update () {
		/*

		GetComponent<Renderer> ().sortingOrder = (int)(transform.position.y * -10);

		if (clicked == true && Input.GetKeyDown (KeyCode.Mouse0) && flag == true && collid == false) {
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
			gridObj.GetComponent<GridSelection> ().setClicked (false);
			clicked = false;
			Cursor.visible = true;
			flag = false;
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
			//clean this up, too many unnecessary vector3 

			x = Input.mousePosition.x;
			y = Input.mousePosition.y;

			Vector3 currentPos = Camera.main.ScreenToWorldPoint (new Vector3 (x ,y , 10.0f));

			currentPos.x = (Mathf.RoundToInt(currentPos.x) - 0.5f);
			currentPos.y = Mathf.RoundToInt(currentPos.y);

			//	Vector3 posRounded = new Vector3 (x2 - 0.5f, y2, 10f);
			//	currentPos.z = 10f;

			Cursor.visible = false;

			transform.position = currentPos;

			if (collid == true) {
				GetComponent<SpriteRenderer> ().color = new Color (1, 0.5f, 0.5f, 0.5f);
			} else {
				GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.5f);
			}



		}


		flag = true;
*/

	}

	public void OnPointerEnter(PointerEventData eventData) {
		print ("pointer enter");
		hoverOver = true;

	}

	public void OnPointerExit(PointerEventData eventData) {

		print ("pointer exit");
		if (clicked != true) {
			hoverOver = false;
		}

	}

	public void OnPointerClick (PointerEventData eventData)
	{

		if (clicked == true) {
			clicked = false;
		} else {

			clicked = true;
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.5f);

			gridObj.GetComponent<GridSelection> ().setClicked (true);

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
