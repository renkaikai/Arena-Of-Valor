using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillsPanel : MonoBehaviour
{
    public event Action<Hero> OnSelectHero;

    // The reference of  item list grid layout game object
    public GameObject SkillList;
    // The reference of item slot prefab
    public GameObject SkillIcon;
    // The amount of item slots
    private int IconAmount = 2;

    public static List<Skill> Skills;

    public static List<SkillIcon> SkillsIcons;
    private SkillIcon newIcon;


    void Start()
    {
        Skills = Game.Instance.database.skills;
        SkillsIcons = new List<SkillIcon>();

        for (int i = 0; i < IconAmount; i++)
        {
            newIcon = Instantiate(SkillIcon, SkillList.transform).GetComponent<SkillIcon>();
            newIcon.id = i;
            newIcon.skillpanel = this;
            SkillsIcons.Add(newIcon);
            newIcon.gameObject.SetActive(false);
        }

    }

}
