using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillIcon : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [HideInInspector]
    public int id;
    public Image iconImage;
    [HideInInspector]
    public Skill skill;
    [HideInInspector]
    public int amount;
    [HideInInspector]
    public SkillsPanel skillpanel;

    public GameObject Introduce;
    public Transform skillPosition;
    private Image skillIconImage;


    SkillInfoPanel skillInfoPanel;
    // Use this for initialization
    void Start()
    {
        skillIconImage = GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        skillInfoPanel = GameObject.Instantiate(Introduce, GameObject.Find("Main").transform).GetComponent<SkillInfoPanel>();
        skillInfoPanel.skill = skill;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(skillInfoPanel.gameObject);
    }
}
