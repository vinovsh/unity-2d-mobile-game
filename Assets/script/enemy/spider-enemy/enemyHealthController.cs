using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthController : MonoBehaviour
{
    // Start is called before the first frame update

    //private int max_health=2;
    public int maxHealth;
    public int currentHealth;

    public Animator anim;

    GameObject player;

           
    public bool isEnemyAlive= true;
   
    void Start()
    {

       anim = anim.GetComponent<Animator>();
       player = GameObject.FindWithTag("Player");
        
    }

     void Update()
    {

       //Physics2D.IgnoreLayerCollision(3,6);   
        
    }

     public void healthReduce(int damage){
     
         currentHealth-=damage;

         if(currentHealth >0){

         }else{

           
            isEnemyAlive=false;
            anim.SetInteger("dead", 1);

            Destroy(gameObject,1f);
         }

        
    }

    void OnCollisionEnter2D(Collision2D coll) {
    
   
    if(coll.gameObject.tag=="enemy"){

         Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(),GetComponent<Collider2D>());
     }

      if(coll.collider.gameObject.tag=="toe"){ //coll.gameObject.tag=="Player"
     
           Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(),GetComponent<Collider2D>());
           Physics2D.IgnoreCollision(coll.collider.gameObject.GetComponent<Collider2D>(),GetComponent<Collider2D>());
      }

     
        
    }

}
