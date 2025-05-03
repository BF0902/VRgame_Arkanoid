using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public delegate void PlayerScore(int temp);//定義委託
    public event PlayerScore GetScore;//定義得分事件，用於發出得分的訊息
    void Start()
    {

    }
    void Update()//在Update()中新增Player的移動控制
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * 2f);//物件可以朝著世界座標向前移動
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * 2f);//物件可以朝著世界座標向前移動
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * 2f);//物件可以朝著世界座標向前移動
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * 2f);//物件可以朝著世界座標向前移動
        }
    }
      /*public void OnTriggerStay(Collider other)//設定觸發器碰撞事件，一旦Player穿過了ScoreObj,就傳送得分事件
      {
          if (other.gameObject.name.Equals("ScoreObj"))//檢查Player碰撞的物體是不是ScoreObj
          {
              if (GetScore != null)//檢查事件是否為空，即有沒有接收器訂閱它
              {
                  GetScore(1);//傳送得分事件訊息，為接收器提供引數1，實現+1分的效果
              }
          }
      }*/

    public void OnCollisionStay(Collision collision)//設定觸發器碰撞事件，一旦Player穿過了ScoreObj,就傳送得分事件
    {
        if (collision.gameObject.name.Equals("ScoreObj"))//檢查Player碰撞的物體是不是ScoreObj
        {
            if (GetScore != null)//檢查事件是否為空，即有沒有接收器訂閱它
            {
                GetScore(1);//傳送得分事件訊息，為接收器提供引數1，實現+1分的效果
            }
        }
    }
}