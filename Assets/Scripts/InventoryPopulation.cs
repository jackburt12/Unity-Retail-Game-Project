using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;
using UnityEngine.UI;

public class InventoryPopulation : MonoBehaviour {

	private XmlDocument playerInv = new XmlDocument();
	private XmlDocument allItems = new XmlDocument();

	private List<Item> inventoryItems = new List<Item>();

	private GameObject inventoryPanel;

	// Use this for initialization
	void Start () {

		ReadXML ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReadXML() {
		playerInv.LoadXml((Resources.Load ("XML/PlayerInventory") as TextAsset).text);
		allItems.LoadXml ((Resources.Load ("XML/AllItems") as TextAsset).text);

		XmlNodeList invItemList = playerInv.GetElementsByTagName ("Item");
		XmlNodeList allItemList = allItems.GetElementsByTagName ("ItemID");

		inventoryPanel = GameObject.Find("MainInvPanel");

		List<string> itemInfo = new List<string> ();

		foreach (XmlNode invItem in invItemList) {

			foreach (XmlNode item in allItemList) {
				if (invItem.InnerText.Equals (item.InnerText)) {

					XmlNodeList itemDetails = item.ParentNode.ChildNodes;
					foreach (XmlNode itemDetail in itemDetails) {
						itemInfo.Add(itemDetail.InnerText);
					}
				}
			}
			Sprite sprite = Resources.Load<Sprite> ("InventorySprites/" + itemInfo [1]);

			Item finalItem = new Item (sprite, (Item.ItemTypes)Enum.Parse(typeof(Item.ItemTypes), itemInfo[3]), itemInfo[2], int.Parse(itemInfo[0]), int.Parse(itemInfo[4]), double.Parse(itemInfo[5]));


			inventoryItems.Add (finalItem);
			itemInfo.Clear ();
		}

		UpdateInv ();
	}

	public void UpdateInv() {

		foreach (Transform child in inventoryPanel.transform) {
			GameObject.Destroy (child.gameObject);
		}
		GameObject currentItem;
		foreach (Item item in inventoryItems) {
			currentItem = (GameObject)Instantiate(Resources.Load("Prefabs/UI/ItemBox"), inventoryPanel.transform);

			currentItem.GetComponentInChildren<Text> ().text = item.Name;
			currentItem.transform.GetChild (0).GetChild (0).GetComponent<Image> ().sprite = item.Image;

		}
	}

	public void AddItemToInv(Item item) {

	}

	public void RemoveItemFromInv(Item item) {

	}
}
