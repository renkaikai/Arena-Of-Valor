using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/MyTeamGame/Skill")]
public class Skill : ItemBase
{
    

	public enum Type
	{
		JINeng,
		YXJN
	}
	/// <summary>
	/// 装备类型
	/// </summary>
	public Type type;

    public AttributeValue[] attackLevels;
    public AttributeValue[] cdLevels;    
    public AttributeEffect[] attributeEffects;
    [HideInInspector]
    public int level;

}
