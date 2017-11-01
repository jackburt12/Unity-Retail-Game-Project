using UnityEngine;
using System.Collections;

public class PlayerCharacter {

	private string name;
	private string hair, shirt, trousers;
	private Color skinColour, eyeColour, hairColour, shirtColour, trousersColour, shoesColour;

	public PlayerCharacter (string name, string hair, string shirt, string trousers)
	{
		this.name = name;
		this.hair = hair;
		this.shirt = shirt;
		this.trousers = trousers;
	}

	public string Name {
		get {
			return this.name;
		}
	}

	public string Hair {
		get {
			return this.hair;
		}
		set {
			hair = value;
		}
	}

	public string Shirt {
		get {
			return this.shirt;
		}
		set {
			shirt = value;
		}
	}

	public string Trousers {
		get {
			return this.trousers;
		}
		set {
			trousers = value;
		}
	}

	public Color SkinColour {
		get {
			return this.skinColour;
		}
		set {
			skinColour = value;
		}
	}

	public Color EyeColour {
		get {
			return this.eyeColour;
		}
		set {
			eyeColour = value;
		}
	}

	public Color HairColour {
		get {
			return this.hairColour;
		}
		set {
			hairColour = value;
		}
	}

	public Color ShirtColour {
		get {
			return this.shirtColour;
		}
		set {
			shirtColour = value;
		}
	}

	public Color TrousersColour {
		get {
			return this.trousersColour;
		}
		set {
			trousersColour = value;
		}
	}

	public Color ShoesColour {
		get {
			return this.shoesColour;
		}
		set {
			shoesColour = value;
		}
	}
		



}
