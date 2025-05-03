using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffect : MonoBehaviour
{
    public GameObject effect;
    public Vector3 effectOff;
  //  public ParticleSystem  particleSystem:

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Coroutine1());
            // GameObject explosionFX = Instantiate(effect, transform.position + effectOff, Quaternion.identity) as GameObject;
            // Destroy(explosionFX, 5);
            //Destroy();
        }
        
    }
/*
    public void Destroy()
    {
        Instantiate(particleSystem, transform.position , Quaternion.identity);
        Destroy(this.gameObject);
    }*/
    IEnumerator Coroutine1()
    {
        effect.SetActive(true);

        yield return new WaitForSeconds(3.0f);

       // Destroy(this.gameObject);

       // Destroy(box.gameObject);
    }
}
