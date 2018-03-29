using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{
   
    //将两个输入框拉进来
    public InputField usertext;
    public InputField passwordtext;

    private string username;
  
    private string password;
    //输入错误重新输入
    public Text Showmessage;
   
    void Update()
    {
        username = usertext.text.ToString();
        password = passwordtext.text.ToString();
    }

    //点击登陆按钮
    public void OnLoginButtonClick()
    {

        {

            //登陆成功
            if (username == SubmitButton.user && password == SubmitButton.password&& username != ""&&password!="")
            {
                Player player = new Player();
                player.username = username;
                
                player.awardnumber = 1000;
                Game.Instance.player = player;



                //加载场景
                SceneManager.LoadScene("Start");
            }
            else
            {
                //用户名或密码错误
                Showmessage.gameObject.SetActive(true);
                Showmessage.text = "您的账号或密码输入错误,请重新输入!";
                //调用协成
                StartCoroutine(DisappearMessage());

            }
            //登陆失败
            if (username == null || password == null)
            {
                //请输入用户名或密码
                Showmessage.gameObject.SetActive(true);
                Showmessage.text = "您的账号或密码输入错误,请重新输入!";
                StartCoroutine(DisappearMessage());
            }
        }

        
    }
    IEnumerator DisappearMessage()
    {
        //协成在一秒后返回一个值/执行完再执行下一个
        yield return new WaitForSeconds(1);
        Showmessage.gameObject.SetActive(false);
    }
  


}
