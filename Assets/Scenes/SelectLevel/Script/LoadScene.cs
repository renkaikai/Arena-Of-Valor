using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    
    private AsyncOperation Async;//异步
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SelectLevel(string NextScene)
    {
        Async = SceneManager.LoadSceneAsync(NextScene);
    }
    public void Return(string Return)
    {
        Async = SceneManager.LoadSceneAsync(Return);
    }
    
}
