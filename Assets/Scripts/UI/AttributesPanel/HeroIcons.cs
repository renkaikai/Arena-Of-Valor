using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroIcons : MonoBehaviour {
    [HideInInspector]
    public PanelInventory panel;
    [HideInInspector]
    public List<Hero> heroes;
    public static int teamNum;
    // Use this for initialization
    [HideInInspector]
    public bool isMyHero;
    void Start () {
        heroes = Game.Instance.database.heroes;
        panel = GetComponent<PanelInventory>();       
    }
	
	// Update is called once per frame
	void Update () {
        if (isMyHero)
        {
            //英雄头像
            transform.GetChild(0).GetComponent<Image>().sprite = heroes[Game.Instance.gameMode.heroIds[0, 0]].icon;
            //英雄名字
            transform.GetChild(1).GetComponent<Text>().text = heroes[Game.Instance.gameMode.heroIds[0, 0]].name;
            //用户名
            //transform.GetChild(2).GetComponent<Text>().text = Game.Instance.player.username;
            if (this.gameObject.transform.parent.name == "HeroList")
            {

                //print("我方属性");
                //英雄信息:
                //生命
                transform.GetChild(3).GetChild(0).GetComponent<Text>().text = this.GetPlayerController(0).playerState.maxAttributes.GetAttributeValue("HP").value.ToString();

                //物攻
                transform.GetChild(3).GetChild(1).GetComponent<Text>().text = this.GetPlayerController(0).playerState.maxAttributes.GetAttributeValue("PA").value.ToString();
                //魔攻
                transform.GetChild(3).GetChild(2).GetComponent<Text>().text = this.GetPlayerController(0).playerState.maxAttributes.GetAttributeValue("MP").value.ToString();
                //物抗
                transform.GetChild(3).GetChild(3).GetComponent<Text>().text = this.GetPlayerController(0).playerState.maxAttributes.GetAttributeValue("MD").value.ToString();
                //魔抗
                transform.GetChild(3).GetChild(4).GetComponent<Text>().text = this.GetPlayerController(0).playerState.maxAttributes.GetAttributeValue("PD").value.ToString();
            }
            else
            {
                //英雄装备栏
                //List
                //print("我方装备");
                for (int i = 0; i < this.GetPlayerController(0).playerState.possessItems.Count; i++)
                {
                    //print("进来啦");
                    transform.GetChild(3).GetChild(i).GetComponent<Image>().sprite = this.GetPlayerController(0).playerState.possessItems[i].icon;
                }
                //英雄信息
                //击杀次数
                transform.GetChild(4).GetChild(0).GetComponent<Text>().text = this.GetPlayerController(0).playerState.kills.ToString();
                //击死亡次数
                transform.GetChild(4).GetChild(1).GetComponent<Text>().text = this.GetPlayerController(0).playerState.deaths.ToString();
                //助攻次数
                transform.GetChild(4).GetChild(2).GetComponent<Text>().text = this.GetPlayerController(0).playerState.assits.ToString();
                //补兵次数
                transform.GetChild(4).GetChild(3).GetComponent<Text>().text = "金钱数";
            }
        }
        else
        {
            //英雄头像
            transform.GetChild(0).GetComponent<Image>().sprite = heroes[Game.Instance.gameMode.heroIds[1, 0]].icon;
            //英雄名字
            transform.GetChild(1).GetComponent<Text>().text = heroes[Game.Instance.gameMode.heroIds[1, 0]].name;
            //用户名
            //transform.GetChild(2).GetComponent<Text>().text = Game.Instance.player.username;
            //print(this.gameObject.transform.parent.name);
            if (this.gameObject.transform.parent.name == "HeroList")
            {
                //print("AI属性");

                //英雄信息:
                //生命
                transform.GetChild(3).GetChild(0).GetComponent<Text>().text =this.GetAIController(0).playerState.maxAttributes.GetAttributeValue("HP").value.ToString();

                //物攻
                transform.GetChild(3).GetChild(1).GetComponent<Text>().text = this.GetAIController(0).playerState.maxAttributes.GetAttributeValue("PA").value.ToString();
                //魔攻
                transform.GetChild(3).GetChild(2).GetComponent<Text>().text = this.GetAIController(0).playerState.maxAttributes.GetAttributeValue("MP").value.ToString();
                //物抗
                transform.GetChild(3).GetChild(3).GetComponent<Text>().text = this.GetAIController(0).playerState.maxAttributes.GetAttributeValue("MD").value.ToString();
                //魔抗
                transform.GetChild(3).GetChild(4).GetComponent<Text>().text = this.GetAIController(0).playerState.maxAttributes.GetAttributeValue("PD").value.ToString();
            }
            else
            {
                //print("AI装备");
                //英雄装备栏
                //List
                for (int i = 0; i < this.GetAIController(0).playerState.possessItems.Count; i++)
                {
                    //print("AI进来啦");
                    transform.GetChild(3).GetChild(i).GetComponent<Image>().sprite = this.GetAIController(0).playerState.possessItems[i].icon;
                }
                //英雄信息
                //击杀次数
                transform.GetChild(4).GetChild(0).GetComponent<Text>().text = this.GetAIController(0).playerState.kills.ToString();
                //击死亡次数
                transform.GetChild(4).GetChild(1).GetComponent<Text>().text = this.GetAIController(0).playerState.deaths.ToString();
                //助攻次数
                transform.GetChild(4).GetChild(2).GetComponent<Text>().text = this.GetAIController(0).playerState.assits.ToString();
                //补兵次数

                transform.GetChild(4).GetChild(3).GetComponent<Text>().text = "金钱数";
            }
        }
    }
}
