using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClick : MonoBehaviour
{
    public List<GameObject> panel;
    private bool active = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Click()
    {
       // print("0");
        if (active == false)
        {
            panel[0].SetActive(true);
            active = true;
        }
        else
        {
            panel[0].SetActive(false);
            active = false;
        }
    }
    public void BtnAttribute()
    {
        panel[1].SetActive(true);
        panel[2].SetActive(false);
    }
    public void BtnAttack()
    {
        panel[2].SetActive(true);
        panel[1].SetActive(false);
    }
}
