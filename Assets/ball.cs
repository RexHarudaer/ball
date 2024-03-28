using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ball : MonoBehaviour
{
    int score = 0 ;
    int score1 = 0;
    float ballDelay = 2;
    [SerializeField] Text scoreText;
    [SerializeField] Text scoreText2;
    Rigidbody2D ballRigidbody2D;
    public float speedx; //水平速度
    public float speedy; //垂直速度
    private Vector3 initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
     
            initialPosition = transform.position;
            ballRigidbody2D = GetComponent<Rigidbody2D>();
            ballRigidbody2D.velocity = new Vector2(0, -speedy);
            
       
    }
   
    // Update is called once per frame
    void Update()
    {
        
           // if (transform.position.y > 10)
          // {
              //  transform.position = initialPosition;
            //    Start();
           // }
           // else if (transform.position.y < -10)
            //{
             //   transform.position = initialPosition;
             //   Start();

            //}
        
    }

     void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag == "DeathLine")
        {
            score ++;
            scoreText.text = score.ToString();
            transform.position = initialPosition;
            Start();
        }
        else if (other.gameObject.tag == "DeathLine2")
        {
            score1 ++;
            scoreText2.text = score1.ToString();
            transform.position = initialPosition;
            Start();
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
