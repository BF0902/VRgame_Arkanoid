using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;
public class Button : MonoBehaviour
{
    //public Text InputText;
    
    public GameObject StartUI;
    public GameObject player;
    public GameObject Tennis;

    bool game_introduceisopen;//背包是否打開
    [SerializeField]
    // private SteamVR_Action_Boolean open = SteamVR_Input.GetBooleanAction("bagisopen");//收到手把按鍵:
    public SteamVR_Action_Boolean opengame_introduce = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("openGame_introduce");//收到手把按鍵:
    public SteamVR_Input_Sources curIndex;
    static int closeLetter2 = 0;



    // Start is called before the first frame update
    /*void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
       //CloseGame_introduceUI();
   }*/
    public void StartGame()
    {
        //InputText.text = InputText.text + "StartButton";
        // Debug.Log("StartButton1");
        SceneManager.LoadScene("stage1");
        Time.timeScale = 1;
        /*Letter.SetActive(true);
        StartUI.SetActive(false);
        Destroy(player);
        Destroy(cube);*/


    }

    public void Menu()
    {
        //InputText.text = InputText.text + "StartButton";
        // Debug.Log("StartButton1");
        SceneManager.LoadScene("start");
        Time.timeScale = 1;
        
        /*Letter.SetActive(true);
        StartUI.SetActive(false);
        Destroy(player);
        Destroy(cube);*/


    }

    public void Stage1ToStage2()
    {
        SceneManager.LoadScene("stage2");
        Tennis.SetActive(true);
        Time.timeScale = 1;
        
    }

    public void StartEndless()
    {
        SceneManager.LoadScene("endless");
        Tennis.SetActive(true);
        Time.timeScale = 1;
    }

}
