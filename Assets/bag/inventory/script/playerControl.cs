using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;
public class playerControl : MonoBehaviour
{
    //背包
    public GameObject mybag;//背包物件
    bool bagisopen;//背包是否打開

    // SteamVR_TrackedObject trackedObject;

    [SerializeField]
    // private SteamVR_Action_Boolean open = SteamVR_Input.GetBooleanAction("bagisopen");//收到手把按鍵:
    public SteamVR_Action_Boolean open = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("openbag");//收到手把按鍵:

    public SteamVR_Input_Sources curIndex;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OpenMyBag();//按b開關背包
    }

    void OpenMyBag()//按手環握持鍵開關背包
    {
        bagisopen = mybag.activeSelf;//避免典籍關閉後再按b出現問題

        //if (Input.GetKeyDown(KeyCode.B))
        //if (open.GetStateDown(curIndex))//收到手把按鍵:
        if (open.GetStateDown(SteamVR_Input_Sources.Any))//收到手把按鍵:
        {
            bagisopen = !bagisopen;//反覆切換背包開關
            mybag.SetActive(bagisopen);
            Debug.Log("bag -");
        }
        // Debug.Log("bag +");
    }
}
