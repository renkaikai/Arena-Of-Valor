using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PawnCharacter : Character {

    [HideInInspector]
    //小兵当前生命值
    public float PawnHP=1001;
    
    //小兵移动速度
    public int MoveSpeed=2;

    //小兵攻击力
    public int AttackForce;

    //小兵攻击速度
    public float AttackSpeed;

    //小兵的攻击距离
    public float attackDistance;

    //小兵最大生命值
    public float TotalHP=300;

    //血条的显示
    private Slider slider;
    private float timer = 1f;
    private Animator anim;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        slider = GetComponentInChildren<Slider>();
    }
    public float AttackDistance
    {
        get
        {
            return attackDistance;
        }

        set
        {
            attackDistance = value;
        }
    }
    void Update()
    {
        slider.value = PawnHP / TotalHP;
        if (PawnHP <= 0)
        {
            
            anim.SetFloat("death", 1);
            timer -= Time.deltaTime;
        }
       
        if (timer <= 0)
        {
            
            Destroy(this.gameObject);
        }

    }

    public void GetDamage(float point )
    {
        PawnHP -= point;
    }
}
