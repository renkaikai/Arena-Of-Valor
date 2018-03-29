using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //获取目标

    [HideInInspector]
    public Vector3 target;
    //跟随目标的速度
    public float speed;
    //摄像机跟目标距离
    Vector3 offset;
    //逐渐移向目标
    Vector3 targetPosition;

    void Start()
    {
        //设置起始目标位置
        targetPosition = transform.position;
        //调整摄像机起始的旋转角度
        transform.rotation = Quaternion.Euler(60, 35, 0);
        //摄像机跟目标位置的合适距离
        offset = new Vector3(target.x+4, target.y + 10, target.z);
    }
    void Update()
    {
        MoveFollow(speed);
    }
    /// <summary>
    /// 跟随移动目标
    /// </summary>
    /// <param name="speed"></param>
    void MoveFollow(float speed)
    {
        //逐渐移向目标
        targetPosition = Vector3.Lerp(targetPosition, target, Time.deltaTime * speed);
        //跟随目标
        transform.position = targetPosition + offset;
    }

}
