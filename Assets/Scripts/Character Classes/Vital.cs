/// <summary>
/// Vital.cs
/// Carmen Yuen
/// July 12, 2012
/// 
/// This class contains all the extra functions for a characters vitals
/// </summary>

public class Vital : ModifiedStat {
	private int _curValue; 				//this is the current value of this vital
	
	/// <summary>
	/// Initializes a new instance of the <see cref="Vital"/> class.
	/// </summary>
	public Vital() {
		UnityEngine.Debug.Log("Vital Created");
		
		_curValue = 0;
		ExpToLevel = 50;
		LevelModifier = 1.1f;
		
	}
	
	/// <summary>
	/// When getting the _curValue, make sure that it is not greater than our AdjustedBaseValue.
	/// If it is, make it the same as our AdjustedBaseValue
	/// </summary>
	/// <value>
	/// The current value.
	/// </value>
	public int CurValue {
		get{
			if(_curValue > AdjustedBaseValue)
				_curValue = AdjustedBaseValue;
			
			return _curValue;
		}
		set{
			_curValue = value;
		}
		
	}
	
}

/// <summary>
/// This enumeration is just a list of the vitals our character will have.
/// </summary>
public enum VitalName {
	Health,
	Energy,
	Mana
}