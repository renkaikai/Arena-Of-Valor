using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家状态
/// </summary>
public class PlayerState : MonoBehaviour {
    /// <summary>
    /// 杀敌次数
    /// </summary>
    public int kills;
    /// <summary>
    /// 杀兵数量
    /// </summary>
    public int killPawns;
    /// <summary>
    /// 助攻次数
    /// </summary>
    public int assits;
    /// <summary>
    /// 死亡次数
    /// </summary>
    public int deaths;
    /// <summary>
    /// 游戏进行中的玩家级别
    /// </summary>
    public int level;
    /// <summary>
    /// 角色当前属性值
    /// </summary>
    public AttributeValue[] attributes;
    /// <summary>
    /// 角色属性最大值
    /// </summary>
    public AttributeValue[] maxAttributes;
    /// <summary>
    /// 角色当前拥有的装备
    /// </summary>
    public List<Item> possessItems;

    public void ApplyDamge()
    {
       
    }
}
