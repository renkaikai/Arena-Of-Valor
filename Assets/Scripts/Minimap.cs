using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Minimap : MonoBehaviour, IPointerUpHandler, IPointerDownHandler,IDragHandler
{
    public Camera minimap;
    Quaternion CameraRotation;
    //主摄像机
    public GameObject CameraMain;
    //漫游相机
    public GameObject CamerScan;
    public Vector3 targetTransform;
    bool ismove = false;
    Vector3 Cameramain;
    void Start()
    {
        Cameramain = CameraMain.transform.position;
        CameraRotation = CameraMain.transform.rotation;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CameraMain.SetActive(true);
        CamerScan.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CameraMain.SetActive(false);
        CamerScan.SetActive(true);
        M(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        CameraMain.SetActive(false);
        CamerScan.SetActive(true);
        M(eventData);
    }


    void M(PointerEventData eventData)
    {

        Vector2 leep = eventData.pointerCurrentRaycast.screenPosition - new Vector2(transform.position.x - 50, transform.position.y - 50);

        Rect rect = ((RectTransform)transform).rect;

        Vector3 vpp = new Vector3(leep.x / rect.width, leep.y / rect.height, 0);
        // 
        Ray ray = minimap.ViewportPointToRay(vpp);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            targetTransform = hit.point;
            CamerScan.GetComponent<FollowCamera>().target =   targetTransform;
        }
    }

}
