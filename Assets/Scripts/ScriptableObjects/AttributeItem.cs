using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Custom/MyTeamGame/AttributeItem")]
public class AttributeItem : ScriptableObject {
    public static string HP = "HP";//生命值
    public static string MP = "MP";//法力值
    public static string AS = "AS";//攻击速度
    public static string CDR = "CDR";//冷却减少的时间
    public static string CD = "CD";//冷却时间
    public static string CP = "CP";//暴击几率
    public static string Hph = "Hph";//吸血
    public static string MA = "MA";//法术攻击
    public static string MD = "MD";//法术防御
    public static string MS = "MS";//移动速度
    public static string PP = "PP";//穿透
    public static string PA = "PA";//物理攻击
    public static string PD = "PD";//物理防御
    public static string AR = "AR";//是否远程攻击
    
    //public static string MP = "MP";

    public int id;
    public string description;
    public string abbr;
    public Sprite icon;
    
}
