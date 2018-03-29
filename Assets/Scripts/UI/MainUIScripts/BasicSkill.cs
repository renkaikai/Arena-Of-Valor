using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkill : MonoBehaviour {
    public Skill basicSkill;
    private PlayerController pc;
	// Use this for initialization
	void Start () {
        pc = this.GetPlayerController(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickBasicSkill()
    {
        //向playerController发送点击了恢复技能的信息
        pc.Attack();
    }
}
