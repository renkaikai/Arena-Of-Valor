using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialSkill : MonoBehaviour{
    private Hero selectHero;  
    private Skill specialSkill;

    //冷却等级
    private int cdLevel = 0;
    //技能冷却时间
    private float coldTime;
    //技能冷却计时
    private float timer = 0;
    private bool startTimer = false;
    //技能冷却图片
    public Image skillImage;
    public Image skillCdImage;

    private PlayerController pc;
    private Button btn;
    // Use this for initialization
    void Start()
    {
        pc = this.GetPlayerController(0);       
        HeroCharacter c = (HeroCharacter)pc.GetCharacter();
        selectHero=c.hero;
        specialSkill = selectHero.specialSkill;

        //添加技能图标
        skillImage.sprite = specialSkill.icon;
        skillCdImage.sprite = specialSkill.icon;
        skillCdImage.fillAmount = 0;

        btn = GetComponentInChildren<Button>();
    }

    // Update is called once per frame 
    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            skillCdImage.fillAmount = (coldTime - timer) / coldTime;
        }
        if (timer >= coldTime)
        {
            startTimer = false;
            timer = 0;
            btn.interactable = true;
        }
    }

    //冷却
    public void ColdClick()
    {
        btn.interactable = false;
        skillCdImage.fillAmount = 1;

        coldTime = specialSkill.cdLevels[cdLevel].value;
        //print("冷却时间" + coldTime);
        startTimer = true;
        cdLevel++;
        //print("冷却等级"+cdLevel);
        if (cdLevel >= specialSkill.cdLevels.Length)
        {
            //print("冷却满级了");
            cdLevel = specialSkill.cdLevels.Length - 1;
        }
        //向playerController发送点击了恢复技能的信息
        pc.ReleasingSkills(specialSkill);
    }

}


