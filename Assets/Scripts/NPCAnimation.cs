using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimation : MonoBehaviour {

	private Animator anim;
	private float velocity;
	private Vector3 previous;
	private Vector3 current;

	private bool up, down, left, right = false;

	private bool isStationary = false;

	void Start () { 
		anim = GetComponent<Animator>();
	}

	void Awake() {
		StartCoroutine ("updateDirection");
	}

	void Update ()
	{
		current = transform.position;

		if (isStationary) {
			stopMoving ();
			up = false;
			down = false;
			left = false;
			right = false;
		} else if (Mathf.Abs(Mathf.Abs(current.y - previous.y) - Mathf.Abs(current.x - previous.x)) < 0.02) {

			//if(current.y - previous.y > 0
			//do nothing?
		//	return;
		}

		else if (Mathf.Abs(current.y - previous.y) > Mathf.Abs (current.x - previous.x)) {
			//moving up or down

			if (current.y > previous.y) {
				if (!up) {
					moveUp ();
				}
				left = false;
				down = false;
				right = false;
				up = true;
			} else {
				if (!down) {
					moveDown ();
				}
				down = true;
				left = false;
				right = false;
				up = false;
			}
		} else {
			//moving left or right

			if (current.x > previous.x) {
				if (!right) {
					moveRight ();
				}
				left = false;
				right = true;
				down = false;
				up = false;
			} else {
				if (!left) {
					moveLeft ();
				}
				left = true;
				right = false;
				down = false;
				up = false;
			}
		}
			
		GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -10);

	}

	public static float AngleBetween (Vector3 vector1, Vector3 vector2) {
		float sin = vector1.x * vector2.y - vector2.x * vector1.y;
		float cos = vector1.x * vector2.x + vector1.y * vector2.y;

		return Mathf.Atan2 (sin, cos) * (180 / Mathf.PI);
	}

	public void moveLeft() {
		anim.SetBool("Left", true);
		anim.SetBool("Down", false);
		anim.SetBool("Up", false);
		anim.SetBool("Right", false);

		anim.SetBool ("WalkLeft", true);
		anim.SetBool ("WalkDown", false);
		anim.SetBool ("WalkUp", false);
		anim.SetBool ("WalkRight", false);
	}

	public void moveRight() {
		anim.SetBool("Left", false);
		anim.SetBool("Down", false);
		anim.SetBool("Up", false);
		anim.SetBool("Right", true);

		anim.SetBool ("WalkLeft", false);
		anim.SetBool ("WalkDown", false);
		anim.SetBool ("WalkUp", false);
		anim.SetBool ("WalkRight", true);
	}

	public void moveUp() {
		anim.SetBool("Left", false);
		anim.SetBool("Down", false);
		anim.SetBool("Up", true);
		anim.SetBool("Right", false);

		anim.SetBool ("WalkLeft", false);
		anim.SetBool ("WalkDown", false);
		anim.SetBool ("WalkUp", true);
		anim.SetBool ("WalkRight", false);
	}

	public void moveDown() {
		anim.SetBool("Left", false);
		anim.SetBool("Down", true);
		anim.SetBool("Up", false);
		anim.SetBool("Right", false);

		anim.SetBool ("WalkLeft", false);
		anim.SetBool ("WalkDown", true);
		anim.SetBool ("WalkUp", false);
		anim.SetBool ("WalkRight", false);
	}

	public void stopMoving() {
		anim.SetBool("Left", false);
		anim.SetBool("Down", false);
		anim.SetBool("Up", false);
		anim.SetBool("Right", false);
		anim.SetBool ("WalkLeft", false);
		anim.SetBool ("WalkDown", false);
		anim.SetBool ("WalkUp", false);
		anim.SetBool ("WalkRight", false);
	}

	IEnumerator updateDirection() {

		while (true) {

			if (Mathf.Abs (current.y - previous.y) < 0.05 && Mathf.Abs (current.x - previous.x) < 0.05)
			{
				isStationary = true;
			} else {

				isStationary = false;

				previous = current;

			}


			yield return new WaitForSeconds (0.05f);


		}

	}
}
