using UnityEngine;
using System.Collections;

public class SpriteOrderShirt : MonoBehaviour {

	void Update () {
		GetComponent<Renderer> ().sortingOrder = (int)(transform.position.y * -10) + 2;
	}
}
