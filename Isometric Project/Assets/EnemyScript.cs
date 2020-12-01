using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]Transform player;
    [SerializeField] private float aggroRange;
    [SerializeField] private float moveSpeed;
    private Vector2 movement;
    private Rigidbody2D rb2d;
    private string lastDirection;
    private string attackDirection;
    private string moveDirection;
    
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        direction.Normalize();
        movement = direction;
        
        if (angle > 0 && angle < 80)
        {
            //FindObjectOfType<EnemyAnimation>().Movement("Static NE"); 
            lastDirection = "Static NE";
            attackDirection = "Attack NE";
            moveDirection = "Walk NE";


        }
        if (angle > 80 && angle < 120)
        {
            //FindObjectOfType<EnemyAnimation>().Movement("Static N"); 
            lastDirection = "Static N";
            attackDirection = "Attack N";
            moveDirection = "Walk N";
            
        }
        if (angle > 120 && angle < 160)
        {
         //   FindObjectOfType<EnemyAnimation>().Movement("Static NW");
            lastDirection = "Static NW";
            attackDirection = "Attack NW";
            moveDirection = "Walk NW";
        }
        
        if (angle < 0 && angle > -60)
        {
            //FindObjectOfType<EnemyAnimation>().Movement("Static SE");
            lastDirection = "Static SE";
            attackDirection = "Attack SE";
            moveDirection = "Walk SE";
        }
        if (angle < -60 && angle >= -150)
        {
           // FindObjectOfType<EnemyAnimation>().Movement("Static S");
            lastDirection = "Static S";
            attackDirection = "Attack S";
            moveDirection = "Walk S";
        }
        if (angle < -155 && angle >= -179)
        {
           // FindObjectOfType<EnemyAnimation>().Movement("Static SW");
            lastDirection = "Static SW";
            attackDirection = "Attack SW";
            moveDirection = "Walk SW";
        }
       
       // rb2d.rotation = angle;
        
        /*float distToPlayer = Vector2.Distance(transform.position,player.position);
        if (distToPlayer > aggroRange)
        {
            StopChasingPlayer();
        }
       
        else if (distToPlayer < aggroRange && distToPlayer>1.2){
            
                 
            
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                if (transform.position.x < player.position.x && transform.position.y < player.position.y)
                {
                    //   rb2d.velocity = new Vector2(moveSpeed, moveSpeed);
                    FindObjectOfType<EnemyAnimation>().Movement("Walk NE");
                    lastDirection = "Static NE";
                    attackDirection = "Attack NE";
          
        
                    //attackDirection = "Attack NE";
                    //lastDirection = "Static NE";

                }
        
                else if (transform.position.x > player.position.x && transform.position.y < player.position.y)
                {
                    //rb2d.velocity = new Vector2(-moveSpeed, moveSpeed);
                    FindObjectOfType<EnemyAnimation>().Movement("Walk NW");
                    lastDirection = "Static NW";
                    attackDirection = "Attack NW";
             
          
         
           
                }   
        
        
                else if (transform.position.x < player.position.x && transform.position.y > player.position.y)
                {
                    // rb2d.velocity = new Vector2(moveSpeed, -moveSpeed);
           
                    FindObjectOfType<EnemyAnimation>().Movement("Walk SE");
                    lastDirection = "Static SE";
                    attackDirection = "Attack SE";
          
            
                }
        
                else if (transform.position.x > player.position.x && transform.position.y > player.position.y)
                {
                    // rb2d.velocity = new Vector2(-moveSpeed, -moveSpeed);
                    FindObjectOfType<EnemyAnimation>().Movement("Walk SW");
                    lastDirection = "Static SW";
                    attackDirection = "Attack SW";


                }
            
        }
        else
        {
            AttackPlayer();
        }*/
        /*  
        // check distance to player
        float distToPlayer = Vector2.Distance(transform.position,player.position);
        print("distToPlayer: "+distToPlayer);

        if (distToPlayer < aggroRange)
        {
            // chase player
            ChasePlayer();
        }
        else
        {
           // Stop chasing Player 
           StopChasingPlayer();
        }
        if( distToPlayer<1.5)
        {
            AttackPlayer();
        }
      if(distToPlayer<1.0)
        {
            AttackPlayer();
        }
*/
        // else
        // {
        //     AttackPlayer();a
        // }


    }

    private void FixedUpdate()
 
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer > aggroRange)
        {
            StopChasingPlayer();
        }
        else if (distToPlayer<1.0)
        {
            AttackPlayer(); 
        }
        else
        {
          moveCharacter(movement);  
        }
        
    }

    void  moveCharacter(Vector2 direction)
    {
        FindObjectOfType<EnemyAnimation>().Movement(moveDirection);
        rb2d.MovePosition((Vector2)transform.position+ (direction * moveSpeed * Time.deltaTime));
    }

    
    private void AttackPlayer()
    {
        Debug.Log("Attack");
        
        rb2d.velocity = new Vector2(0, 0);
        FindObjectOfType<EnemyAnimation>().Movement(attackDirection);
       
        


    }

    void StopChasingPlayer()
    {
        Debug.Log("Too Far");
        rb2d.velocity = new Vector2(0, 0);
        FindObjectOfType<EnemyAnimation>().Movement(lastDirection);
    }
    void ChasePlayer()
    {
        // enemy the left of the player want to move right
        if (transform.position.x < player.position.x)
        {
            Mathf.FloorToInt(transform.position.x);
            rb2d.velocity = new Vector2(moveSpeed, 0);
            Debug.Log("Move Right");
            //lastDirection = "Static N";
           // attackDirection = "Attack N";
            


        }
        
        
        // enemy on the right of the player move left
        if(transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            Debug.Log("Move Left");
            //lastDirection = "Static NW";
          //  attackDirection = "Attack NW";
           
            

           
        }
        
        //working 
        if (transform.position.y > player.position.y)
        {
           rb2d.velocity = new Vector2(0, -moveSpeed);
           Debug.Log("Move Down");
           // lastDirection = "Static SE";
         //   attackDirection = "Attack SE";
            
            
  
        }
        
        if (transform.position.y < player.position.y)
        {
            rb2d.velocity = new Vector2(0, moveSpeed);
            Debug.Log("Move Up");
            //lastDirection = "Static NW";
           // attackDirection = "Attack NW";
            
          
        }
      /*  
        float distToPlayer = Vector2.Distance(transform.position,player.position);
        
        if (transform.position.x < player.position.x && transform.position.y < player.position.y)
        {
            rb2d.velocity = new Vector2(moveSpeed, moveSpeed);
           FindObjectOfType<EnemyAnimation>().Movement("Walk NE");
           lastDirection = "Static NE";
           attackDirection = "Attack NE";
          
        
            //attackDirection = "Attack NE";
           //lastDirection = "Static NE";

        }
        
        else if (transform.position.x > player.position.x && transform.position.y < player.position.y)
        {
            rb2d.velocity = new Vector2(-moveSpeed, moveSpeed);
            FindObjectOfType<EnemyAnimation>().Movement("Walk NW");
            lastDirection = "Static NW";
             attackDirection = "Attack NW";
             
          
         
           
        }   
        
        
        else if (transform.position.x < player.position.x && transform.position.y > player.position.y)
        {
            rb2d.velocity = new Vector2(moveSpeed, -moveSpeed);
           
            FindObjectOfType<EnemyAnimation>().Movement("Walk SE");
            lastDirection = "Static SE";
            attackDirection = "Attack SE";
          
            
        }
        
        else if (transform.position.x > player.position.x && transform.position.y > player.position.y)
        {
            rb2d.velocity = new Vector2(-moveSpeed, -moveSpeed);
            FindObjectOfType<EnemyAnimation>().Movement("Walk SW");
            lastDirection = "Static SW";
           attackDirection = "Attack SW";


        }
        else if (Mathf.FloorToInt(transform.position.x) == Mathf.FloorToInt(player.position.x)&& transform.position.y > player.position.y  )
        {
            rb2d.velocity = new Vector2(0, -moveSpeed);
        }
        else if (Mathf.FloorToInt(transform.position.x) == Mathf.FloorToInt(player.position.x) && transform.position.y < player.position.y  )
        {
            rb2d.velocity = new Vector2(0, moveSpeed);
        }
        else if (transform.position.x > player.position.x && Mathf.FloorToInt(transform.position.y) == Mathf.FloorToInt(player.position.y)  )
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
        }
        else if (transform.position.x < player.position.x && Mathf.FloorToInt(transform.position.y) == Mathf.FloorToInt(player.position.y) ) 
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
        }

   
*/
    }
    
}
