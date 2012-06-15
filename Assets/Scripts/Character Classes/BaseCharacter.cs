using UnityEngine;
using System.Collections;
using System;                 //added to access the enum class

public class BaseCharacter : MonoBehaviour {
	private string _name;
	private int _level;
	private uint _freeExp;
	
	private Attribute[] _primaryAttribute;
	private Vital[] _vital;
	private Skill[] _skill;
	
	
	public void Awake() {
		_name =string.Empty;
		_level = 0;
		_freeExp = 0;
		
		_primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];
		
		SetupPrimaryAttributes();
		SetupVitals();
		SetupSkills();
	}
		
	public string Name {
		get{
			return _name;
		}
		set{
			_name = value;
		}
	}
	public int Level {
		get{
			return _level;
		}
		set{
			_level = value;
		}
	}			
		public uint FreeExp {
		get{
			return _freeExp;
		}
		set{
			_freeExp = value;
		}
	}
	
	public void AddExp(uint exp) {
		_freeExp += exp;
		
		CalculateLevel();	
	}
	
	
	// tave average f all the players skills and assign that as the player level
	public void	CalculateLevel() {
	}
	
	private void SetupPrimaryAttributes() {
		for(int cnt = 0; cnt < _primaryAttribute.Length; cnt++) { 
			_primaryAttribute[cnt] = new Attribute();
			_primaryAttribute[cnt].Name = ((AttributeName)cnt).ToString();
		}
	}
	
	private void SetupVitals() {
		for(int cnt = 0; cnt < _vital.Length; cnt++) 
			_vital[cnt] = new Vital();
		
		SetupVitalModifiers();

	}
	
	private void SetupSkills() {
		for(int cnt = 0; cnt < _skill.Length; cnt++) 
			_skill[cnt] = new Skill();
		
		SetupSkillModifiers();

	}
	
	public Attribute GetPrimaryAttribute(int index) {
		return _primaryAttribute[index];
	}

	public Vital GetVital(int index) {
		return _vital[index];
	}
	
	public Skill GetSkill(int index) {
		return _skill[index];
	}
	

	private void SetupVitalModifiers() {
		//health
		GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Strength), .5f));
		//energy
		GetVital((int)VitalName.Energy).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Stamina), 1));
		//mana
		GetVital((int)VitalName.Mana).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intelligence), .5f));
						
	}
	
	private void SetupSkillModifiers() {
		
		//Melee Offense
		GetSkill((int)SkillName.Melee_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Strength), .33f));
		GetSkill((int)SkillName.Melee_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		//Melee Defense
		GetSkill((int)SkillName.Melee_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Strength), .33f));
		GetSkill((int)SkillName.Melee_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Stamina), .33f));

		//Magic Offense
		GetSkill((int)SkillName.Magic_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intelligence), .33f));
		GetSkill((int)SkillName.Magic_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		//Magic Defense
		GetSkill((int)SkillName.Magic_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intelligence), .33f));
		GetSkill((int)SkillName.Magic_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		
		//Ranged Offense
		GetSkill((int)SkillName.Ranged_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Strength), .33f));
		GetSkill((int)SkillName.Ranged_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		//Ranged Defense
		GetSkill((int)SkillName.Ranged_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Strength), .33f));
		GetSkill((int)SkillName.Ranged_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));

	}

	public void StatUpdate() {
		for(int cnt = 0; cnt < _vital.Length; cnt++)
			_vital[cnt].Update();
		
		for(int cnt = 0; cnt < _skill.Length; cnt++)
			_skill[cnt].Update();
			
	}
}

