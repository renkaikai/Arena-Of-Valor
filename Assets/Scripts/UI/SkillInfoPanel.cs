 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillInfoPanel : MonoBehaviour{

    //Animator anim;
    //public Image skill0Image;//游戏中技能1
    //public Image skill1Image;//游戏中技能2


    //bool isCD=true;//判断是否冷却

    //float resttime;
    [HideInInspector]
   public Skill  skill;


    public Text Skillname; //技能名称
    public Text CD_time; //冷却时间
    public Text MP_use; //法力消耗
    public Text Skill_describe; //技能描述


    public Text Hurt_Lv1;
    public Text Hurt_Lv2;
    public Text Hurt_Lv3;
    public Text Hurt_Lv4;
    public Text Hurt_Lv5;
    public Text Hurt_Lv6;

    public Text CD_Lv1;
    public Text CD_Lv2;
    public Text CD_Lv3;
    public Text CD_Lv4;
    public Text CD_Lv5;
    public Text CD_Lv6;
    void Start()
    {
        Skillname.text = skill.name;
        CD_time.text = skill.cdLevels[0].value.ToString();
        MP_use.text = skill.cdLevels[0].value.ToString();
        Skill_describe.text = skill.description;

        Hurt_Lv1.text = skill.attackLevels[0].value.ToString();
        Hurt_Lv2.text = skill.attackLevels[1].value.ToString();
        Hurt_Lv3.text = skill.attackLevels[2].value.ToString();
        Hurt_Lv4.text = skill.attackLevels[3].value.ToString();
        Hurt_Lv5.text = skill.attackLevels[4].value.ToString();
        Hurt_Lv6.text = skill.attackLevels[5].value.ToString();

        CD_Lv1.text = skill.cdLevels[0].value.ToString();
        CD_Lv2.text = skill.cdLevels[1].value.ToString();
        CD_Lv3.text = skill.cdLevels[2].value.ToString();
        CD_Lv4.text = skill.cdLevels[3].value.ToString();
        CD_Lv5.text = skill.cdLevels[4].value.ToString();
        CD_Lv6.text = skill.cdLevels[5].value.ToString();

    }
}
    

   

	

