using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour {

	private float speed = 0.04f;

	private bool active = false;
	GameTime gameTime;

	private GameObject floor, wall;
	private GameObject player, seller;
	private GameObject dialogueText;

	private TextAsset textFile;

	private Animator anim;


	public void StartDay() {

		player = (GameObject)Instantiate(Resources.Load("Prefabs/Characters/Player"));
		floor = GameObject.Find ("PlayArea");
		wall = GameObject.Find ("BackWall");
		floor.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Floors/WornOutFloor");
		wall.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Walls/ShittyBackWall");
		dialogueText = GameObject.Find ("DialogueText");
		dialogueText.GetComponent<TextImporter> ().DisableTextBox ();
		textFile = Resources.Load ("Dialogue/BuyingSceneDialogue") as TextAsset;
		anim = player.GetComponent<Animator> ();


		active = true;

		player.GetComponent<PlayerMovement> ().canMove = false;
		player.GetComponent<PlayerAnimation> ().canMove = false;

		player.transform.position = new Vector3(0, -10);

		StartCoroutine ("Sequence");

	}

	public void EndDay() {

		GameObject dayChanger = GameObject.Find ("DayChanger");
		dayChanger.GetComponent<DayChanger> ().StartCoroutine ("FadeIn");
		dayChanger.GetComponent<DayChanger> ().dayStarted = false;

	}

	IEnumerator Sequence() {

		yield return StartCoroutine ("WalkUp");
		yield return StartCoroutine ("LookAround");
		yield return StartCoroutine ("EnterSeller");
		yield return StartCoroutine ("BeginDialogue");
		yield return StartCoroutine ("SellerLeave");
		yield return StartCoroutine ("TurnAround");

		EndDay ();

		yield return null;

	}

	IEnumerator WalkUp() {
		

		yield return new WaitForSeconds (10);

		while (player.transform.position.y < 0) {
			player.transform.Translate (Vector2.up * speed);

			yield return null;
		}
			
	}

	IEnumerator LookAround() {

		yield return new WaitForSeconds (1);

		anim.SetBool("Left", true);
		anim.SetBool("Down", false);
		anim.SetBool("Up", false);
		anim.SetBool("Right", false);

		yield return new WaitForSeconds (1);

		anim.SetBool("Left", false);
		anim.SetBool("Down", false);
		anim.SetBool("Up", false);
		anim.SetBool("Right", true);

		yield return new WaitForSeconds (1);

		anim.SetBool("Left", false);
		anim.SetBool("Down", true);
		anim.SetBool("Up", false);
		anim.SetBool("Right", false);

		yield return null;
	}

	IEnumerator EnterSeller() {

		seller = (GameObject)Instantiate(Resources.Load("Prefabs/Characters/Seller"));


		while (seller.transform.position.y < -1.5) {
			seller.transform.Translate (Vector2.up * speed);

			yield return null;
		}

		yield return null;

	}

	IEnumerator BeginDialogue() {

		if (textFile != null && dialogueText != null) {
			dialogueText.GetComponent<TextImporter> ().LoadTextFile (textFile);

			dialogueText.GetComponent<TextImporter> ().EnableTextBox ();
		}

		while (dialogueText.GetComponent<TextImporter> ().isActive) {
			yield return null;
		}

		yield return null;

	}

	IEnumerator SellerLeave() {

		while (seller.transform.position.y > -10) {
			seller.transform.Translate (Vector2.down * speed);

			yield return null;
		}

		GameObject.Destroy (seller);

		yield return null;

	}

	IEnumerator TurnAround() {

		anim.SetBool("Left", false);
		anim.SetBool("Down", false);
		anim.SetBool("Up", true);
		anim.SetBool("Right", false);

		yield return new WaitForSeconds (3);
	
	}

}
