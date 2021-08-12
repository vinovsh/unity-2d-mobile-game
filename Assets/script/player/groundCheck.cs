using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class groundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Rigidbody2D rb;
    public AudioSource jumpDownSound;

    private float groundExitTime=0f;
    void Start(){

         player = GameObject.FindWithTag("Player");

         rb=player.GetComponent<Rigidbody2D>();

        
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
         
      if(col.gameObject.tag=="ground" || col.gameObject.tag=="platform"){

        player.GetComponent<playerController>().isGround=true;
      
         if (!jumpDownSound.isPlaying && Time.time > groundExitTime+0.1f)
          {
            groundExitTime=0f;
            jumpDownSound.Play();

          }
        
        // player.transform.parent = col.gameObject.transform;
       // player.transform.SetParent(col.gameObject.transform);
       //rb.interpolation = RigidbodyInterpolation2D.None;

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
      if(col.gameObject.tag=="ground" || col.gameObject.tag=="platform"){

        player.GetComponent<playerController>().isGround=false;
       // player.transform.parent = null;
       // player.transform.SetParent(null);
       groundExitTime=Time.time;

      }
    }

   
}
