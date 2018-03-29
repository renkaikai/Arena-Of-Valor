using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal :GuardTower {
    public GameObject[] pawns;
    private  GameObject pawn1;
    private  GameObject pawn2;
    public Transform tager;
    private float timer=30f;
    //// Use this for initialization
    protected override void Start()
    {
        base.Start();
        if (teamIndex == 0)
        {
            pawn1 = pawns[0];
            pawn2 = pawns[1];
        }
        else
        {
            pawn1 = pawns[2];
            pawn2 = pawns[3];
        }

    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        timer-=Time.deltaTime;
        if (timer <= 0)
        {
            StartCoroutine(CreatPawn());
            timer = 30;
        }
    }
    IEnumerator CreatPawn()
    {
        GameObject batman1 = GameObject.Instantiate(pawn1, tager.position,Quaternion.identity);
        batman1.gameObject.GetComponent<PawnAIController>().teamIndex = this.teamIndex;
        yield return new WaitForSeconds(0.5f);
        GameObject batman2= GameObject.Instantiate(pawn1, tager.position, Quaternion.identity);
        batman2.gameObject.GetComponent<PawnAIController>().teamIndex = this.teamIndex;
        yield return new WaitForSeconds(1f);
        GameObject batman3= GameObject.Instantiate(pawn2, tager.position, Quaternion.identity);
        batman3.gameObject.GetComponent<PawnAIController>().teamIndex = this.teamIndex;
    }
    public override void ApplyDamage(Damage damage)
    {
        if (!isExist)
        {
            this.playerState.attributes.IncreaseAttributeValue(AttributeItem.HP, -damage.point);
        }
    }
}
