using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private float moveH, moveV;
    private string lastDirection;

    [SerializeField] private float moveSpeed = 2.0f;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
  

    // Update is called once per frame
    // void Update()
    // {
    //     moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
    //     moveV = Input.GetAxisRaw("Vertical") * moveSpeed;
    //     rb.velocity= new Vector2(moveH, moveV);
    //
    // }

    private void FixedUpdate()
    {
        // moveH = Input.GetAxis("Horizontal") * moveSpeed;
        // moveV = Input.GetAxis("Vertical") * moveSpeed;
        // rb.velocity = new Vector2(moveH,moveV);
        //
        // Vector2 direction = new Vector2(moveH,moveV);
        // FindObjectOfType<PlayerAnimation>().SetDirection(direction);
      
            moveH = Input.GetAxis("Horizontal") * moveSpeed;
            moveV = Input.GetAxis("Vertical") * moveSpeed;
            rb.velocity = new Vector2(moveH,moveV);
            
            // Movement in basic formation
            if(Input.GetKey(KeyCode.W))
            {
                FindObjectOfType<PlayerAnimation>().Movement("Run N");
                lastDirection = "Static N";
            }
            else if (Input.GetKey(KeyCode.S))
            {
                FindObjectOfType<PlayerAnimation>().Movement("Run S");
                lastDirection = "Static S";
            }
            else if (Input.GetKey(KeyCode.A))
            {
                FindObjectOfType<PlayerAnimation>().Movement("Run W");
                lastDirection = "Static W";
            }
            else if (Input.GetKey(KeyCode.D))
            {
                
                FindObjectOfType<PlayerAnimation>().Movement("Run E");
                lastDirection = "Static E";
            }
            
            //Movement at in cross formation
            else if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.D))
            {
                FindObjectOfType<PlayerAnimation>().Movement("Run NE");
                lastDirection = "Static NE";
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))

            {
                FindObjectOfType<PlayerAnimation>().Movement("Run NW");
                lastDirection = "Static NW";
            }

            else if (Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.D))
            {
                FindObjectOfType<PlayerAnimation>().Movement("Run SE");
                lastDirection = "Static SE";
            }
            else if (Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.A))
            {
                FindObjectOfType<PlayerAnimation>().Movement("Run SW");
                lastDirection = "Static SW";
            }

            // else if not pressing a button stand still in the last direction
            else
            {
                rb.velocity = Vector2.zero;
                FindObjectOfType<PlayerAnimation>().Movement(lastDirection);   
            }
            
            
            
            
            /*if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.D))
            {
                FindObjectOfType<PlayerAnimation>().Movement("Run NE");
                lastDirection = "Static NE";
            }
            else if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.A))

            {
                FindObjectOfType<PlayerAnimation>().Movement("Run NW");
                lastDirection = "Static NW";
            }
            
            
            else if (Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.D))
            {
                FindObjectOfType<PlayerAnimation>().Movement("Run SE");
                lastDirection = "Static SE";
            }
            else if (Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.A))
            {
                FindObjectOfType<PlayerAnimation>().Movement("Run SW");
                lastDirection = "Static SW";
            }*/
        
    }
    
    
    
}

