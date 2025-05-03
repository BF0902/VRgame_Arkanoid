//更改背包顯示道具的圖片
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public item slotItem;
    public Image slotImage;
    public Text slotNum;

    public int slotID;//6 slotslist空格ID=itemList物品ID 賦值InventoryManager
    public string slotInfo;//5物品資料欄
    public GameObject itemInSolt;//5獲取將itemButton

    public GameObject slotItemObject;//*

    // public GameObject iteminSlot;//抽屜格

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemOnClicked()
    {
        //InventoryManager.UpdateItemInfo(slotItem.itemInfo);
        InventoryManager.UpdateItemInfo(slotInfo);//點及背包格子內的botton 觸發ItemOnClicked() 並將slotInfo道具說明欄訊息傳送到InventoryManager
        UseBotton.UpdateItemObject(slotItemObject.gameObject, slotID);
    }

    //5
    //一開始生成對應數量(18)的Prefabsolt:emptySlot時可以將Slot裡的資料slotItem;slotImage;slotNum; 也憶起生呈上去
    //這裡將slotslist item設定好 在InventoryManager RefreshItem()生呈上去 :SetupSlot(item items)
    public void SetupSlot(item items)
    {
        Debug.Log("SetupSlot");
        //Debug.Log(items.name);
        if (items == null)//item 空的 沒有物品 將itemButton設成false不顯示出來
        {
            itemInSolt.SetActive(false);//將itemButton設成false不顯示出來
            return;
        }
        bool a = itemInSolt.activeSelf;
        Debug.Log(a);
        //item 有物品 將items裡的資料slotImage;slotNum;設定到slotImage物件上
        //方格組中每個方格slot根據mybag itemList中對應順序的item賦值
        slotImage.sprite = items.itemImage;//
        slotNum.text = items.itemHeld.ToString();//
        slotInfo = items.itemInfo;//slotInfo獲取背包道具物品說明訊息items.itemInfo 並用ItemOnClicked() 並將slotInfo道具說明欄訊息傳送到InventoryManager

        slotItemObject = items.g;

    }

}
