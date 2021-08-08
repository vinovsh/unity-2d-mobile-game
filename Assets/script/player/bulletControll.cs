using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControll : MonoBehaviour
{
    // Start is called before the first frame update
   public  GameObject blast;

    void OnCollisionEnter2D(Collision2D coll) {
    
    GameObject blastEffect=Instantiate(blast,gameObject.transform.position,gameObject.transform.rotation);
       
      Destroy(gameObject);
      Destroy(blastEffect,0.5f);

     

     if(coll.gameObject.tag=="enemy"){

       coll.gameObject.GetComponent<enemyHealthController>().healthReduce(1);
     } 

        
    }
}
