using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Text1 : MonoBehaviour {
	public GameObject SkillIcon;
	public Text SkillDreation;

	[HideInInspector]
	public Skill selectSkill;	//当前选择技能
	void Start () 
	{
		foreach (Skill skill in Game.Instance.database.skills) {
			if (skill.type == Skill.Type.JINeng) {
				GameObject specialSkill = Instantiate (SkillIcon, this.transform);
				specialSkill.GetComponent<Text2> ().skill = skill;
				specialSkill.GetComponent<Text2> ().SkillDreation = SkillDreation;
				specialSkill.GetComponent<Text2> ().SkillPanel = this;
			}
		}

	}
}
