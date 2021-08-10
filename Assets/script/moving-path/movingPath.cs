using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class movingPath : MonoBehaviour
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
           

          }else{

            currentPos=end_point.position;
          }
      }

         transform.position = Vector3.MoveTowards(transform.position,currentPos, speed * Time.fixedDeltaTime);

        if(start_point.position==transform.position){

            currentPos=end_point.position;
        }

        if(end_point.position==transform.position){

            currentPos=start_point.position;
        } 
        
    }

     private void OnCollisionEnter2D(Collision2D other)
    {

        if(other.collider.gameObject.tag=="toe"){

            player.transform.parent = gameObject.transform ;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {

        if(other.collider.gameObject.tag=="toe"){

            player.transform.parent = null;
        }
        
    } 
}
