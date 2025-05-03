using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;


public class DialogSystem : MonoBehaviour
{
    [Header("UI組件")]
    public Text textLabel;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;

    public GameObject Dialog;
    List<string> textList = new List<string>();
    public SteamVR_Action_Boolean action = SteamVR_Actions.default_NextPage;
    public SteamVR_Behaviour_Pose pose;

    //public GameObject player;
    //public GameObject Button;
    public Text NameText;

    

    // Start is called before the first frame update
    void Awake()
    {
        GetTextFromFile(textFile);
    }
    private void OnEnable()
    {
        index = 0;
        if (textList[index] == "A\r")
        {
            NameText.text = "可芳";
            index++;
            textLabel.text = textList[index];
            index++;

        }
        else if (textList[index] == "B\r")
        {
            NameText.text = "我";
            index++;
            textLabel.text = textList[index];
            index++;
        }
        else
        {
            textLabel.text = textList[index];
            index++;
        }
        /*textLabel.text = textList[index];
        index++;*/
    }

    // Update is called once per frame
    void Update()
    {
        if(action.GetStateDown(pose.inputSource) && index == textList.Count) 
        {
            //gameObject.SetActive(false);
            Dialog.SetActive(false);
            //Button.SetActive(true);
            index = 0;
            return;
           
        }
        if (action.GetStateDown(pose.inputSource)) 
        {
            if (textList[index] == "A\r")
            {
                NameText.text = "可芳";
                index++;
                textLabel.text = textList[index];
                index++;

            }
            else if (textList[index] == "B\r")
            {
                NameText.text = "我";
                index++;
                textLabel.text = textList[index];
                index++;
            }
            else { 
                textLabel.text = textList[index];
                //NameText.text = index.ToString();
                index++;            
            }

        }
        
    }

    void GetTextFromFile(TextAsset file) 
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData) 
        {
            textList.Add(line);
        }
               
    }

    /*void OnTriggerEnter(Collider other) 
    {
        if (other.GameObject == player) 
        {
            Dialog.SetActive(true);
        }

    
    }*/
}
