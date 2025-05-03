using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject Spere;
    //public GameObject Camera1;
    // Start is called before the first frame update
    void Start()
    {
        //Spere.transform.position = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera1.transform.position = Spere.transform.position;
        Camera.main.transform.position = Spere.transform.position;
    }
}
