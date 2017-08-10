using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System;
using UnityEngine.UI;
using System.IO;
using System.Text;
using UnityEngine.EventSystems;

public class InventoryPopulation : MonoBehaviour {

	private XmlDocument allItems = new XmlDocument();

	private List<Item> inventoryItems = new List<Item>();

	private GameObject inventoryPanel;

	private bool instantiated = false;

	// Use this for initialization
	void Start () {

		GameObject cam = GameObject.Find ("Main Camera");
		cam.GetComponent<Camera> ().orthographicSize = 10;

		PlayerPrefs.SetString ("Inventory", "101;102;101;101");

		ReadInv ();
		StartCoroutine("UpdateInv");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReadInv() {
		inventoryItems.Clear ();

		allItems.LoadXml ((Resources.Load ("XML/AllItems") as TextAsset).text);

		XmlNodeList allItemList = allItems.GetElementsByTagName ("ItemID");

		inventoryPanel = GameObject.Find("MainInvPanel");

		string inventoryString = PlayerPrefs.GetString ("Inventory");
		if (inventoryString.Equals ("") || inventoryString == null) {
			return;
		}

		string[] inventoryItemIds = inventoryString.Split (';');

		List<string> itemInfo = new List<string> ();

		foreach (string invItem in inventoryItemIds) {

			foreach (XmlNode item in allItemList) {
				if (invItem.Equals (item.InnerText)) {

					XmlNodeList itemDetails = item.ParentNode.ChildNodes;
					foreach (XmlNode itemDetail in itemDetails) {
						itemInfo.Add(itemDetail.InnerText);
					}
				}
			}

			Item finalItem = new Item (itemInfo[1], (Item.ItemTypes)Enum.Parse(typeof(Item.ItemTypes), itemInfo[3]), itemInfo[2], int.Parse(itemInfo[0]), int.Parse(itemInfo[4]), double.Parse(itemInfo[5]));


			inventoryItems.Add (finalItem);
			itemInfo.Clear ();
		}
		inventoryItems.Sort (SortById);

	}

	public IEnumerator UpdateInv() {
		ReadInv ();

		foreach (Transform child in inventoryPanel.transform) {
			GameObject.Destroy (child.gameObject);
		}
		yield return new WaitForEndOfFrame ();
		GameObject currentItem;

		if (inventoryItems.Count == 0) {
			yield break;
		}
		foreach (Item item in inventoryItems) {
			bool exists = false;
			GameObject[] invItems = null;
			invItems = GameObject.FindGameObjectsWithTag ("InventoryItem");

			foreach (GameObject go in invItems) {
				print ("List of living items:" + go.GetComponentInChildren<Text> ().text);
				if (go.GetComponentInChildren<Text> ().text.ToString().Equals(item.Name)) {
					print (go.GetComponentInChildren<Text> ().text + "|" + item.Name);
					exists = true;
					string current = go.transform.GetChild (2).GetComponent<Text> ().text;
					string[] currentArr = current.Split ('x');
					int currentNo = int.Parse (currentArr [1]);
					currentNo++;
					string countStr = "x" + currentNo.ToString ();
					go.transform.GetChild (2).GetComponent<Text> ().text = countStr;
				}
			}
			if (exists == false) {
				currentItem = (GameObject)Instantiate (Resources.Load ("Prefabs/UI/ItemBox"), inventoryPanel.transform);

				currentItem.GetComponentInChildren<Text> ().text = item.Name;
				currentItem.transform.GetChild(2).GetComponent<Text> ().text = "x1";
		
				currentItem.transform.GetChild (0).GetChild (0).GetComponent<Image> ().sprite = Resources.Load<Sprite> ("InventorySprites/" + item.Image);
				currentItem.transform.GetChild (0).GetComponent<Button> ().onClick.AddListener (delegate {
					InstantiateItemAtMouse (item);
				});



			}
			exists = false;


		}
	}

	public void AddItemToInv(Item item) {

		string stringToChange = PlayerPrefs.GetString ("Inventory");
		string newString = stringToChange + ";" + item.Id.ToString();

		PlayerPrefs.SetString ("Inventory", newString);

		StartCoroutine ("UpdateInv");
	}

	public void RemoveItemFromInv(Item item) {
		print("StringBeforeRemove: " + PlayerPrefs.GetString("Inventory"));
		string stringToChange = PlayerPrefs.GetString ("Inventory");

		StringBuilder sb = new StringBuilder ();
		bool deleted = false;
		string[] invItems = stringToChange.Split (';');
		foreach (string itemString in invItems) {
			if (itemString.Equals (item.Id.ToString ()) && deleted == false) {
				deleted = true;
			} else {
				sb.Append (itemString);
				sb.Append (";");
			}

		
		}
	
		string newString = sb.ToString();
		if (!newString.Equals ("")) {
			newString = newString.Remove (newString.Length - 1);
		}

		PlayerPrefs.SetString ("Inventory", newString);
		print ("Item removed");
		print("StringAfterRemove: " + PlayerPrefs.GetString("Inventory"));

		StartCoroutine ("UpdateInv");
			
	}

	public void InstantiateItemAtMouse(Item item) {
		if (!instantiated) {
			instantiated = true;
			GameObject instantiatedItem = (GameObject)Instantiate (Resources.Load<GameObject> ("Prefabs/Items/" + item.Image));
			if (instantiatedItem.GetComponent<MoveObject> () != null) {
				instantiatedItem.GetComponent<MoveObject> ().clicked = true;
			} else {
				instantiatedItem.GetComponent<MoveObjectEven> ().clicked = true;
			}
			
			GameObject cancel = (GameObject)Instantiate (Resources.Load ("Prefabs/UI/InvInstantiatecancel"), GameObject.Find ("InvMask").transform);
			cancel.GetComponent<Button> ().onClick.AddListener (delegate {
				CancelInstantiate (instantiatedItem, cancel);
			});

			object[] objectsToPass = new object[2]{item, instantiatedItem};

			StartCoroutine ("StartInstantiation", objectsToPass);
		}
	}

	IEnumerator StartInstantiation(object[] objects) {
		yield return null;

		GameObject instantiatedItem = (GameObject)objects [1];
		Item item = (Item)objects [0];

		if (instantiatedItem.GetComponent<MoveObject> () != null) {

			while (instantiatedItem.GetComponent<MoveObject> ().clicked == true) {
				yield return null;
			}
			instantiated = false;
			RemoveItemFromInv (item);
			GameObject.Destroy(GameObject.Find ("InvInstantiateCancel(Clone)"));
		} else {
			while (instantiatedItem.GetComponent<MoveObjectEven> ().clicked == true) {
				yield return null;
			}

			instantiated = false;
			RemoveItemFromInv (item);
			GameObject.Destroy(GameObject.Find ("InvInstantiateCancel(Clone)"));

		}


	}

	public void CancelInstantiate(GameObject toDestroy, GameObject button) {
		if (toDestroy.GetComponent<MoveObject> () != null) {
			toDestroy.GetComponent<MoveObject> ().clicked = false;
		} else {
			toDestroy.GetComponent<MoveObjectEven> ().clicked = false;
		}
		GameObject.Destroy (toDestroy);
		GameObject.Destroy (button);
		instantiated = false;

		StopCoroutine ("StartInstantiation");

		Cursor.visible = true;

	}

	static int SortById(Item item1, Item item2) {

		return item1.Id.CompareTo (item2.Id);

	}

}
