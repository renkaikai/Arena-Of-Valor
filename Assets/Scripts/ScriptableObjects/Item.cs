using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/MyTeamGame/Item")]
public class Item : ItemBase { 
     
    public enum Type
    {
        MagicAttack,
        PhysicsAttack,
        Defense,
        Move
    }
    /// <summary>
    /// 装备类型
    /// </summary>
    public Type type;
    /// <summary>
    /// 装备使用效果
    /// </summary>
    public AttributeEffect[] attributeEffects;
}
