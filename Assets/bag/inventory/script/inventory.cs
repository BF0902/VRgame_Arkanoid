//創建背包系統 列表所有物品儲存 可創建不同背包 玩家鐵匠 藥水裝備

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new inventory", menuName = "inventory/new inventory")]
public class inventory : ScriptableObject
{
    public List<item> itemList = new List<item>();//
}
