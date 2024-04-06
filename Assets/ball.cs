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
      
    public int score = 0 ; //玩家1分數
    public int score1 = 0;  //玩家2分數

    [SerializeField] Text scoreText; //顯示文字UI 共用分數欄
    [SerializeField] Text scoreText2; //顯示文字UI 共用分數欄2
    [SerializeField] GameObject Replay;//
    [SerializeField] GameObject play;//
    Rigidbody2D ballRigidbody2D;//
    public float speedx; //水平速度
    public float speedy; //垂直速度
    private Vector3 initialPosition;//紀錄初始位置變數
   
    // Start is called before the first frame update
    void Start()
    {
            Time.timeScale = 0;//程式運行度等於0
        initialPosition = transform.position; //記住當前位置
            ballRigidbody2D = GetComponent<Rigidbody2D>();//取得物件Rigidbody2D
            ballRigidbody2D.velocity = new Vector2(0, -speedy);//設定初始運動方向
       
       
    }
   
    // something before delay
   
    // something after delay
    // Update is called once per frame
    void Update()
    {

        // if (transform.position.y > 10) 如果y大於10
        // {
        //  transform.position = initialPosition; 回到上次紀錄位置
        //    Start(); 呼叫Start()
        // }
        // else if (transform.position.y < -10)如果y小於-10
        //{
        //   transform.position = initialPosition;回到上次紀錄位置
        //   Start(); 呼叫Start()

        //}

    }

    void OnTriggerEnter2D(Collider2D other) //接觸判斷
    {
       if (other.gameObject.tag == "DeathLine")//如果此物件碰到"DeathLine"tag物件
        {
            score ++; //玩家1分數加1
            if (score > 5)//如果玩家1分數大於5
            {
                score = 5;//玩家1分數等於5
            }
            scoreText.text = score.ToString();//把新的文字改到文字物件上面,把現在數字轉成字串
            transform.position = initialPosition; //回到上次紀錄位置
            ballRigidbody2D.velocity = new Vector2(0, 0);//將運動方向，速度設為零
            Invoke("ballstar", 2f);//延遲兩秒後呼叫 ballstar();
            Die();//呼叫Die();
        }
        else if (other.gameObject.tag == "DeathLine2")////如果此物件碰到"DeathLine2"tag物件
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
    

    void OnCollisionEnter2D(Collision2D collision)//設定運動速度
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
   void Die()//如果分數大於等於5程式運行度等於0
    {
        if (score >= 5)
        {
            Time.timeScale = 0;
            Replay.SetActive(true);//顯示繼續遊戲按鈕
        }
        else if (score1 >= 5)
        {
            Time.timeScale = 0;
            Replay.SetActive(true);
        }
    }
    public void GameReplay()//按下按鈕重新執行遊戲
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    public void Gameplay()//設定開始按鈕
    {
        Time.timeScale = 1;
       
        play.SetActive(false);
    }
}
