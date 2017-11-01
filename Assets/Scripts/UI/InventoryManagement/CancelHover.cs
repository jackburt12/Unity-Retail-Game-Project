using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CancelHover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerEnter(PointerEventData eventData) {
		print ("HoverOverCancel");
		Cursor.visible = true;
	}
	public void OnPointerExit(PointerEventData eventData) {
		Cursor.visible = false;
		print ("NoHoverOverCancel");

	}
}
