using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	public bool canMove = true;

    public Animator anim;

    void Start () { 
        anim = GetComponent<Animator>();
	}

    void Update ()
    {

		if (canMove) {

			if (Input.GetKey (KeyCode.A)) {
				anim.SetBool ("Left", true);
				anim.SetBool ("Down", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Right", false);
			}
			if (Input.GetKey (KeyCode.S)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Down", true);
				anim.SetBool ("Up", false);
				anim.SetBool ("Right", false);
			}
			if (Input.GetKey (KeyCode.W)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Down", false);
				anim.SetBool ("Up", true);
				anim.SetBool ("Right", false);
			}
			if (Input.GetKey (KeyCode.D)) {
				anim.SetBool ("Left", false);
				anim.SetBool ("Down", false);
				anim.SetBool ("Up", false);
				anim.SetBool ("Right", true);
			}
			if (Input.GetKey (KeyCode.A)) {
				anim.SetBool ("WalkLeft", true);
			} else {
				anim.SetBool ("WalkLeft", false);
			}
			if (Input.GetKey (KeyCode.D)) {
				anim.SetBool ("WalkRight", true);
			} else {
				anim.SetBool ("WalkRight", false);
			}
			if (Input.GetKey (KeyCode.S)) {
				anim.SetBool ("WalkDown", true);
			} else {
				anim.SetBool ("WalkDown", false);
			}
			if (Input.GetKey (KeyCode.W)) {
				anim.SetBool ("WalkUp", true);
			} else {
				anim.SetBool ("WalkUp", false);
			}

		}

    }
}
