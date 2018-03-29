using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public int MovementRange = 100;  //slid move range
    private Vector2 direction;  // direction of move to targetdirection
    private Vector2 targetDrection;  
    private Vector2 originPoint;
    Vector3 m_StartPos; 

    void Start()
    {
        m_StartPos = transform.position;
    }

    void Update()
    {
       
    }


    public void OnDrag(PointerEventData data)
    {
        Vector3 newPos = Vector3.zero;
        Vector2 targetPoint = data.position - originPoint;
        targetDrection = targetPoint.normalized;
        int delta_x = (int)(data.position.x - m_StartPos.x);
        delta_x = Mathf.Clamp(delta_x, -MovementRange, MovementRange);
        newPos.x = delta_x;
        float distanceOfMove = Vector3.Distance(m_StartPos, new Vector3(m_StartPos.x + newPos.x, m_StartPos.y + (data.position.y - m_StartPos.y), m_StartPos.z));
        if (distanceOfMove > MovementRange)
        {
            int offsetDistanceOf_y = (int)(data.position.y - m_StartPos.y);
            int offsetDistanceOf_x = (int)(data.position.x - m_StartPos.x);
            float delta_y = (int)Mathf.Sqrt(Mathf.Pow(MovementRange, 2) - Mathf.Pow(offsetDistanceOf_x, 2));
            newPos.y = offsetDistanceOf_y < 0 ? delta_y < 0 ? 0 : -delta_y : delta_y < 0 ? 0 : delta_y;
        }
        else
        {
            newPos.y = data.position.y - m_StartPos.y;
        }
        transform.position = new Vector3(m_StartPos.x + newPos.x, m_StartPos.y + newPos.y, m_StartPos.z + newPos.z);
    }
    public void OnPointerUp(PointerEventData data)
    {
        targetDrection = Vector3.zero;
        transform.position = m_StartPos;
    }
    public void OnPointerDown(PointerEventData data)
    {
        originPoint = data.position;
    }


    /// <summary>
    /// 获取摇杆当前的方向
    /// </summary>
    public Vector2 GetDirection
    {
        get
        {
            direction = Vector2.MoveTowards(direction, targetDrection, 0.5f);
            return direction;
        }
    }
}