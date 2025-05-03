using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Player : MonoBehaviour
{
    public delegate void Game_PlayerScore(int temp);
    public event Game_PlayerScore GetScore;


    public Game_Timer timer; // 引用Timer脚本，需要在Inspector中将Timer对象拖放到这个字段
    public int extraTime = 5; // 增加的时间（秒）

    private AudioSource audioData1;
    public AudioSource[] audioData2 = new AudioSource[3];


    void Start()
    {
        audioData1 = GetComponent<AudioSource>();

    }
    public void OnCollisionEnter(Collision collision)
    {
        //audioData1.Play(0);
        if (collision.gameObject.CompareTag("BOX1"))
        {
            audioData2[0].Play(0);

            if (GetScore != null)
            {
                GetScore(1);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("BOX2"))
        {
            //audioData2[0].Play(0);
            audioData2[0].Play(0);//test用

            if (GetScore != null)
            {
                GetScore(5);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("STARS1"))
        {
            //audioData2[0].Play(0);
            audioData2[1].Play(0);//test用

            if (GetScore != null)
            {
                GetScore(1);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("STARS2"))
        {
            //audioData2[0].Play(0);
            audioData2[1].Play(0);//test用

            if (GetScore != null)
            {
                GetScore(5);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Timer"))
        {
            audioData2[2].Play(0);
            if (GetScore != null)
            {
                GetScore(3);
            }
            timer.AddTime(extraTime); // 增加倒计时时间
            Destroy(collision.gameObject);
        }
        else
        {
            audioData1.Play(0);
        }
    }

    

}

