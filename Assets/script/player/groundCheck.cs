using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start(){

         player = GameObject.FindWithTag("Player");

        
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
         
      if(col.gameObject.tag=="ground"){

        player.GetComponent<playerController>().isGround=true;

      }

      if(col.gameObject.tag=="enemy"){

        
          

         if(col.gameObject.GetComponent<enemyHealthController>().isEnemyAlive){

            col.gameObject.GetComponent<enemyHealthController>().healthReduce(1);
          Rigidbody2D rb=player.GetComponent<Rigidbody2D>();

             // rb.AddForce(Vector2.up*20,ForceMode2D.Impulse);
             rb.velocity=Vector2.up*10;
         }
     }
        
      
   
    }

    void OnCollisionExit2D(Collision2D col)
    {
      if(col.gameObject.tag=="ground"){

        player.GetComponent<playerController>().isGround=false;

      }
    }

   
}
