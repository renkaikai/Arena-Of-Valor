using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroesPanel : MonoBehaviour
{
    public event Action<Hero> SelectHero;

    // The reference of  item list grid layout game object
    public GameObject HeroList;
    // The reference of item slot prefab
    public GameObject HeroIcon;

    public static List<Hero> Heroes;

    private List<GameObject> HeroesIcons;
    void Start()
    {
        Heroes = Game.Instance.database.heroes;
        HeroesIcons = new List<GameObject>();
        foreach  (Hero hero in Heroes)
        {
            GameObject newIcon;
            newIcon = Instantiate(HeroIcon, HeroList.transform);
            newIcon.GetComponent<HeroIcon>().hero = hero;
            newIcon.GetComponent<HeroIcon>().heropanel = this;
            HeroesIcons.Add(newIcon);
        }
    }

    public void OnSelectHero(Hero hero)
    {
        if (Heroes != null)
        {
            SelectHero(hero);
        }
    }
}
