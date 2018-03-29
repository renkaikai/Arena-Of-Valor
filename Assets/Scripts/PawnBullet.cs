using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnBullet : MonoBehaviour {
    //子弹的移动速度
    private float speed = 4;
    //子弹要攻击的目标
    public Vector3 target;
    [HideInInspector]
    public PawnAIController PC;
    
    // Use this for initialization
    void Start () {
        if (PC.isMeet) { target = PC.enemys[0].transform.position; }     
    }
	
	// Update is called once per frame
	void Update () {
        
        if (PC == null)
        {
            DestoryBullet();
            return;
        }
        transform.LookAt(target);
        transform.position += transform.forward * Time.deltaTime * speed;
        if(Vector3.Distance(transform.position, target) < 0.2)
        {
            DestoryBullet();
        }
        
    }
    void DestoryBullet()
    {
        Destroy(this.gameObject);
    }
}
