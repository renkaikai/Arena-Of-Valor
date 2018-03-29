using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    public Toggle toggle;

    public Text nametext;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        nametext.text = Game.Instance.player.username;
        //print(nametext.text);
    }

    public void OnStartButtonClick()
    {
        if (toggle.isOn)
        {
            //加载下一个场景
            SceneManager.LoadScene("GameLobby");
        }
    }
    
}
