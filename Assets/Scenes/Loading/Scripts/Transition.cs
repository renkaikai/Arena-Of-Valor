using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    //Game里 public int[,] teamHeroIds;
    public Text _progress;
    /// <summary>
    /// 显示用户名的Text
    /// </summary>
    public Text _userNameText;
    /// <summary>
    /// 显示我方英雄
    /// </summary>
    public Image playerImage;
    /// <summary>
    /// 显示敌方英雄
    /// </summary>
    public Image otherImage;
    /// <summary>
    /// 显示特殊技能
    /// </summary>
    public Image specialSkillImage;

    private Sprite specialSkill;
    /// <summary>
    ///  双方战队英雄编号
    /// </summary>
    private int[,] teamHeroId;
    /// <summary>
    /// 我方英雄图片显示
    /// </summary>
    private Sprite playerSprite;
    /// <summary>
    /// 敌方英雄图片显示
    /// </summary>
    private Sprite otherSprite;

    private AsyncOperation async;//异步加载
    private Player player;
    private Hero hero1;
    private Hero hero2;
    /// <summary>
    /// 英雄列表
    /// </summary>
    private List<Hero> _heros;

    void Start()
    {
        player = Game.Instance.player;
        //获取用户名
       //player.username="zxc";

       //print(player.username);
        _userNameText.text = player.username;

       // Game.Instance.teamHeroIds = new int[,]{{2},{3}};

        _heros = Game.Instance.database.heroes;
        teamHeroId = Game.Instance.teamHeroIds;
        //我方英雄
        hero1 = _heros[teamHeroId[0, 0]];
        //敌方英雄
        hero2 = _heros[teamHeroId[1, 0]];
        
        //获取我方英雄的特殊技能
        print(hero1);
        print(hero2);
        specialSkill = hero1.specialSkill.icon;
        specialSkillImage.sprite = specialSkill;
        //在Hero类中获取我方英雄图片
        playerImage.sprite = hero1.cardIcon;
        //在Hero类中获取敌方英雄图片
        otherImage.sprite = hero2.cardIcon;
        
        StartCoroutine(LoadScene());
    }
    /// <summary>
    /// 加载进度
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadScene()
    {
        int displayProgress = 0;
        //int toProgress = 0;
        async = SceneManager.LoadSceneAsync("man_machine_1vs1");
        async.allowSceneActivation = false;
        //发布webGL版本时会导致卡死
        //while (async.progress < 0.9f)
        //{
        //    toProgress = (int)async.progress * 100;
        //    while (displayProgress < toProgress)
        //    {
        //        ++displayProgress;
        //        _progress.text = displayProgress + "%";
        //        yield return new WaitForEndOfFrame();
        //    }
        //}
        int toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            _progress.text = displayProgress + "%";
            yield return new WaitForEndOfFrame();//等待帧结束
        }
        async.allowSceneActivation = true;
    }




}
