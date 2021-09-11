using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlateController : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anim;
    public float force;
    Rigidbody2D rb;

    AudioSource audios;
    void Start()
    {

        anim=GetComponent<Animator>();
        audios=GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
   private void OnCollisionEnter2D(Collision2D other)
   {
      
       rb=other.gameObject.GetComponent<Rigidbody2D>();
       rb.velocity=Vector2.up*force;
       anim.SetInteger("bounce", 1);
       audios.Play();
      
   }

   private void OnCollisionExit2D(Collision2D other)
   {
        anim.SetInteger("bounce", 0);
       
   }
}
