using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HeroIcon : MonoBehaviour, IPointerClickHandler
{
    public Image iconImage;
    [HideInInspector]
    public int id;
    [HideInInspector]
    public Hero hero;
    [HideInInspector]
    public HeroesPanel heropanel;

    private Image heroIconImage;

    // Update is called once per frame
    void Start()
    {
        heroIconImage = GetComponent<Image>();
        heroIconImage.sprite = hero.icon;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SkillsPanel.SkillsIcons[0].gameObject.SetActive(true);
        SkillsPanel.SkillsIcons[1].gameObject.SetActive(true);
        SkillsPanel.SkillsIcons[0].skill = hero.skills[0];
        SkillsPanel.SkillsIcons[1].skill = hero.skills[1];
        SkillsPanel.SkillsIcons[0].iconImage.sprite = hero.skills[0].icon;
        SkillsPanel.SkillsIcons[1].iconImage.sprite = hero.skills[1].icon;
        if (GameObject.Find("HeroShow").transform.childCount > 0)
        {
            Destroy(GameObject.Find("HeroShow").transform.GetChild(0).gameObject);
        }
        GameObject.Instantiate(hero.prefab, GameObject.Find("HeroShow").transform);
        GameObject.Find("HeroImage").GetComponent<Image>().sprite = hero.icon;
        Confirm.IsClickHero = true;
        Confirm.hero = hero;
    }
}
