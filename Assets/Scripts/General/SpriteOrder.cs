using UnityEngine;
using System.Collections;

public class SpriteOrder : MonoBehaviour {

	void Update () {
		GetComponent<Renderer> ().sortingOrder = (int)(transform.position.y * -10);
    }
}
