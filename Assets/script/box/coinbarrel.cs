using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class coinbarrel : MonoBehaviour
{
    // Start is called before the first frame update

    private ParticleSystem particle;
    public GameObject sprite;

    private Rigidbody2D rb;

    private BoxCollider2D bc;
    private CapsuleCollider2D cc;

    public AudioSource coinSound;

    public GameObject coin;

    private GameObject coinInstantiate;

    public Rigidbody2D coinInstantiaterb;
    public CircleCollider2D coinInstantiatecc;

    public GameObject player;
    void Start()
    {

        particle =GetComponentInChildren<ParticleSystem>();
        rb=GetComponent<Rigidbody2D>();
        bc=GetComponent<BoxCollider2D>();
        cc=GetComponent<CapsuleCollider2D>();
        player=GameObject.FindWithTag("Player");
       // coinSound=GetComponent<AudioSource>();
       
        
    }

 

 private void OnCollisionEnter2D(Collision2D other)
 {
    string tag=other.collider.gameObject.tag;
    if(tag=="toe"){
      other.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.up*7;
      
      StartCoroutine(breakBox());
       player.GetComponent<playerController>().isGround=false;
    }
 }

 private IEnumerator breakBox(){

     particle.Play();
     coinSound.Play();
     rb.gravityScale=0f;
     cc.enabled=false;
     bc.enabled=false;
     Destroy(sprite);
      player.GetComponent<playerController>().isGround=false;

     int i;

     for(i=0; i<=3;i++){

      
      
       
       coinInstantiate=Instantiate(coin);
       coinInstantiate.transform.position=sprite.transform.position;
       coinInstantiatecc=coinInstantiate.GetComponent<CircleCollider2D>();
       coinInstantiatecc.isTrigger=false;
       coinInstantiaterb=coinInstantiate.GetComponent<Rigidbody2D>();
       //coinInstantiaterb.collisionDetectionMode=CollisionDetectionMode2D.Continuous;
       coinInstantiaterb.gravityScale=1f;
       coinInstantiaterb.velocity=Vector2.right*i;
         
     }
     
    

     yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
    
     Destroy(gameObject);

     
 }
 
}
