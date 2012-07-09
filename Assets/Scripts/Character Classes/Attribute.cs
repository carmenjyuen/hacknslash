/// <summary>
/// Attribute.cs 
/// Carmen Yuen
/// July 8, 2012
/// 
/// This is the class for all of the character attributes in game.
/// </summary>
public class Attribute : BaseStat {
	new public const int STARTING_EXP_COST = 50;	//this is the starting cost for all of the attributes
	
	private string _name;							//this is the name of the attribute
	
	/// <summary>
	/// Initializes a new instance of the <see cref="Attribute"/> class.
	/// </summary>
	public Attribute(){
		_name = "";
		ExpToLevel = STARTING_EXP_COST;
		LevelModifier = 1.05f;
		
	}
	
	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	/// <value>
	/// The name.
	/// </value>
	public string Name {
		get{ return _name; }
		set{ _name = value; }
	}
	
}

// Adding a note to revise Attributes

/// <summary>
/// List of the Attributes that will be in game for characters.
/// </summary>
public enum AttributeName {
	Strength,
	Stamina,
	Speed,
	Intelligence,
	Charisma
	
}