using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_startforce : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody ball;
    [SerializeField, Range(0f, 100f)] float maxSpeed = 10f;
    public int gravity = -10000;
    private int times = 0, generate = 0;


    private System.DateTime moment1 = System.DateTime.Now;
    private int second1;


    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().Sleep();
        GetComponent<Rigidbody>().useGravity = false;
        // Physics.gravity = new Vector3(0, gravity, 0);
        // ball.velocity = transform.up * speed;
        //ball.velocity = new Vector3(0, 0,0);

        // transform.Translate(Vector3.forward * Time.deltaTime * 1000f);
        second1 = moment1.Second;

    }

    public int Generate
    {
        get
        {
            return generate;
        }
        set
        {
            generate = value;
        }
    }
        



    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ball.velocity.magnitude);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.velocity = new Vector3(0, 0, 10);
        }
        if (Input.GetKeyDown("a"))
        {
            ball.velocity = new Vector3(3, 5, 3);
        }
    }
     void FixedUpdate()
      {
        ball.velocity = ball.velocity.normalized * speed;
      }
    void OnCollisionEnter(Collision collision)
    {
       // Debug.Log(times);
        if(times == 20)
        {
            
            generate = 1;
            times = 0;
        }
        if (collision.gameObject.CompareTag("BOX1") || collision.gameObject.CompareTag("BOX2") || collision.gameObject.CompareTag("STARS1") || collision.gameObject.CompareTag("STARS2"))
        {
            times += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Tennis"))
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
       /* if (collision.gameObject.CompareTag("PLUS"))
        {
            Destroy(collision.gameObject);
        }*/
        if (collision.gameObject.CompareTag("wall"))
        {
               transform.position = new Vector3(455.8f, 528.06f, 61.8f);
               //ball.velocity = new Vector3(0, 0, 500);
               GetComponent<Rigidbody>().Sleep();
               GetComponent<Rigidbody>().useGravity = false;
        }

        moment1 = System.DateTime.Now;
        //Debug.Log(moment1);

        if (moment1.Second - second1 >= 5 || moment1.Second - second1 <= -55 )
        {
            //²yÂà´«¨¤«×
            ball.velocity = new Vector3(Random.Range(-50, 50),Random.Range(-50, 50),Random.Range(-50, 50));
            second1 = moment1.Second;
            //ball.velocity = new Vector3(0,-100,0);
        }
        if (collision.gameObject.CompareTag("BOX1") || collision.gameObject.CompareTag("BOX2") || collision.gameObject.CompareTag("STARS1") ||
            collision.gameObject.CompareTag("STARS2") ||collision.gameObject.CompareTag("Timer") || collision.gameObject.CompareTag("Tennis"))
        {
            second1 = moment1.Second;
        }
    }
}