using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroCharacter : Character {
    [HideInInspector]
    public Hero hero;

    protected float HPF;//获取英雄当前HP float值
    protected float HPMaxF;//获取英雄最大HP float值
    protected float MPF;//获取英雄当前MHP float值
    protected float MPMaxF;//获取英雄最大MHP float值
    public Slider bloodslider;//血条
    public Slider buleslider;//蓝量
    public Image Expimage;//经验背景图
    public Text Exptext;//经验文本
    private PlayerState playerstate;//英雄属性
    public MeshRenderer mapsign;

    // Use this for initialization
    void Start() {

        playerstate = controller.playerState;
       
        //设置蓝条
        MPF = playerstate.attributes.GetAttributeValue(AttributeItem.MP).value;
        MPMaxF = playerstate.attributes.GetAttributeValue(AttributeItem.MP).value;

        //辨别敌我血条,蓝条和设置小地图动态面板
        Transform bloodfill = bloodslider.fillRect;
        Transform bulefill = buleslider.fillRect;
        bulefill.GetComponent<Image>().color = Color.blue;

        if (controller.teamIndex == 0)
        {
            bloodfill.GetComponent<Image>().color = Color.green;
            mapsign.sharedMaterial.color = Color.green;
        }
        else
        {
            bloodfill.GetComponent<Image>().color = Color.red;
            mapsign.sharedMaterial.color = Color.red;
        }
        //设置经验内容
        Expimage.color = Color.gray;
        Exptext.text = playerstate.level.ToString();
        Exptext.color = Color.white;
        Exptext.fontSize = 15;
    }

    // Update is called once per frame
    void Update()
    {
        //设置血条
        HPF = playerstate.attributes.GetAttributeValue(AttributeItem.HP).value;
        HPMaxF = playerstate.maxAttributes.GetAttributeValue(AttributeItem.HP).value;
        bloodslider.wholeNumbers = true;
        bloodslider.minValue = 0;
        bloodslider.maxValue = HPMaxF;
        bloodslider.value = HPF;

        buleslider.wholeNumbers = true;
        buleslider.minValue = 0;
        buleslider.maxValue = MPMaxF;
        buleslider.value = MPF;
        bloodslider.value = playerstate.attributes.GetAttributeValue(AttributeItem.HP).value;
    }
}
