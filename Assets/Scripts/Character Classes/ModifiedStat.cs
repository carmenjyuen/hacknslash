/// <summary>
/// ModifiedStat.cs
/// Carmen Yuen
/// July 8, 2012
/// 
/// This is the base class for all stats that will be modifiable by attributes.
/// </summary> 
using System.Collections.Generic;				//Generic was added so we can use the List<>

public class ModifiedStat : BaseStat {
	private List<ModifyingAttribute> _mods;   	//A list of Attributes that modify this stat
	private int _modValue;                    	// The amount added to the baseValue from the modifiers
	
	/// <summary>
	/// Initializes a new instance of the <see cref="ModifiedStat"/> class.
	/// </summary>
	public ModifiedStat() {
		_mods = new List<ModifyingAttribute>();
		_modValue = 0;
	}
	
	/// <summary>
	/// Add a ModifyingAttribute to our list of mods for this ModifiedStat.
	/// </summary>
	/// <param name='mod'>
	/// Mod.
	/// </param>/
	public void AddModifier( ModifyingAttribute mod) {
		_mods.Add(mod);
		
	}
	
	/// <summary>
	/// Reset modValue to 0.
	/// Check to see if we have atleast 1 ModifyingAttribute in our list of mods
	/// If we do, then iterate through the list and add the AdjustedBaseValue * ratio of modValue 
	/// </summary>
	private void CalculateModValue() {
		_modValue = 0;
		
		if(_mods.Count > 0) 
			foreach(ModifyingAttribute att in _mods)
				_modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio);
		
	}
	
	/// <summary>
	/// This function is overriding the AdjustedBaseValue in the BaseStat class.
	/// Calculate the AdjustedBaseValue from the BaseValue + BuffValue + modValue
	/// </summary>
	/// <value>
	/// The adjusted base value.
	/// </value>
	public new int AdjustedBaseValue {
		get{return BaseValue + BuffValue + _modValue; }
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update() {
		CalculateModValue();	
	}
	
	public string GetModifyingAttributesString() {
		string temp = "";
		
//		UnityEngine.Debug.Log(_mods.Count);
		
		for(int cnt = 0; cnt < _mods.Count; cnt++) {
			temp += _mods[cnt].attribute.Name;
			temp += "_";
			temp += _mods[cnt].ratio;
			
			if(cnt < _mods.Count - 1)
				temp += "|";
			
			
			UnityEngine.Debug.Log(temp);

		}
		
		return temp;
	}
	
}

/// <summary>
/// A structure that will hold an Attribute and a ratio that will be added as a modifying attribue to our ModifiedStats
/// </summary>
public struct ModifyingAttribute {
	public Attribute attribute;			//the attribute to be used as a modifier
	public float ratio;					//the percent of the attributes AdjustedBaseValue that will be applied to the ModifiedStat
	
	/// <summary>
	/// Initializes a new instance of the <see cref="ModifyingAttribute"/> struct.
	/// </summary>
	/// <param name='att'>
	/// Att. the attribute to be used
	/// </param>
	/// <param name='rat'>
	/// Rat. the ratio to use
	/// </param>
	public ModifyingAttribute(Attribute att, float rat) {
//		UnityEngine.Debug.Log("Modifying Attribute Created");
		attribute = att;
		ratio = rat;
	}
	
}