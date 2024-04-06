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
      
    public int score = 0 ; //���a1����
    public int score1 = 0;  //���a2����

    [SerializeField] Text scoreText; //��ܤ�rUI �@�Τ�����
    [SerializeField] Text scoreText2; //��ܤ�rUI �@�Τ�����2
    [SerializeField] GameObject Replay;//
    [SerializeField] GameObject play;//
    Rigidbody2D ballRigidbody2D;//
    public float speedx; //�����t��
    public float speedy; //�����t��
    private Vector3 initialPosition;//������l��m�ܼ�
   
    // Start is called before the first frame update
    void Start()
    {
            Time.timeScale = 0;//�{���B��׵���0
        initialPosition = transform.position; //�O���e��m
            ballRigidbody2D = GetComponent<Rigidbody2D>();//���o����Rigidbody2D
            ballRigidbody2D.velocity = new Vector2(0, -speedy);//�]�w��l�B�ʤ�V
       
       
    }
   
    // something before delay
   
    // something after delay
    // Update is called once per frame
    void Update()
    {

        // if (transform.position.y > 10) �p�Gy�j��10
        // {
        //  transform.position = initialPosition; �^��W��������m
        //    Start(); �I�sStart()
        // }
        // else if (transform.position.y < -10)�p�Gy�p��-10
        //{
        //   transform.position = initialPosition;�^��W��������m
        //   Start(); �I�sStart()

        //}

    }

    void OnTriggerEnter2D(Collider2D other) //��Ĳ�P�_
    {
       if (other.gameObject.tag == "DeathLine")//�p�G������I��"DeathLine"tag����
        {
            score ++; //���a1���ƥ[1
            if (score > 5)//�p�G���a1���Ƥj��5
            {
                score = 5;//���a1���Ƶ���5
            }
            scoreText.text = score.ToString();//��s����r����r����W��,��{�b�Ʀr�ন�r��
            transform.position = initialPosition; //�^��W��������m
            ballRigidbody2D.velocity = new Vector2(0, 0);//�N�B�ʤ�V�A�t�׳]���s
            Invoke("ballstar", 2f);//�������I�s ballstar();
            Die();//�I�sDie();
        }
        else if (other.gameObject.tag == "DeathLine2")////�p�G������I��"DeathLine2"tag����
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
    

    void OnCollisionEnter2D(Collision2D collision)//�]�w�B�ʳt��
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
   void Die()//�p�G���Ƥj�󵥩�5�{���B��׵���0
    {
        if (score >= 5)
        {
            Time.timeScale = 0;
            Replay.SetActive(true);//����~��C�����s
        }
        else if (score1 >= 5)
        {
            Time.timeScale = 0;
            Replay.SetActive(true);
        }
    }
    public void GameReplay()//���U���s���s����C��
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    public void Gameplay()//�]�w�}�l���s
    {
        Time.timeScale = 1;
       
        play.SetActive(false);
    }
}
