using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ClickSkillBtn : MonoBehaviour,IPointerClickHandler
{
	public GameObject SkillPanel;
	public GameObject ZHSSkills;

    public Image skill1;
    public Image skill2;

	public Skill skill;

  	public void OnPointerClick (PointerEventData eventData)
	{
		if (SkillPanel.GetComponent<Text1> ().selectSkill) {
			skill = SkillPanel.GetComponent<Text1> ().selectSkill;
			ZHSSkills.SetActive (false);

            Confirm.hero.specialSkill = skill;

        }
        skill1.sprite = SkillPanel.GetComponent<Text1>().selectSkill.icon;
        skill2.sprite = SkillPanel.GetComponent<Text1>().selectSkill.icon;
    }
}
