using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;

    public float smoothFactor;
    public Vector3 offset;
    public float offset2;

    public bool isPlayerTop=false;

    public bool isPlayerbottom=false;

    public float restricted_player_top_area;
    public float restricted_player_bottom_area;
    void Start()
    {
      
       player = GameObject.FindWithTag("Player");
      //Destroy(player1);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       Vector3 targetPosition=player.transform.position+offset;

       Vector3 smoothPosition=Vector3.Lerp(transform.position,targetPosition,smoothFactor*Time.fixedDeltaTime);
       smoothPosition.z=transform.position.z;


      if(player.transform.position.y >=transform.position.y+restricted_player_top_area){

          isPlayerTop=true;
      }if(player.transform.position.y <=transform.position.y+restricted_player_bottom_area){
        
          isPlayerbottom=true;
      }else if(player.GetComponent<playerController>().isGround==true){

         isPlayerTop=false; 
         isPlayerbottom=false;
      }



      /*  if(player.transform.position.y >=4f){

           transform.position=smoothPosition;
       }else if(player.transform.position.y <=-4f){

           transform.position=smoothPosition;
       } */
      
      if(isPlayerTop==false && isPlayerbottom==false){
           

        if(player.GetComponent<playerController>().isGround==true){

         

          //transform.position=new Vector3(player.transform.position.x,player.transform.position.y+offset2,transform.position.z);
          transform.position=smoothPosition;
          

        }else if(player.GetComponent<playerController>().isGround==false){

           transform.position=new Vector3(smoothPosition.x,transform.position.y,transform.position.z);
        }

      }else if(isPlayerTop==true){
          if(player.GetComponent<playerController>().hit_bottom_distance < 4.7f){
             
             transform.position=new Vector3(smoothPosition.x,transform.position.y,transform.position.z);

          }else{

             transform.position=new Vector3(smoothPosition.x,player.transform.position.y-restricted_player_top_area,transform.position.z);
          }
          
      }else if(isPlayerbottom==true){

          transform.position=smoothPosition;
      }
       
     
        
    }
}
