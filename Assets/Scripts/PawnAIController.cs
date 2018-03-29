using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PawnAIController : AIController
{
    
    private float addDamage = 300;//小兵施加的伤害
    Damage damage; 
    public bool isMeet = false;//是否有敌军进入攻击范围  true/攻击
    public GameObject buttlePrefabs; //子弹的预制体
    private GameObject[] targetArr; //小兵要移动到的位置，敌方水晶。 
    private GameObject target; 
    private Animator anim;//AI攻击时的动画 
    private NavMeshAgent pawn;//导航角色
    private float AttackDistance; //小兵攻击距离 
    float timer = 2; //小兵攻击的时间间隔 
    public List<GameObject> enemys = new List<GameObject>();//创建用于储存敌方目标的数组
    // Use this for initialization
    void Start()
    {
        damage.point = addDamage;
        damage.source = this.gameObject;
        Crystal[] items = GameObject.FindObjectsOfType<Crystal>();
        foreach (Crystal item in items)
        {
            if (item.gameObject.GetComponent<Crystal>().teamIndex != this.teamIndex)
            {
                target = item.gameObject;
            }
        }
        AttackDistance = this.GetComponent<PawnCharacter>().AttackDistance;//从小兵属性上获得小兵的攻击距离
        anim = this.GetComponent<Animator>();
        pawn = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        if (isMeet == false) //如果没有遇到敌人
        {
            Move();
            anim.SetFloat("attack", 0f);
            anim.SetFloat("run", 1f);
        }
        else    //遇到敌人
        {
            if (enemys.Count <= 0)
            {
                isMeet = false;
                return;
            }
            if (AttackDistance == 2)
                WorrriorAttack();
            else if (AttackDistance == 10)
                ShooterAttack();
        }
        if (enemys.Count <= 0)
        {
            isMeet = false;
        }
    }
    /// <summary>
    /// 把碰到的敌方对象存到敌方集合中
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.transform.GetComponent<Controller>())
        {       
        if (collider.gameObject.transform.GetComponent<Controller>().teamIndex == teamIndex) return;
        enemys.Add(collider.gameObject);
        isMeet = true;
        }
    }
    
    void OnTriggerExit(Collider collider)
    {
        if(enemys.Contains(collider.gameObject)) enemys.Remove(collider.gameObject);
    }
    /// <summary>
    /// 移动方法
    /// </summary>
    public void Move()
    {
        pawn.SetDestination(target.transform.position);
    }
    /// <summary>
    /// 近战小兵的攻击
    /// </summary>
    void WorrriorAttack()
    {
        if (enemys[0] == null)
        {
            UpdateEnemy();
        }
        if (enemys.Count <= 0) return;
        if (Vector3.Distance(transform.position, enemys[0].transform.position) < AttackDistance)
        {
            anim.SetFloat("run", 0f);
            anim.SetFloat("attack", 1f);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                enemys[0].gameObject.GetComponent<Controller>().ApplyDamage(damage);
                timer = 1;
            }
            transform.LookAt(enemys[0].transform.position);
            pawn.SetDestination(transform.position);
        }
        else
        {
            pawn.SetDestination(enemys[0].transform.position);
            anim.SetFloat("run", 1f);
        }
    }
    /// <summary>
    /// 远程小兵的攻击
    /// </summary>
    void ShooterAttack()
    {
        if (enemys[0] == null)
        {
            UpdateEnemy();
        }
        if (enemys.Count <= 0) return;
        if (Vector3.Distance(transform.position, enemys[0].transform.position) < AttackDistance)
        {
            timer -= Time.deltaTime;
            anim.SetFloat("run", 0f);
            anim.SetFloat("attack", 1f);
            if (timer <= 0)
            {
                GameObject bullet = GameObject.Instantiate(buttlePrefabs, this.transform.Find("Hips").Find("Staff").gameObject.transform.position + new Vector3(0, 1f, 0), transform.rotation);
                bullet.GetComponent<PawnBullet>().PC = this;
                enemys[0].gameObject.GetComponent<Controller>().ApplyDamage(damage);
                timer = 1f;
            }
            transform.LookAt(enemys[0].transform.position);
            pawn.SetDestination(transform.position);

        }
        else
        {
            pawn.SetDestination(enemys[0].transform.position);
            anim.SetFloat("run", 1f);
        }
    }
    /// <summary>
    /// 受到伤害
    /// </summary>
    /// <param name="damage"></param>
    public override void ApplyDamage(Damage damage)
    {
        
        this.gameObject.transform.GetComponent<PawnCharacter>().GetDamage(damage.point);
        if (damage.source&&this.GetComponent<PawnCharacter>().PawnHP<=0)
        {
            if (damage.source.gameObject.GetComponent<PlayerState>())
            {
                damage.source.GetComponent<PlayerState>().killPawns++;
            }
        }
    } 
    /// <summary>
    /// 更新敌方集合
    /// </summary>
    void UpdateEnemy()
    {
        enemys.RemoveAll(item => item == null);
    }

}
