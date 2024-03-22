using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody2D ballRigidbody2D;
    public float speedx; //水平速度
    public float speedy; //垂直速度
    // Start is called before the first frame update
    void Start()
    {
      
        ballRigidbody2D = GetComponent<Rigidbody2D>();
        ballRigidbody2D.velocity = new Vector2(0, -speedy);
       
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "DeathLine")
            {
             
            }
        }
    }
   void OnCollisionEnter2D(Collision2D collision)
    {
        lockSpeed();
    }
    void lockSpeed()
    {
        Vector2 lockSpeed = new Vector2(restSpeedx(), restSpeedy());
        ballRigidbody2D.velocity = lockSpeed;
    }
    float restSpeedx()
    {
        float CurrentSpeedx = ballRigidbody2D.velocity.x;
        if (CurrentSpeedx <0) 
        {
            return -speedx ;
        }
        else 
        {
            return speedx;
        }
    }
    float restSpeedy()
    {
        float CurrentSpeedy = ballRigidbody2D.velocity.y;
        if (CurrentSpeedy <0)
        {
            return -speedy;
        }
        else
        {
            return speedy;
        }
    }
}
