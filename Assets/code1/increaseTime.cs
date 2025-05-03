using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseTime : MonoBehaviour
{
    public Game_Timer timer; // 引用Timer脚本，需要在Inspector中将Timer对象拖放到这个字段
    public int extraTime = 5; // 增加的时间（秒）

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 假设你的球有一个"Ball"的标签
        {
            timer.AddTime(extraTime); // 增加倒计时时间
        }
    }
}
