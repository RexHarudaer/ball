using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{   float moveSpeed = 15;
    Rigidbody2D PlayerRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(-0.03f, -5.32f, 0);
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {    
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed*Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed*Time.deltaTime, 0, 0);
        }

        //void OnCollisionEnter2D(Collision2D other)
        //{
           // if (other.gameObject.name == "ball")
            //{
                
            //}
          
       // } 
        //void  OnTriggerEnter2D(Collision2D other)
        //{
           // if (other.gameObject.name == "ball")
            //{
                
           // }
      //  }

    }
}
