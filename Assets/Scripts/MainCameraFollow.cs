using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainCameraFollow : MonoBehaviour
{
    //获取目标
    public Image image;
    [HideInInspector]
    public Transform targetTransform;
    //跟随目标的速度
    public float speed;
    //判断摄像机是否锁定目标
    private bool isLockTarget;
    //摄像机跟目标距离
    Vector3 offset;
    //逐渐移向目标
    Vector3 targetPosition;

    void Start()
    {
        targetTransform = this.GetPlayerController(0).transform;
        //设置起始目标位置
        targetPosition = transform.position;
        //调整摄像机起始的旋转角度
        transform.rotation = Quaternion.Euler(60, 35, 0);
        //摄像机跟目标位置的合适距离
        offset = new Vector3(targetTransform.position.x + 70, targetTransform.position.y + 5, targetTransform.position.z);
        isLockTarget = false;
    }
    void Update()
    {
        //如果相机还没有锁定到目标
        if (!isLockTarget)
        {
            MoveFollow(1);
            if (Vector3.Distance(targetPosition, targetTransform.position) < 0.5f)
            {
                isLockTarget = true;
                image.gameObject.SetActive(false);
            }
        }
        else
        {
            MoveFollow(speed);
        }
    }
    /// <summary>
    /// 跟随移动目标
    /// </summary>
    /// <param name="speed"></param>
    void MoveFollow(float speed)    
    {
        //逐渐移向目标
        targetPosition = Vector3.Lerp(targetPosition, targetTransform.position, Time.deltaTime * speed);
        //跟随目标
        transform.position = targetPosition + offset;
    }

}
