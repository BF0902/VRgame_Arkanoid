//存背包物件內所有訊息 :名字 圖片 數量 資訊
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new item", menuName = "inventory/new item")]
//創建菜單文件方法  fileName ="創建新文件的文件名",menuName =文件夾路徑

//ScriptableObject可直接新增 不需要掛載到一個物件上才能執行

public class item : ScriptableObject
{
    public string itemName;//名
    public Sprite itemImage;//圖片
    public int itemHeld;//持有數量
    [TextArea]//多航描述
    public string itemInfo;
    public GameObject g;//道具物件
}