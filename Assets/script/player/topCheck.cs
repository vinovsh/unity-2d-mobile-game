using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class topCheck : MonoBehaviour
{
   
   GameObject player;
    private void Start()
    {

      player=GameObject.FindWithTag("Player");
        
    }
    




    private void OnCollisionEnter2D(Collision2D other)
  {
      string tag=other.gameObject.tag;
      if(tag=="box"){

        if(player.GetComponent<playerController>().isMoving==true){
              
              other.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.right*3;
            
           

         }

          
      }
  }

  
  
}
