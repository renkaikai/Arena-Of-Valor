using UnityEngine;

/// <summary>
/// 英雄资源对象
/// </summary>
[CreateAssetMenu(menuName = "Custom/MyTeamGame/Hero")]
public class Hero : ItemBase {
    public GameObject heroPrefab;
    /// <summary>
    /// 英雄卡片
    /// </summary>
    /// 
    public Sprite cardIcon;
    /// <summary>
    /// 英雄属性
    /// </summary>         
    public AttributeValue[] attributes;
    /// <summary>
    /// 英雄基本技能
    /// </summary>
    public Skill[] skills;
    /// <summary>
    /// 特殊技能
    /// </summary>
    public Skill specialSkill;
    /// <summary>
    /// 推荐装备(用于AI角色)
    /// </summary>
    public Item[] suggestItems;
}
