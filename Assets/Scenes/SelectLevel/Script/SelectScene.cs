using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScene : MonoBehaviour {
    public GameObject[] Go1=new GameObject[4];
    int index = 0;
   void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            Go1[i].SetActive(false);

        }
    }
    void UpdateLevel()
    {
        for(int i = 0; i < 4; i++)
        {
            
            if (index != i)
            {
                
                Go1[i].SetActive(false);

            }
        }
    }
    public void ClickOne()
    {
        index = 0;
        UpdateLevel();
        Go1[index].SetActive(true);

        
    }
    public void ClickTwo()
    {
        index = 1;
        UpdateLevel();
        Go1[index].SetActive(true);
        
    }
    public void ClickThree()
    {
        index = 2;
        UpdateLevel();
        Go1[index].SetActive(true);
       

    }
    public void ClickFour()
    {
        index = 3;
        UpdateLevel();
        Go1[index].SetActive(true);
        

    }
    public void BGClick()
    {
        for(int i=0; i < 4; i++)
        {
            Go1[i].SetActive(false);
        }
    }
}
