using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class MovingGear : MonoBehaviour
{
    // Start is called before the first frame update

   // public enum movePosition {left,right};


    public Transform start_point;
    public Transform end_point;


    public float speed;
     public bool canIMoveLeft;

    

     public Vector3 nextPos;
     public Vector3 currentPos;
     private bool start_move=true;

     GameObject player;

     

     public float spiner_speed;
  
    // Update is called once per frame
     void Start()
    {

        player=GameObject.FindWithTag("Player");
        
    }

    void FixedUpdate()
    {


       if(start_move==true){ 
           start_move=false;
          if(canIMoveLeft==true){
          
            currentPos=start_point.position;
      
            transform.eulerAngles=new Vector3(0,-180,transform.position.z);

           

          }else{

            currentPos=end_point.position;
         
            transform.eulerAngles=new Vector3(0,0,transform.position.z);
          }
      }

         transform.position = Vector3.MoveTowards(transform.position,currentPos, speed * Time.fixedDeltaTime);
         transform.Rotate(0,0, spiner_speed * Time.fixedDeltaTime*-1);

        if(start_point.position==transform.position){

            currentPos=end_point.position;
          
            transform.eulerAngles=new Vector3(0,0,transform.position.z);
        }

        if(end_point.position==transform.position){

            currentPos=start_point.position;
          
            transform.eulerAngles=new Vector3(0,-180,transform.position.z);
        } 
        
    }

   void OnTriggerEnter2D(Collider2D coll) {

     
    
     if(coll.gameObject.tag=="Player"){

        coll.gameObject.GetComponent<healthController>().healthReduce(1);

     }

     if(coll.gameObject.tag=="enemy"){

        coll.gameObject.GetComponent<enemyHealthController>().healthReduce(1);

     }

     
        
    }
}
