/// <summary>
/// Skill.cs
/// Carmen Yuen
/// July 12, 2012
/// 
/// This class contains all the extra functions that are needed for a skill
/// </summary>

public class Skill : ModifiedStat {
	private bool _known;				//A boolean variable to toggle if a a character knows a skill
	
	/// <summary>
	/// Initializes a new instance of the <see cref="Skill"/> class.
	/// </summary>
	public Skill() {
//		UnityEngine.Debug.Log("Skill Created");
		_known = false;
		ExpToLevel = 25;
		LevelModifier = 1.1f;

	}
	
	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="Skill"/> is known.
	/// </summary>
	/// <value>
	/// <c>true</c> if known; otherwise, <c>false</c>.
	/// </value>
	public bool Known {
		get{
			return _known; 
		
		}
		set{
			_known = value;
		}
	}
}

/// <summary>
/// This enumeration is just a list of skills the player can learn
/// </summary>
public enum SkillName {
	Melee_Offense,
	Melee_Defense,
	Ranged_Offense,
	Ranged_Defense,
	Magic_Offense,
	Magic_Defense
}