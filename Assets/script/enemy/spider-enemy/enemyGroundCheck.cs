using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGroundCheck : MonoBehaviour
{
      // Start is called before the first frame update
    GameObject player;
    public bool isGround=true;


    void OnTriggerEnter2D(Collider2D other)
    {

       if(other.gameObject.tag=="ground"){

          isGround=true;
       

      }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
      if(col.gameObject.tag=="ground"){

        isGround=false;

      }
    }

   
}