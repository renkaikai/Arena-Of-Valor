using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Cancel : MonoBehaviour {
    private bool IsClick;
	// Use this for initialization
	void Start ()
    {
        IsClick = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}
    public void ButtonClick()
    {
        if (IsClick == true)
        {
            SceneManager.LoadScene("Loading");
        }
    }
}
