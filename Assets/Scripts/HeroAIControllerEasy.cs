using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAIControllerEasy : HeroAIController
{
    // Update is called once per frame
    void Update()
    {
        //实时更新英雄HP值  
        HPF = HP.value;
        HPMaxF = HPMax.value;
        //实时更新英雄MP值   
        MPF = MP.value;
        MPMaxF = MPMax.value;

        //处于健康状态时 生命值大于百分之20
        if (HPF / HPMaxF > 0.2f)
        {
            //判断AI与玩家之间的距离
            float distance = Vector3.Distance(PlayerTra.position, this.transform.position);

            //当玩家距离与AI距离大于11时 向玩家控制角色移动
            if (distance >= 11)
            {
                this.transform.LookAt(PlayerTra);
                Move(PlayerTra.position);
            }
            //当玩家与AI的距离小于11 
            if (distance <= 11)
            {
                //当玩家与AI的距离小与10发动玩家攻击
                if (distance <= 10)
                {
                    Attack();
                }
                else //否则AI将开始面朝玩家追击
                {
                    Move(PlayerTra.position);
                }
            }
        }

        //处于危险状态时 生命值低于百分之20
        if (HPF / HPMaxF < 0.2f && HPF > 0)//处于危险状态时 生命值低于百分之20
        {
            this.transform.LookAt(spring);
            Move(spring);//向泉水移动
        }

        //处于死亡状态时 生命值小于0
        if (HPF <= 0&&islive==true)//处于危险状态时 生命值低于百分之20
        {
            Death();
            Invoke("Rebirth", 10);                 
        }
    } 
}
