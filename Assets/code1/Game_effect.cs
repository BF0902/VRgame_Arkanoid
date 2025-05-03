using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_effect : MonoBehaviour
{
    public GameObject collisionEffectPrefab;
    public float hideDelay = 2f;

    private GameObject currentEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (currentEffect == null)
        {
            // 在碰撞點位置創建特效
            Vector3 collisionPoint = collision.GetContact(0).point;
            currentEffect = Instantiate(collisionEffectPrefab, collisionPoint, Quaternion.identity);
        }
        else
        {
            // 重置特效位置並重新啟用
            currentEffect.transform.position = collision.GetContact(0).point;
            currentEffect.SetActive(true);
        }

        // 延遲隱藏特效
        Invoke("HideEffect", hideDelay);
    }

    private void HideEffect()
    {
        // 隱藏特效
        currentEffect.SetActive(false);
    }
}