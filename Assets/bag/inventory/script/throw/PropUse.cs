using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class PropUse : MonoBehaviour
{
    //使用该道具的事件
    public SteamVR_Action_Boolean useAction = SteamVR_Actions.default_ActionTest;

    ///事件触发
    public UnityEvent OnUse;

    public bool isTaken=false;
    ///当前道具被抓取中
    protected virtual void HandAttachedUpdate(Hand hand)
    {
        if (useAction.GetStateDown(hand.handType))
        {
            isTaken = true;
            Debug.Log("按键按下,道具使用");
            Debug.Log("isTaken:1");
            //OnUse?.Invoke();
            //Debug.Log("isTaken:", isTaken);
            OnUse.Invoke();
            //Invoke(OnUse);
        }
        //else
        //{
          //  isTaken = false;
          //  Debug.Log("isTaken:０");
        //}

}


}

