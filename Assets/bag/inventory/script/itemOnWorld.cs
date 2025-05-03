//可運用在所有的道具物件 只要玩家碰撞到物品就會保存在玩家背包內

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;


public class itemOnWorld : MonoBehaviour
{
    //背包道具屬性
    public item thisItem;//獲得 玩家碰到的物件是屬於哪個數據庫 屬性
    public inventory playerInventory;//物品要去哪背包


    public GameObject itemGameObject;
    public int index;

    ///事件触发
    public UnityEvent OnUse;
    //public UnityEvent onDetachFromHand;
    private Hand hand;
    //public Throwable throwable;
    public UnityEvent throwable;
    public UnityEvent throwable1;
    public UnityEvent throwable2;
    public SteamVR_Action_Boolean throwaaa = SteamVR_Actions.default_GrabPinch;
    //public delegate void OnDetachedFromHandDelegate(Hand hand);
    //public event OnDetachedFromHandDelegate onDetachedFromHand;


    //使用该道具的事件
    public SteamVR_Action_Boolean useAction = SteamVR_Actions.default_ActionTest;
    public bool isTaken; //当前道具被抓取中

    [SerializeField]
    //點擊收集道具
    private SteamVR_Action_Boolean collect = SteamVR_Input.GetBooleanAction("collectItem");
    public SteamVR_Input_Sources collectIndex;


    protected virtual void HandAttachedUpdate(Hand hand)
    {
        if (!useAction.GetStateDown(hand.handType))
        {
            isTaken = true;
            Debug.Log("按键按下,道具使用");
            Debug.Log("isTaken:1");
            //OnUse?.Invoke();

            //OnUse.Invoke();
            //Invoke(OnUse);
            //hand.DetachObject(gameObject, restoreOriginalParent);
        }
        else
        {
            isTaken = false;
            Debug.Log("isTaken:０");
            //itemGameObject.GetComponent<Throwable>().onDetachFromHand;
            
        }
        //////////
    }
    /*protected virtual void onDetachFromHand(Hand hand)
    {

    }*/
    // Start is called before the first frame update
    void Start()
    {
        //throwable = GetComponent<Throwable>();
        Debug.Log("throwaaa.lastActive:"+throwaaa.lastActive);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("isTaken:", isTaken);
        take();
    }



    public void take()
    {
        if (isTaken == true && collect.GetStateDown(collectIndex))
        {
            //Debug.Log(!useAction.GetStateDown(hand.handType));
            Debug.Log("take()");
            AddNewItem();//添加道具物品進背包
            Debug.Log("take2");
            itemGameObject.gameObject.SetActive(false);
            Debug.Log("throwaaa.lastActive:" + throwaaa.lastActive);
            //throwaaa = null;
            OnUse.Invoke();
            throwable.Invoke();
            throwable1.Invoke();
            throwable2.Invoke();
            Debug.Log("throwaaa.lastActive:" + throwaaa.lastActive);
            //onDetachedFromHand.Invoke(hand);
            //onDetachFromHand.Invoke();
            //useAction.GetComponent<Throwable>().onDetachFromHand;
            //Destroy(gameObject);//銷毀地圖上的道具物件
            //OnDetachedFromHand(hand);
            //throwable.OnDetachedFromHand(hand);
            //hand.DetachObject(itemGameObject);
            // OnDetachedFromHand(attachedToHand);
        }
    }
    public void AddNewItem()//添加新物品
    {
        Debug.Log("AddNewItem()");
        //判斷此物品thisItem是否已經在此背包playerInventory內 
        //1.在 持有數量+1(增加數量
        //2不再 添加物品到此背包(生成圖片
        //將物品
        if (!playerInventory.itemList.Contains(thisItem))
        {
            Debug.Log("!playerInventory.itemList.Contains(thisItem)");
            //5 playerInventory.itemList.Add(thisItem);
            for (int i = 0; i < playerInventory.itemList.Count; i++)//5
            {
                //Debug.Log("2");
                if (playerInventory.itemList[i] == null)//5
                {
                    playerInventory.itemList[i] = thisItem;//5
                    thisItem.itemHeld = 1;
                    //*
                    playerInventory.itemList[i].g = itemGameObject;


                    index = i;
                    Debug.Log("1" + index.ToString());
                    //Debug.Log("3");
                    break;//5

                }
            }
        }
        else
        {
            index = playerInventory.itemList.IndexOf(thisItem);
            Debug.Log("2" + index.ToString());
            thisItem.itemHeld += 1;
        }
        Debug.Log("99999999");
        InventoryManager.RefreshItem();
        //InventoryManager.RefreshObject(itemGameObject.gameObject, index);   //*  
        Debug.Log("3" + index.ToString());


    }
}
