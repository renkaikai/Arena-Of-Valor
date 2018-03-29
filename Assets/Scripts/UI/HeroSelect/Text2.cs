using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Text2 : MonoBehaviour,IPointerClickHandler
{
	[HideInInspector]
	public Skill skill;	//获取当前格子的技能
	[HideInInspector]
	public Text SkillDreation;	//获取当前技能描述

	[HideInInspector]
	public Text1 SkillPanel;
	void Start () 
	{
		GetComponent<Image> ().sprite = skill.icon;
		transform.GetChild (0).GetComponent<Text> ().text = skill.name;
	}
	public void OnPointerClick (PointerEventData eventData)
	{
		SkillDreation.text = skill.description;
		SkillPanel.selectSkill = skill;
	}
}
