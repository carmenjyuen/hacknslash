/// <summary>
/// BaseStat.cs
/// Carmen Yuen
/// July 8, 2012
/// 
/// This is the base class for all stats in game.
/// </summary>

using UnityEngine;
public class BaseStat {
	public const int STARTING_EXP_COST = 100;	//publicly assesable value for all base stats to start at
	
	private int _baseValue;						//the base value of this stat
	private int _buffValue;						//the amount of the buff to this stat
	private int _expToLevel;					//the total amount of exp needed raise this skill
	private float _levelModifier;				//the modifier applied to the exp needed to raise the skill
	
	private string _name;							//this is the name of the attribute	
	
	/// <summary>
	/// Initializes a new instance of the <see cref="BaseStat"/> class.
	/// </summary>
	public BaseStat(){
//		Debug.Log("Base Stat Created");
		_baseValue = 0;
		_buffValue = 0;
		_levelModifier = 1.1f;
		_expToLevel = STARTING_EXP_COST;
		_name = "";

	}
	
#region Basic Setters and Getters
	/// <summary>
	/// Gets or sets the baseValue.
	/// </summary>
	/// <value>
	/// The baseValue.
	/// </value>
	//Basic Setters and Getters
	public int BaseValue {
		get{
			return _baseValue;
		}
		set{
			_baseValue = value;
		}
	}
	/// <summary>
	/// Gets or sets the buffValue.
	/// </summary>
	/// <value>
	/// The buffValue.
	/// </value>
	public int BuffValue {
		get{
			return _buffValue;
		}
		set{
			_buffValue = value;
		}
	}
	
	/// <summary>
	/// Gets or sets the expToLevel.
	/// </summary>
	/// <value>
	/// The expYoLevel.
	/// </value>
	public int ExpToLevel {
		get{
			return _expToLevel;
		}
		set{
			_expToLevel = value;
		}
	}
	
	public float LevelModifier {
		get{
			return _levelModifier;
		}
		set{
			_levelModifier = value;
		}
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
	
#endregion
	
	/// <summary>
	/// Calculates the exp to level.
	/// </summary>
	/// <returns>
	/// The exp to level.
	/// </returns>
	private int CalculateExpToLevel() {
		return (int)(_expToLevel * _levelModifier);
	}
	
	/// <summary>
	/// Assign the new value to expToLevel and then increase the baseValue by one.
	/// </summary>
	public void LevelUp() {
		_expToLevel = CalculateExpToLevel();
		_baseValue++;
	}
	
	/// <summary>
	/// Recalculates the adjusted base value and returns it.
	/// </summary>
	/// <returns>
	/// The adjusted base value.
	/// </returns>	
	public int AdjustedBaseValue {
		get{
			return _baseValue + _buffValue; }
	}
		
}
