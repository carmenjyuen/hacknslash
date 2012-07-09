public class Attribute : BaseStat {
	new public const int STARTING_EXP_COST = 50;
	
	private string _name;
	
	public Attribute(){
		_name = "";
		ExpToLevel = STARTING_EXP_COST;
		LevelModifier = 1.05f;
		
	}
	
	public string Name {
		get{ return _name; }
		set{ _name = value; }
	}
	
}
// Adding a note to revise Attributes
public enum AttributeName {
	Strength,
	Stamina,
	Speed,
	Intelligence,
	Charisma
	
}