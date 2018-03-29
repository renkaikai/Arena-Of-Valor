using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInventory : MonoBehaviour
{
    public GameObject List;
    public GameObject Icon;
    private int Amount;
    public static int i;
    
    void Start()
    {
        Amount = Game.Instance.gameMode.teamSize*2;
        HeroIcons newIcon;
        for (i = 0; i < Amount; i++)
        {
            newIcon = Instantiate(Icon, List.transform).GetComponent<HeroIcons>();
            if (i % 2 == 0)
            {
                newIcon.isMyHero = true;
            }
            else
            {
                newIcon.isMyHero = false;

            }
        }
    }


}
