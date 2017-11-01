using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

	public enum ItemTypes {
		FUNCTIONAL,
		DECORATIVE,
		CLOTHING,
		MISCELLANEOUS 
	}

	private string image;
	private string name;
	private int id;
	private int cost;
	private double revenue;
	private ItemTypes type;



	public Item (string image, ItemTypes type, string name, int id) {
		this.image = image;
		this.type = type;
		this.name = name;
		this.id = id;	
	}

	public Item(string image, ItemTypes type, string name, int id, int cost, double revenue) {
		this.image = image;
		this.type = type;
		this.name = name;
		this.id = id;	
		this.cost = cost;
		this.revenue = revenue;
	}


	public string Name {
		get {
			return this.name;
		}
	}

	public int Id {
		get {
			return this.id;
		}
	}

	public int Cost {
		get {
			return this.cost;
		}
	}

	public double Revenue {
		get {
			return this.revenue;
		}
	}

	public ItemTypes Type {
		get {
			return this.type;
		}
	}

	public string Image {
		get {
			return this.image;
		}
	}
}
