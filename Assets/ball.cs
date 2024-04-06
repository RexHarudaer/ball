using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;



public class ball : MonoBehaviour
{   
      
    public int score = 0 ;
    public int score1 = 0;
    
    [SerializeField] Text scoreText;
    [SerializeField] Text scoreText2;
    [SerializeField] GameObject Replay;
    [SerializeField] GameObject play;
    Rigidbody2D ballRigidbody2D;
    public float speedx; //水平速度
    public float speedy; //垂直速度
    private Vector3 initialPosition;
   
    // Start is called before the first frame update
    void Start()
    {
            Time.timeScale = 0;
            initialPosition = transform.position; //記住當前位置
            ballRigidbody2D = GetComponent<Rigidbody2D>();
            ballRigidbody2D.velocity = new Vector2(0, -speedy);
       
       
    }
   
    // something before delay
   
    // something after delay
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
            if (score > 5)
            {
                score = 5;
            }
            scoreText.text = score.ToString();
            transform.position = initialPosition;
            ballRigidbody2D.velocity = new Vector2(0, 0);
            Invoke("ballstar", 2f);
            Die();
        }
        else if (other.gameObject.tag == "DeathLine2")
        {
            score1 ++;
            if (score1 > 5)
            {
                score1 = 5;
               
            }
           
            scoreText2.text = score1.ToString();
            transform.position = initialPosition;
            ballRigidbody2D.velocity = new Vector2(0, 0);
            Invoke("ballstar", 2f);
            Die();

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
   void ballstar()
    {
        initialPosition = transform.position;     
        ballRigidbody2D = GetComponent<Rigidbody2D>();      
        ballRigidbody2D.velocity = new Vector2(0, -speedy);
    
    }
   void Die()
    {
        if (score >= 5)
        {
            Time.timeScale = 0;
            Replay.SetActive(true);
        }
        else if (score1 >= 5)
        {
            Time.timeScale = 0;
            Replay.SetActive(true);
        }
    }
    public void GameReplay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    public void Gameplay()
    {
        Time.timeScale = 1;
       
        play.SetActive(false);
    }
}
