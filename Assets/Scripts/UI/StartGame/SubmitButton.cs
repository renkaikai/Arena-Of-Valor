using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour
{
    public GameObject Login;
    //将两个文本拉进来
    public InputField _user;
    public InputField _password;
    //存储密码和用户
    public static string user;
    public static string password;

    public Text Showmessage;

    void Awake()
    {
        //_user.text = null;
        //_password.text = null;

    }
    // Update is called once per frame
    void Start()
    {

    }

    //点击确定按钮
    public void OnSubmitButtonClick()
    {
        user = _user.text;
        password = _password.text;
        if (user == "" || password == "")
        {
            //请输入用户名或密码
            Showmessage.gameObject.SetActive(true);
            Showmessage.text = "您输入的格式不正确,请重新输入!";
            StartCoroutine(DisappearMessage());
            return;
        }

        if (user != "" && password != "")
        {
            //print("注册成功");
            transform.parent.gameObject.SetActive(false);
            Login.SetActive(true);
        }

    }

    IEnumerator DisappearMessage()
    {
        //协成在一秒后返回一个值/执行完再执行下一个
        yield return new WaitForSeconds(1);
        Showmessage.gameObject.SetActive(false);
    }
    //点击返回按钮
    public void OnReturnButtonClick()
    {
        this.transform.parent.gameObject.SetActive(false);
        Login.gameObject.SetActive(true);

        if (_user.text != "" || _password.text != "")
        {
            _user.text = "";
            _password.text = "";
        }
    }

}
