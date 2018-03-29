using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsPanel : MonoBehaviour
{
    PlayerController player;

    public GameObject itemIcon;         //商店装备格子的预制体
    public GameObject inventoryPanel;   //自身装备栏的Panel
    public Text itemDescription;        //装备描述


    private List<GameObject> itemIcons; //装备的集合
    private List<Item> magicItems;      //魔法装备
    private List<Item> phyItems;        //物理装备
    private List<Item> movItems;        //移动装备
    private List<Item> defItems;        //防御装备
    private List<Item> allItems;        //全部装备
    private Item ClckedItem;            //当前选择要买的装备  
    private List<Transform> inventorys; //自身装备栏中的装备格子

    private int[] inventorysIndex;      //自身装备栏格子的索引下标集合   

    private Dictionary<string, List<Item>> ItemDic; //装备类型集合的字典
    void Start()
    {
        player = this.GetPlayerController(0);   //获取当前控制对象
        
        itemIcons = new List<GameObject>(); //装备框框的集合
        magicItems = new List<Item>();      //魔法装备
        phyItems = new List<Item>();        //物理装备
        movItems = new List<Item>();        //移动装备
        defItems = new List<Item>();        //防御装备
        inventorys = new List<Transform>(); //自身装备栏中的装备格子

        //获取到我的所有装备格子
        for (int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            inventorys.Add(inventoryPanel.transform.GetChild(i));
        }
        inventorysIndex = new int[inventoryPanel.transform.childCount];

        ItemDic = new Dictionary<string, List<Item>>();
        allItems = Game.Instance.database.items;

        for (int i = 0; i < allItems.Count; i++)
        {
            switch (allItems[i].type)
            {
                case Item.Type.MagicAttack:         //魔法
                    magicItems.Add(allItems[i]);
                    break;
                case Item.Type.PhysicsAttack:       //物理
                    phyItems.Add(allItems[i]);
                    break;
                case Item.Type.Move:                //移动
                    movItems.Add(allItems[i]);
                    break;
                case Item.Type.Defense:             //防御
                    defItems.Add(allItems[i]);
                    break;
            }
        }
        ItemDic.Add("魔法", magicItems);
        ItemDic.Add("物理", phyItems);
        ItemDic.Add("防御", defItems);
        ItemDic.Add("移动", movItems);
    }
    /// <summary>
    /// 装备类型选择按钮
    /// </summary>
    /// <param name="typeName"></param>
    public void ItemTypeBtnClick(string typeName)
    {
        //根据外面按钮的类型名不同查找到对应类型的装备集合
        if (itemIcons.Count > 0)
        {
            foreach (GameObject itemIcon in itemIcons)
            {
                Destroy(itemIcon);
            }
            //每次点击重新new一下集合 不然集合长度一直在增加         
            itemIcons = new List<GameObject>();
            itemDescription.text = "";
            ClckedItem = null;
        }
        foreach (Item It in ItemDic[typeName])
        {
            GameObject item = Instantiate(itemIcon, transform);
            itemIcons.Add(item);
            item.GetComponent<ItemIcon>().item = It;
            item.GetComponent<ItemIcon>().itemPanel = this;
        }
    }
    /// <summary>
    /// 商店某个装备被点击
    /// </summary>
    /// <param name="item"></param>
    public void ItemIconClick(Item item)
    {
        ClckedItem = item;
    }
    /// <summary>
    /// 购买按钮被点击
    /// </summary>
    public void BuyBtn()
    {
        if (ClckedItem)
        {
            for (int i = 0; i < inventorys.Count; i++)
            {
                //inventorysIndex中所有元素默认为0更换默认元素值
                if (inventorysIndex[i] != i + 1)
                {
                    inventorys[i].GetChild(0).GetComponent<Image>().sprite = ClckedItem.icon;
                    inventorysIndex[i] = i + 1;
                    //购买成功后在角色当前拥有装备的集合中添加
                    player.playerState.possessItems.Add(ClckedItem);
                    //给对象控制器传入一个装备ClckedItem调用购买装备增加属性的方法
                    player.BuyItem(ClckedItem);
                    //重置
                    itemDescription.text = "";
                    ClckedItem = null;
                    return;
                }
            }
        }  
    }
}
