using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour {

    public Text Nametext;
    public Text GoldText;
    public Text JewelText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        Nametext.text = Game.Instance.player.username;
        GoldText.text = Game.Instance.player.awardnumber.ToString();
        JewelText.text = Game.Instance.player.awardnumber.ToString();


    }
    public void OnReturnButton()
    {
        SceneManager.LoadScene("Login");
    }
}
