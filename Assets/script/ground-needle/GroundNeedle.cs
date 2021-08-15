using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundNeedle : MonoBehaviour
{
    // Start is called before the first frame update
  void OnCollisionEnter2D(Collision2D coll) {
    
     if(coll.gameObject.tag=="Player"){

        coll.gameObject.GetComponent<healthController>().healthReduce(1);

     }

     if(coll.gameObject.tag=="enemy"){

        coll.gameObject.GetComponent<enemyHealthController>().healthReduce(1);

     }

     
        
    }

      void OnCollisionStay2D(Collision2D coll)
     {
          if(coll.gameObject.tag=="Player"){

        coll.gameObject.GetComponent<healthController>().healthReduce(1);

     }

     if(coll.gameObject.tag=="enemy"){

        coll.gameObject.GetComponent<enemyHealthController>().healthReduce(1);

     }
     }
}
