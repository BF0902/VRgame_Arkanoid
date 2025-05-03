using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    private bool isGrabbed = false;
    private Transform originalParent;

    private void Start()
    {
        originalParent = transform.parent;
    }

    public void Grab(Transform hand)
    {
        isGrabbed = true;
        transform.SetParent(hand);
        // 可以在這裡調整物件的位置和旋轉
    }

    public void Release()
    {
        isGrabbed = false;
        transform.SetParent(originalParent);
    }

    public bool IsGrabbed()
    {
        return isGrabbed;
    }
}
