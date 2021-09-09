using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinnerAttack : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject player;
    void Start()
    {

          player=GameObject.FindWithTag("Player");
        
    }
   private void OnTriggerEnter2D(Collider2D other)
    {
      

        if(other.gameObject.tag=="Player"){

           other.gameObject.GetComponent<healthController>().healthReduce(1);

        }
        
    }
}
