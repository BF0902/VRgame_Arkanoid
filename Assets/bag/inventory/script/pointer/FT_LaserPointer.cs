using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class FT_LaserPointer : SteamVR_LaserPointer
{
    public SteamVR_Action_Boolean interactWithModel = SteamVR_Input.GetBooleanAction("GrabPinch");

    bool isActive = false;

    public event PointerEventHandler PointerClickModel;

    Transform previousContact = null;

    public virtual void OnPointerClickModel(PointerEventArgs e)
    {
        if (PointerClickModel != null)
            PointerClickModel(this, e);
    }

    private void Update()
    {
        if (!isActive)
        {
            isActive = true;
            this.transform.GetChild(0).gameObject.SetActive(true);
        }

        float dist = 100f;

        Ray raycast = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        bool bHit = Physics.Raycast(raycast, out hit);

        if (previousContact && previousContact != hit.transform)
        {
            PointerEventArgs args = new PointerEventArgs();
            args.fromInputSource = pose.inputSource;
            args.distance = 0f;
            args.flags = 0;
            args.target = previousContact;
            OnPointerOut(args);
            previousContact = null;
        }
        if (bHit && previousContact != hit.transform)
        {
            PointerEventArgs argsIn = new PointerEventArgs();
            argsIn.fromInputSource = pose.inputSource;
            argsIn.distance = hit.distance;
            argsIn.flags = 0;
            argsIn.target = hit.transform;
            OnPointerIn(argsIn);
            previousContact = hit.transform;
        }
        if (!bHit)
        {
            previousContact = null;
            pointer.GetComponent<MeshRenderer>().material.color = color;
        }
        else
        {
            pointer.GetComponent<MeshRenderer>().material.color = clickColor;
        }
        if (bHit && hit.distance < 100f)
        {
            dist = hit.distance;
        }

        if (bHit && interactWithUI.GetStateUp(pose.inputSource))
        {
            PointerEventArgs argsClick = new PointerEventArgs();
            argsClick.fromInputSource = pose.inputSource;
            argsClick.distance = hit.distance;
            argsClick.flags = 0;
            argsClick.target = hit.transform;
            OnPointerClick(argsClick);
        }

        if (bHit && interactWithModel.GetStateUp(pose.inputSource))
        {
            PointerEventArgs argsClick = new PointerEventArgs();
            argsClick.fromInputSource = pose.inputSource;
            argsClick.distance = hit.distance;
            argsClick.flags = 0;
            argsClick.target = hit.transform;
            OnPointerClickModel(argsClick);
        }

        if (interactWithUI != null && interactWithUI.GetState(pose.inputSource))
        {
            pointer.transform.localScale = new Vector3(thickness * 5f, thickness * 5f, dist);

        }
        else
        {
            pointer.transform.localScale = new Vector3(thickness, thickness, dist);

        }
        pointer.transform.localPosition = new Vector3(0f, 0f, dist / 2f);
    }
}