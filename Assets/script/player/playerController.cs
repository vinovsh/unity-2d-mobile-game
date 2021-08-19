using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;

    public float jumpspeed;

    public Rigidbody2D rb;
    public Animator anim;

    public bool isGround=true;

    public bool canLeftMove=false;
    public bool canRightMove=false;
    public bool canJump=false;

    public float friction;

    public AudioSource runSound;
    
    
    void Awake()
    {

        rb=GetComponent<Rigidbody2D>();
        anim = anim.GetComponent<Animator>();


        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        float inputX=Input.GetAxis("Horizontal");
        float inputY=Input.GetAxis("Vertical");

       
 //rb.velocity = rb.velocity * friction; // custom friction 

      

       if (Input.GetKey(KeyCode.RightArrow) || canRightMove)
        {
           transform.eulerAngles=new Vector2(0,0);
       
           transform.position+=new Vector3(1,0,0)*Time.fixedDeltaTime*speed;
          
           // rb.AddForce(Vector2.right*speed);

           //rb.MovePosition(new Vector2(transform.position.x+1 * speed * Time.deltaTime,transform.position.y));
           
            anim.SetInteger("jump", 0);
            anim.SetInteger("idle", 0);
            anim.SetInteger("walk", 1);

            if (!runSound.isPlaying && isGround==true)
            {

             runSound.Play();

            }

           
          
            
        }else if(Input.GetKey(KeyCode.LeftArrow) || canLeftMove){
          
          transform.eulerAngles=new Vector3(0,180,0);
         
          transform.position+=new Vector3(-1,0,0)*Time.fixedDeltaTime*speed;
          //rb.AddForce(Vector2.left*speed);
         // rb.MovePosition(new Vector2(transform.position.x-1 * speed * Time.deltaTime,transform.position.y));
         
          anim.SetInteger("jump", 0);
          anim.SetInteger("idle", 0);
          
          anim.SetInteger("walk", 1);

          if (!runSound.isPlaying  && isGround==true)
          {

             runSound.Play();

          }
            

        }else{

             anim.SetInteger("walk", 0);
              anim.SetInteger("jump", 0);
             

            anim.SetInteger("idle", 1);
          
          


        }

         if (Input.GetKey(KeyCode.Space) || canJump)
        {

            if(isGround==true){

              
               rb.velocity=Vector2.up*jumpspeed;
               // rb.AddForce(Vector2.up*jumpspeed,ForceMode2D.Impulse);
                anim.SetInteger("idle", 0);
                anim.SetInteger("walk", 0);
                anim.SetInteger("jump", 1);
             

            }
           
           
            
        }

       
       // groundCheck();

        
    }

  public void leftMoveHold(){

      canLeftMove=true;


  }

  public void leftMoveRelese(){

       canLeftMove=false;

  }

   public void rightMoveHold(){

      canRightMove=true;


  }

  public void rightMoveRelese(){

       canRightMove=false;

  }

   public void jumpHold(){

      canJump=true;


  }

  public void jumpRelese(){

       canJump=false;

  }



        
   
}
