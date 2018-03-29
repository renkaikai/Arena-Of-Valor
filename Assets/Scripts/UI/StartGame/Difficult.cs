using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Difficult : MonoBehaviour {
    public GameObject ChooseScene;//当前所在画布对象
    public GameObject DifficultScene;//等级按钮
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnReturnButton()
    {
        ChooseScene.SetActive(false);//隐藏画布
        if(DifficultScene==true)
        {
            DifficultScene.SetActive(false);
        }
    }

    public void OnEntryButton(int level)
    {
        //公开等级
        Game.Instance.difficultLevel = level;
        //切换下一个界面
        SceneManager.LoadScene("HeroSelecting");
    }
}
