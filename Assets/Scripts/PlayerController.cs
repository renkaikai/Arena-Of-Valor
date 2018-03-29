using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{

    private Animator anim;
    private Collider minDisCollider;//最近距离的敌人

    //TEST
    public List<Collider> EnemyCollider;//敌方集合
    public float collider1;
    //TEST
    private AttributeValue AR;//获取攻击距离
    private AttributeValue HP;//获取生命值
    private AttributeValue MS;//获取当前英雄的移动速度
    private AttributeValue PAvalue;//物理攻击
    private Damage damage;
    private float ARvalue;
    private float HPvalue;
    private float MSValue;
    private float PAValue;
    private PlayerController pc;
    private HeroCharacter c;//获取当前英雄
    private GameObject AIpalyer;
    private Hero hero;
    //绑定子弹预制体
    public GameObject Bullet;
    public bool isAttack;
    private Transform bulletPositions;
    [HideInInspector]
    protected PlayerState ps;//获取当前英雄的状态
    [HideInInspector]
    public Joystick joyStick;//获取操纵杆脚本
    [HideInInspector]
    public BulletMove bulletMove;
    private bool islive = true;
    void Start()
    {
        // AIpalyer = this.GetPlayerController(0).gameObject;
        EnemyCollider = new List<Collider>();
        Bullet = GameObject.Find("bullet");
        pc = this.GetPlayerController(0);
        joyStick = GameObject.FindObjectOfType<Joystick>();
        bulletMove = GetComponent<BulletMove>();
        bulletPositions = GameObject.Find("bullet").transform;
        c = (HeroCharacter)this.GetCharacter();
        anim = c.GetComponent<Animator>();
        hero = c.hero;//获取到英雄
        ps = this.playerState;
        AR = ps.attributes.GetAttributeValue(AttributeItem.AR);
        HP = ps.attributes.GetAttributeValue(AttributeItem.HP);
        MS = ps.attributes.GetAttributeValue(AttributeItem.MS);
        PAvalue = ps.attributes.GetAttributeValue(AttributeItem.PA);
        ARvalue = AR.value;
    }
    void Update()
    {
        Move(joyStick.GetDirection);
        HPvalue = HP.value;
        MSValue = MS.value;
        PAValue = PAvalue.value;
        AtkCondition2(ARvalue);//调用检测

        if (HPvalue <= 0 && islive == true)
        {
            Death();
            Invoke("Rebirth", 10);
        }
    }
    /// <summary>
    /// 人物得移动，获取JoyStick的Vector2值
    /// </summary>
    /// <param name="target"></param>
    public void Move(Vector2 target)
    {        
        float joyPositionX = target.x;
        float joyPositionZ = target.y;
        if (joyPositionX != 0 || joyPositionZ != 0)
        {
            transform.LookAt(new Vector3(c.transform.position.x + joyPositionX, c.transform.position.y, c.transform.position.z + joyPositionZ));
            transform.position += transform.forward * 6 * Time.deltaTime;
            anim.SetFloat("Run", 3);
        }
        if (joyPositionX == 0 && joyPositionZ == 0)
        {
            anim.SetFloat("Run", 0);
        }
    }
    /// <summary>
    /// 普通攻击，攻击最近的敌人
    /// </summary>
    public void Attack()
    {
        if (EnemyCollider.Count > 0)
        {
            if (ARvalue <= 2)//获取英雄是否为近战
            {
                Transform enemy = AtkCondition2(ARvalue).transform;
                this.transform.LookAt(enemy);
                Damages(enemy);
                anim.SetTrigger("Attack");
            }
            else if (ARvalue >= 10f)//英雄远程
            {
                Transform enemy = AtkCondition2(ARvalue).transform;
                this.transform.LookAt(new Vector3(enemy.position.x, transform.position.y, enemy.position.z));
                anim.SetTrigger("Attack");
                GameObject obj = GameObject.Instantiate(Bullet, bulletPositions.position, Quaternion.identity);
                // simple handle by andy
                obj.GetComponent<MeshRenderer>().enabled = true;
                obj.AddComponent<BulletMove>().SetTarget(AtkCondition2(ARvalue).transform);
                Damages(enemy);

            }
        }
    }
    /// <summary>
    /// 监测最近的敌人
    /// </summary>
    /// <param name="attackRange"></param>
    /// <returns></returns>
    Collider AtkCondition2(float Range)
    {
        if (collider1 != Physics.OverlapSphere(transform.position, Range, LayerMask.GetMask("Hero","Pawn")).Length)
        {
            EnemyCollider = new List<Collider>();
        }
        collider1 = Physics.OverlapSphere(transform.position, Range, LayerMask.GetMask("Hero","Pawn")).Length;
        foreach (Collider enemy in Physics.OverlapSphere(transform.position, Range, LayerMask.GetMask("Hero")))
        {
            if (enemy.GetComponent<Controller>().teamIndex != this.teamIndex)
            {

                if (!EnemyCollider.Contains(enemy))
                {
                    EnemyCollider.Add(enemy);
                }
            }
        } 
        if (EnemyCollider != null && EnemyCollider.Count>0)
        {
            minDisCollider = EnemyCollider[0];
            for (int i = 1; i < EnemyCollider.Count; i++)
            {
                float dis = (minDisCollider.transform.position - transform.position).magnitude;
                float dis1 = (EnemyCollider[i].transform.position - transform.position).magnitude;
                if (dis > dis1)
                {
                    minDisCollider = EnemyCollider[i];
                }
            }
        }
        return minDisCollider;
    }
    /// <summary>
    /// TODO
    /// 目前没有动画，待做
    ///人物释放技能
    /// </summary>
    public void ReleasingSkills(Skill skill)
    {
        //anim.SetTrigger(skill.name);
        foreach (AttributeEffect effect in skill.attributeEffects)
        {
            float max = pc.playerState.maxAttributes.GetAttributeValue(effect.attribute.abbr).value;
            pc.playerState.attributes.IncreaseAttributeValue(effect.attribute.abbr, effect.value, max);
        }
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
                pc.playerState.maxAttributes.IncreaseAttributeValue(effect.attribute.abbr, effect.value);
            }
        }
    }
    /// <summary>
    /// 伤害
    /// </summary>
    private void Damages(Transform enemy)
    {
        Controller enemyController = enemy.GetComponent<Controller>();
        if (enemyController == null)
        {
            enemyController = enemy.GetComponentInChildren<Controller>();
        }
        if(enemyController == null)
        {
            enemyController = enemy.GetComponentInParent<Controller>();
        }
        damage.point = PAValue;
        damage.source = this.gameObject;

        if (enemyController != null)
        {
            enemyController.ApplyDamage(damage);
        }else
        {
            print("Warning! cannot find enemy controller");
        }

        //AIpalyer.GetComponent<Controller>().ApplyDamage(damage);
    }
    /// <summary>
    /// 被击杀
    /// </summary>
    public void Death()
    {
        anim.SetTrigger("Death");
        islive = false;
        this.playerState.deaths++;
    }

    public void Rebirth()
    {
        this.playerState.attributes.IncreaseAttributeValue(AttributeItem.HP, HPvalue, HPvalue);
        this.transform.position = new Vector3(-73,9,-5);
        anim.SetTrigger("Living");
    }
}
