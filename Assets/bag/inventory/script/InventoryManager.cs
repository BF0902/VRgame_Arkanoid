//itemOnWorld AddNewItem()內檢測到玩家處碰添加道具 用InventoryManager生成Slot
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    public inventory myBag;//哪個背包內列表內物品要生成
    public GameObject slotGrid;//背包內的格子 要在格子內一個個顯示
    //05public Slot soltPrefab; //
    public GameObject emptySlot;//5
    public Text itemInfromation;//道具資訊

    public List<GameObject> slotslist = new List<GameObject>();//5 背包18格子存在一個list中

    //單利
    static InventoryManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);//整個環境中只能有一個實例 如之前已存在實例 那就不存在實例化
        instance = this;
    }

    private void OnEnable()//直接調用 RefreshItem();
    {
        RefreshItem();
        instance.itemInfromation.text = "";
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //靜態方法 更快進行訪問 不需要new實例化
    /*public static void CreatNewItem(item item1)//創建新物體 獲得item內所有訊息並傳給slot 並在InventoryManager生成出物體  需要item類別的參數
    {
        //1.生成 Slot 類的物體(複製體newItem 克隆一個物體 在哪面向哪
        //2.將新實例化的newItem位置與instance.slotGrid.transform.position聯繫憶起 
        //newItem類型是個(腳本) 但要用.gameObject獲得物品本身才可存取.transform 
        //將newItem位置與父節點掛憶起
        //345.傳輸 Slot 類數據:item slotItem; Image slotImage; Text slotNum;
        //newItem是 Slot 類行 可訪問 Slot 類類的變量

        Slot newItem = Instantiate(instance.soltPrefab, instance.slotGrid.transform.position, Quaternion.identity);//Instantiate(你要複製的物件，在哪個位置生成，角度)生成複製體) 可不加位置旋轉 家父節點transform
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform, false);//,false防止變形
        newItem.slotItem = item1;//
        newItem.slotImage.sprite = item1.itemImage;//Image在Item內類型是個sprite 傳輸圖片
        newItem.slotNum.text = item1.itemHeld.ToString();//slotNum在slot內類型是個text 傳輸數字
    }
    */


    //
    /*public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0) break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for(int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            //CreatNewItem(instance.myBag.itemList[i]);
         
        }


    }*/
    public static void RefreshItem()
    {
        Debug.Log("RefreshItem()");
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0) break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slotslist.Clear();
        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            instance.slotslist.Add(Instantiate(instance.emptySlot));//5一開始生成對應數量(18)的空格子Prefabsolt:emptySlot
            instance.slotslist[i].transform.SetParent(instance.slotGrid.transform, false);//5這些emptySlot位置與grid(slotGrid)放憶起 把這些空格子擺放好//false避免變形

            instance.slotslist[i].transform.position = instance.slotslist[i].transform.parent.position;


            instance.slotslist[i].GetComponent<Slot>().slotID = i;//6 賦值 slotslist空格ID=itemList物品ID=i 從0開始-17 共18格 獲得當前列表slotslist的排序就可以獲得背包列表itemList的排序

            Debug.Log("11111");
            // instance.slotslist[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);//5將背包內物品給到Slot
            instance.slotslist[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);//5將背包內物品給到Slot    

            //Debug.Log(instance.slotslist[i].GetComponent<Slot>().slotID+":"+instance.slotslist[i].GetComponent<Slot>().slotItem.name);
            Debug.Log("22222");
            //*


            //5 CreatNewItem(instance.myBag.itemList[i]);
        }
    }

    public static void RefreshObject(GameObject itemGameObject, int index)
    {
        //GameObject itemGameObject1 = itemGameObject;
        Debug.Log("4" + index.ToString());
        instance.slotslist[index].GetComponent<Slot>().slotItemObject = itemGameObject;

        // Debug.Log("5" + index.ToString()+ instance.slotslist[index].GetComponent<Slot>().slotItemObject.name);
        Debug.Log("-----------");
        for (int i = 0; i < instance.slotslist.Count; i++)
        {
            Debug.Log("slotslist" + i + instance.slotslist[i].GetComponent<Slot>().slotItemObject.name);


        }
    }


    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInfromation.text = itemDescription;
    }
}
