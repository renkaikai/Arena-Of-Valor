using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class registerButton : MonoBehaviour
{
    public GameObject register;
    public InputField userText;
    public InputField password;
     void Start()
    {
        
    }

    public void OnRegisterButtonClick()
    {
        if (userText.text != "" || password.text != "")
        {
            userText.text = "";
            password.text = "";
        }   
        register.gameObject.SetActive(true);

        this.transform.parent.gameObject.SetActive(false);
        //
        
    }

}
