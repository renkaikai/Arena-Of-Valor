using System;
using System.Collections.Generic;
using UnityEngine;


public class HeroAIController : AIController
{
    public bool TowerDie = true;//防御塔的状态
    protected Animator anim;//获取动画状态机
    protected Damage damage;

    protected PlayerState ps;//获取英雄状态

    protected AttributeValue PA;//获取英雄当前PA
    protected float PAF;//获取英雄当前PA float值

    protected AttributeValue HP;//获取英雄当前HP
    protected AttributeValue HPMax;//获取英雄最大HP
    protected float HPF;//获取英雄当前HP float值
    protected float HPMaxF;//获取英雄最大HP float值

    protected AttributeValue MP;//获取英雄当前MP
    protected AttributeValue MPMax;//获取英雄最大MP
    protected float MPF;//获取英雄当前MP float值
    protected float MPMaxF;//获取英雄最大MP float值

    protected AttributeValue AR;//获取英雄当前AR
    protected float ARF;//获取英雄当前AR float值

    protected GameObject Player;
    protected Transform PlayerTra;//玩家控制角色坐标
    protected Vector3[] destination;//预设坐标
    protected Vector3 spring = new Vector3(66, 9.08f, 0);//泉水坐标
    protected Vector3 home = new Vector3(44, 8.2f, 0);//水晶坐标
    protected Vector3 tower = new Vector3(21, 8.23f, 0);//防御塔坐标

    public bool islive = true;
    void Start()
    {

        //获取到英雄数据
        PlayerTra = this.GetPlayerController(0).transform;
        Player = this.GetPlayerController(0).gameObject;

        ps = this.playerState;
        anim = GetCharacter().GetComponent<Animator>();

        //获得英雄PA
        PA = ps.attributes.GetAttributeValue(AttributeItem.PA);

        //获得英雄HP
        HP = ps.attributes.GetAttributeValue(AttributeItem.HP);
        HPMax = ps.maxAttributes.GetAttributeValue(AttributeItem.HP);

        //获得英雄MP
        MP = ps.attributes.GetAttributeValue(AttributeItem.MP);
        MPMax = ps.maxAttributes.GetAttributeValue(AttributeItem.MP);

        //获得英雄射程   
        AR = ps.attributes.GetAttributeValue(AttributeItem.AR);
        ARF = AR.value;

        //出场时播放IDLE动画
        //anim.SetTrigger("Idle");
    }

    /// <summary>
    /// 向指定方向移动
    /// </summary>
    /// <param name="V"></param>
    protected void Move(Vector3 V)
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, V, 4f * Time.deltaTime);
        anim.SetFloat("Run", 5);
    }
    /// <summary>
    /// 普通攻击
    /// </summary>
    public void Attack()
    {
        anim.SetTrigger("Attack");
        damage.point = PA.value/60;
        damage.source = this.gameObject;
        Player.GetComponent<Controller>().ApplyDamage(damage);
    }

    /// <summary>
    /// 受到伤害
    /// </summary>
    /// <param name="damage"></param>
    //public override void ApplyDamage(Damage damage)
    //{
    //    print(damage.point);
    //}

    /// <summary>
    /// 死亡动画
    /// </summary>
    public void Death()
    {
        anim.SetTrigger("Death");
        islive = false;
        playerState.deaths++;      
 
    }

    /// <summary>
    /// 重生动画
    /// </summary>
    public void Rebirth()
    {
        this.playerState.attributes.IncreaseAttributeValue(AttributeItem.HP, HPMaxF, HPMaxF);
        this.transform.position = spring;
        anim.SetTrigger("Living");
        islive = true;   
    }

    /// <summary>
    /// 购买装备，增加属性
    /// </summary>
    /// <param name="item"></param>
    public void BuyItem(Item item)
    {
        foreach (AttributeEffect effect in item.attributeEffects)
        {
            if (effect.isMaxAttribute)
            {
                this.playerState.maxAttributes.IncreaseAttributeValue(effect.attribute.abbr, effect.value);
            }
        }
    }
}


