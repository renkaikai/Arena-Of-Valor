using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour {
    public GameObject obj;
    private Button btn;
    private bool isHit=true;
	// Use this for initialization
	void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(IsHit);
    }
	
	// Update is called once per frame
	void Update () {
       
	}
    void IsHit()
    {
        obj.SetActive(isHit);
        isHit = isHit == true ? false : true;
    }
}
