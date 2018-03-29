using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/MyTeamGame/Database")]
public class Database : ScriptableObject {
    public List<AttributeItem> attributes;
    public List<Item> items;
    public List<Skill> skills;
    public List<Hero> heroes;
    public Skill basicSkill;
    public List<AttributeValue> crystalAttributes;
    public List<AttributeValue> guardTowerAttributes;
    public List<AttributeValue> birthPlaceAttributes;

    /// <summary>
    /// 生成物品编号
    /// </summary>
    public void GenerateIDs()
    {
        int i = 0;
        foreach(AttributeItem item in attributes)
        {
            item.id = i++;
        }
        i = 0;
        foreach (Item item in items)
        {
            item.id = i++;
        }
        i = 0;
        foreach (Skill item in skills)
        {
            item.id = i++;
        }
        i = 0;
        foreach (Hero item in heroes)
        {
            item.id = i++;
        }
    }
    /// <summary>
    /// 根据编号获取英雄对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Hero GetHeroById(int id)
    {
        return heroes[id];
    }
}
