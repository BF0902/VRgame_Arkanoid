using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UseBotton : MonoBehaviour
{
    static GameObject newObject;
    static int id;//public
    public inventory playerInventory;

    //public GameObject emptySlot;
    //單利
    static UseBotton instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(this);//整個環境中只能有一個實例 如之前已存在實例 那就不存在實例化
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public static void UpdateItemObject(GameObject obj, int slotid)
    {
        newObject = obj.gameObject;
        id = slotid;
        Debug.Log("newObject.name" + newObject.name);
        Debug.Log("id" + id.ToString());
    }
    public void UsebottonOnClicked()
    {
        UseItem();
    }
    public void UseItem()
    {
        Debug.Log("newObject.name" + newObject.name);
        //
        newObject.transform.forward = new Vector3(newObject.transform.position.x, 0, newObject.transform.position.z) - new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z);
        //newObject.transform.position=cam
        Debug.Log("newObject.transform.position:" + newObject.transform.position);


        newObject.SetActive(true);
        playerInventory.itemList[id].itemHeld -= 1;
        if (playerInventory.itemList[id].itemHeld == 0)
        {
            // Destroy(playerInventory.itemList[id]);
            //playerInventory.itemList.Remove(playerInventory.itemList[id]);

            playerInventory.itemList[id] = null;
            item i = new item();
            // playerInventory.itemList.Add((item)items);
            //playerInventory.itemList.Insert(id,i);
            // .Remove(playerInventory.itemList[id]);
            // transform.parent.GetComponentInParent<InventoryManager>().slotslist.Add();
            //instance.slotslist.Add(Instantiate(instance.emptySlot));
        }
        InventoryManager.RefreshItem();
    }
}
