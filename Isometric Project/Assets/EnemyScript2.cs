using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript2 : MonoBehaviour
{ 
     Transform player;
    [SerializeField] private float aggroRange;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb2d;
    private string lastDirection;
    private string attackDirection;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position,player.position);
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
        }
        

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

}
