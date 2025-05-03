using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class col : MonoBehaviour
{
    public GameObject water; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision other) {
       if (other.gameObject.CompareTag("BOX"))
        {
            // StartCoroutine(Coroutine1());
            Instantiate(water, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }
    /*
    IEnumerator Coroutine1()
    {
        //fire.SetActive(true);
        Destroy(this.gameObject);

        Destroy(box.gameObject);
    }*/
}
