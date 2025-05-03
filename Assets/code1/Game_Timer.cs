using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Timer : MonoBehaviour
{
    public int m_seconds;                 //倒數計時經換算的總秒數

    public int m_min;              //用於設定倒數計時的分鐘
    public int m_sec;              //用於設定倒數計時的秒數

    public Text m_timer;           //設定畫面倒數計時的文字
    public GameObject m_gameOver,bgm,end_bgm, GameObject_FT_LaserPointer;  //設定 GAME OVER 物件
    public GameObject player,Tennis;
    public Vector3 end_player_position;
    public Vector3 end_player_rotation;

   
    //public GameObject[] cancel = new GameObject[7];

    void Start()
    {
        StartCoroutine(Countdown());   //呼叫倒數計時的協程
        //Debug.Log(player.transform.position);
    }

    public void AddTime(int secondsToAdd)
    {
        m_seconds += secondsToAdd;
        m_sec += secondsToAdd % 60;
        m_min += secondsToAdd / 60;

        if (m_sec >= 60)
        {
            m_sec -= 60;
            m_min += 1;
        }

        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00"));
    }

    IEnumerator Countdown()
    {
        m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00"));
        m_seconds = (m_min * 60) + m_sec;       //將時間換算為秒數

        while (m_seconds > 0)                   //如果時間尚未結束
        {
            yield return new WaitForSeconds(1); //等候一秒再次執行

            m_seconds--;                        //總秒數減 1
            m_sec--;                            //將秒數減 1

            if (m_sec < 0 && m_min > 0)         //如果秒數為 0 且分鐘大於 0
            {
                m_min -= 1;                     //先將分鐘減去 1
                m_sec = 59;                     //再將秒數設為 59
            }
            else if (m_sec < 0 && m_min == 0)   //如果秒數為 0 且分鐘大於 0
            {
                m_sec = 0;                      //設定秒數等於 0
            }
            m_timer.text = string.Format("{0}:{1}", m_min.ToString("00"), m_sec.ToString("00"));
        }

        while (m_seconds < 0)
        {
            Time.timeScale = 0;
        }
        yield return new WaitForSeconds(1);   //時間結束時，顯示 00:00 停留一秒
        m_gameOver.SetActive(true);           //時間結束時，畫面出現 GAME OVER
        bgm.SetActive(false);
        end_bgm.SetActive(true);
        GameObject_FT_LaserPointer.SetActive(true);
        Tennis.SetActive(false);
        //Debug.Log(player.transform.position);
        //player.transform.position = (455.8f, 3528f, 16.1f);
        player.transform.SetPositionAndRotation(end_player_position, Quaternion.Euler(end_player_rotation));

        
        /*for(int i = 0;i <= 6; i++)
        {
            cancel[i].SetActive(false);
        }*/
        //Destroy(collision.gameObject.CompareTag("STARS1") ? collision.gameObject) ;
        Time.timeScale = 0;                   //時間結束時，控制遊戲暫停無法操作


    }
}