using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecoverySkill : MonoBehaviour{
    private Skill recoverSkill;
    //冷却等级
    private int cdLevel = 0;
    //技能冷却时间
    //[HideInInspector]
    private float coldTime;
    //技能冷却计时
    //[HideInInspector]
    private float timer = 0;
    //[HideInInspector]
    private bool startTimer = false;
    //技能冷却图片
    public Image skillImage;
    public Image skillCdImage;

    private PlayerController pc;

    private Button btn;
    // Use this for initialization
    void Start () {       
        recoverSkill = Game.Instance.database.skills[6];

        //添加技能图标
        skillImage.sprite = recoverSkill.icon;
        skillCdImage.sprite = recoverSkill.icon;
        skillCdImage.fillAmount = 0;

        pc = this.GetPlayerController(0);
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

        coldTime = recoverSkill.cdLevels[cdLevel].value;       
        startTimer = true;
        cdLevel++;
        if (cdLevel >= recoverSkill.cdLevels.Length)
        {           
            cdLevel = recoverSkill.cdLevels.Length - 1;
        }
        //向playerController发送点击了恢复技能的信息
        pc.ReleasingSkills(recoverSkill);
    }
}
