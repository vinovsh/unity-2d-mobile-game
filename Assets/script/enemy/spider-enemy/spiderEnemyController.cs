using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderEnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;

    public Vector3 right_offset; 
    public Vector3 bottom_offset;

    public Vector3 left_offset;

    public float raycast_distance_right;
    public float raycast_distance_bottom;
    public float raycast_distance_left;

    public int move_direction=-1;

    public bool canWalk;

    public bool attack=false;

  
    public float speed;

    public float scriptActivation_diatance;

    GameObject player;
    public Animator anim;

    AudioSource dieSound;

    private float lastAttack = 0.0f;
    public float attackRate;

    public bool isEnemyAlive=true;

    public bool isGround=true;

    public GameObject ground_check_object;

    float turn_time=0;

    public bool isActiveDeadSection=false;
    void Start()
    {

        rb=GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        anim = anim.GetComponent<Animator>();
        dieSound=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

       //if(player.transform.position.x > this.transform.position.x-scriptActivation_diatance || player.transform.position.x > this.transform.position.x+scriptActivation_diatance){
        isEnemyAlive=gameObject.GetComponent<enemyHealthController>().isEnemyAlive; 
        isGround=ground_check_object.GetComponent<enemyGroundCheck>().isGround; 

    

         
       if(isGround==false){

         canWalk=false;
         
       }
         

     

        if(isEnemyAlive && isGround){
           Vector3 rightOffsetCorrection=new Vector3(right_offset.x*move_direction,right_offset.y,right_offset.z);
           Vector3 bottomOffsetCorrection=new Vector3(bottom_offset.x*move_direction,bottom_offset.y,bottom_offset.z);
           Vector3 leftOffsetCorrection=new Vector3(left_offset.x*move_direction,left_offset.y,left_offset.z);

           RaycastHit2D hit_right = Physics2D.Raycast(transform.position+rightOffsetCorrection, transform.TransformDirection(Vector3.right),raycast_distance_right);
           Debug.DrawRay(transform.position+rightOffsetCorrection,transform.TransformDirection(Vector3.right)*raycast_distance_right,Color.red);

           RaycastHit2D hit_bottom = Physics2D.Raycast(transform.position+bottomOffsetCorrection, Vector2.down,raycast_distance_bottom);
           Debug.DrawRay(transform.position+bottomOffsetCorrection,Vector2.down*raycast_distance_bottom,Color.red);

           RaycastHit2D hit_left = Physics2D.Raycast(transform.position+leftOffsetCorrection, transform.TransformDirection(Vector3.left),raycast_distance_left);
           Debug.DrawRay(transform.position+leftOffsetCorrection,transform.TransformDirection(Vector3.left)*raycast_distance_left,Color.red);

         
	        
          if(hit_right.collider!=null){


              GameObject obj=hit_right.collider.gameObject;
	          if(obj.tag=="ground" || obj.tag=="box"){

               

                  
                  canWalk=true;
                  attack=false;

                  
                  if(hit_right.distance < 0.3 && Time.time > turn_time){

                     if(move_direction==1){

                        move_direction=-1;
                        turn_time=Time.time+0.5f;
                     }else{

                        move_direction=1;
                        turn_time=Time.time+0.5f;
                     }

                     

                  }
              }

              if(obj.CompareTag("Player")){
              
                if(hit_right.distance < 0.2f){

                    attack=true;
                    canWalk=false;
                }else{

                    attack=false;
                    canWalk=true;
                }
                 
              }else{

                  attack=false;
                  canWalk=true;
              }
           }else{

              attack=false;
              canWalk=true;
           }

           if(hit_bottom.collider!=null){



              if(hit_bottom.distance>0.4){

                  if(move_direction==1){

                     move_direction=-1;
                  }else{

                     move_direction=1;
                  }
              }

            
           }else{

               if(move_direction==1){

                     move_direction=-1;
               }else{

                     move_direction=1;
               }
           }

           

           //movement section
        if(canWalk){

             anim.SetInteger("walk", 1);
             if(move_direction==1){

               transform.eulerAngles=new Vector3(0,0,0);
       
               transform.position+=new Vector3(1,0,0)*Time.deltaTime*speed;
                
            }else{

               transform.eulerAngles=new Vector3(0,180,0);
         
               transform.position+=new Vector3(-1,0,0)*Time.deltaTime*speed;
           }

        }else{

           anim.SetInteger("walk", 0);
        }

        if(attack){

           

             if (Time.time > attackRate + lastAttack && isEnemyAlive)
            {

                anim.SetInteger("attack", 1);
            
                player.GetComponent<healthController>().healthReduce(1);

                
                lastAttack = Time.time;

            }

            
        }else{

           anim.SetInteger("attack", 0);

        }
	      
        }


        //dead section

        if(isActiveDeadSection==true){

           isActiveDeadSection=false;

            dieSound.Play();
            anim.SetInteger("dead", 1);

            Destroy(gameObject,1f);
        }
          
 

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

   //  print(other.gameObject.tag);

       
     

           if(other.collider.gameObject.tag=="top" || other.collider.gameObject.tag=="toe"){

           }else if(other.gameObject.tag=="Player1"){

              if (Time.time > attackRate + lastAttack && isEnemyAlive)
              {

                anim.SetInteger("attack", 1);
            
                player.GetComponent<healthController>().healthReduce(1);

                
                lastAttack = Time.time;

             }

           }
          


     
       
    }


     
}
