using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemIcon : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public Item item;

    [HideInInspector]
    public ItemsPanel itemPanel;

    public Image itemIconImage;

    public Text itemIconText;

    void Start()
    {
        if (item)
        {
            itemIconImage.sprite = item.icon;
            itemIconText.text = item.name;
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        itemPanel.ItemIconClick(item);
        itemPanel.itemDescription.text = item.name + "\n" + item.description;
    }
}
