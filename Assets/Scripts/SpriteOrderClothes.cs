using UnityEngine;
using System.Collections;

public class SpriteOrderClothes : MonoBehaviour {

	void Update () {
		GetComponent<Renderer> ().sortingOrder = (int)(transform.position.y * -10) + 1;
	}
}
