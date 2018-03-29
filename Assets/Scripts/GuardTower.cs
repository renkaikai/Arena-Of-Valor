using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardTower : AIController {
    public GameObject[] models;
    public Slider[] sliders;
    //公开子弹对象
    public GameObject Bullet;
    //子弹起始位置
    public Transform firePosition;
    //存储小兵的列表
    private  List<GameObject> batman = new List<GameObject>();
    //判断是否攻击小兵
    private bool Crashpawn = false;
    //判断是否攻击英雄
    private bool Crashhero = false;
    //敌方英雄
    [HideInInspector]
    public static GameObject Hero;
    //判断防御塔是否存在
    [HideInInspector]
    public bool isExist=true ;
    //判断敌方英雄是否在塔的范围内
    private bool Rangeinto = false;
    //射线
    public LineRenderer radial;
    //子弹攻速
    private float i =60;
    //血条
    [HideInInspector]
   public   Slider slider;
    private GameObject OurHero;
    private bool AttackPlayer=false;
    private bool isJudge = true;
    // Use this for initialization
    protected virtual void Start()
    {
        models[this.teamIndex].SetActive(true);
        slider = sliders[this.teamIndex];
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        JudgeSourse();
        Crash();
        RenewHP();
        
    }
    private void JudgeSourse()
    {
        if (isJudge &&OurHero != null&& OurHero.GetComponent<Controller>().ReceiveDamgeSource != null&&OurHero.GetComponentInParent<Controller>().ReceiveDamgeSource.tag == "Player")
        {
          
                AttackPlayer = true;
                isJudge = false;
        }
    }
    private void Crash()
    {
        if (Crashpawn && batman.Count>0)
        {
            for (int j = 0; j < batman.Count; j++)
            {
                if (batman[j] == null)
                {
                    batman.Remove(batman[j]);
                    j--;
                }
            }
            if (batman.Count > 0)
            {
                radial.enabled = true;
                radial.SetPositions(new Vector3[] { firePosition.position, batman[0].transform.position });
                if (i > 60)
                {
                    GameObject.Instantiate(Bullet, firePosition.position,firePosition.rotation);
                    Bullet.GetComponent<FireBullt>().enemy = batman[0];
                    Bullet.GetComponent<FireBullt>().tower = this;
                    Bullet.GetComponent<FireBullt>().Index = teamIndex;
                  
                    i = 0;
                }
                i++;
            }
            else
            {
                radial.enabled = false;
                Crashpawn = false;
            }
        }
       
      if ((Crashhero)||( Rangeinto&&AttackPlayer))
        {
            Crashpawn = false;
            if (Hero == null)
            {
                if (batman.Count > 0)
                {
                    Crashpawn = true;
                }
                Crashhero = false;
                return;
            }
            radial.enabled = true;
            radial.SetPositions(new Vector3[] { firePosition.position,Hero.transform.position });
            if (i > 30)
            {
                GameObject.Instantiate(Bullet, firePosition.position, firePosition.rotation);
                Bullet.GetComponent<FireBullt>().enemy = Hero;
                Bullet.GetComponent<FireBullt>().tower = this;
                Bullet.GetComponent<FireBullt>().Index = teamIndex;
                i = 0;
            }
            i++;
       
        }
        else
        {
            radial.enabled = false;
        }
    }
    protected virtual void RenewHP()
    {
      float maxhp = playerState.maxAttributes.GetAttributeValue("HP").value;
      float hp = playerState.attributes.GetAttributeValue("HP").value;
      slider.value = hp / maxhp;
      if (hp <= 0)
      {
          isExist = false;
          Destroy(this.gameObject);
      }
    }
   private void OnTriggerEnter(Collider other)
    {
      
          //当塔检测到兵并且兵的阵营不和塔一致
            if (other.tag == "Pawn" && other.GetComponentInParent<PawnAIController>().teamIndex !=this.teamIndex)
            {
                batman.Add(other.gameObject);
                Crashpawn = true;
            }
            //当塔检测到英雄并且阵营不一致
            if (other.tag == "Player" && other.gameObject.GetComponent<Controller>().teamIndex !=this.teamIndex)
            {
                Hero = other.gameObject;
                Rangeinto = true;
                //判断是否正在攻击小兵
                if (Crashpawn == false)
                {
                    Crashhero = true;
                }
            }
            if (other.tag == "Player" && other.GetComponent<Controller>().teamIndex == this.teamIndex)
            {
                OurHero = other.gameObject;
            }
    }
    //退出检测
    private void OnTriggerExit(Collider other)
    {
       
            if (other.tag == "Pawn" && other.GetComponentInParent<PawnAIController>().teamIndex !=this.teamIndex)
            {
                batman.Remove(other.gameObject);
            }
            if (other.tag == "Player" && other.GetComponent<Controller>().teamIndex !=this.teamIndex)
            {
                AttackPlayer = false;
                isJudge = true;
                Crashhero = false;
                Rangeinto = false;
                if (batman.Count > 0)
                {
                    Crashpawn = true;
                }
            }
        }
}
