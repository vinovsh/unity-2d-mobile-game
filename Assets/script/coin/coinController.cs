using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    // Start is called before the first frame update

   
    public  GameObject coinBlast;
    
    GameObject player;

    public GameObject coinSound;
    
    void Start()
    {
       player = GameObject.FindWithTag("Player"); 
      
    }

   void OnTriggerEnter2D(Collider2D col)
    {
    
      if(col.gameObject.tag=="Player"){

        

        player.GetComponent<healthController>().CoinAdd(1);
        

        GameObject copyBlastCoin=Instantiate(coinBlast,gameObject.transform.position,gameObject.transform.rotation);

        GameObject copyCoinSound=Instantiate(coinSound,gameObject.transform.position,gameObject.transform.rotation);
        copyCoinSound.GetComponent<AudioSource>().Play(); 
        Destroy(copyBlastCoin,0.5f);
        Destroy(copyCoinSound,0.8f);
        Destroy(this.gameObject);

       

      }
      
        
      
   
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

       if(col.gameObject.tag=="Player"){

        

        player.GetComponent<healthController>().CoinAdd(1);
        

        GameObject copyBlastCoin=Instantiate(coinBlast,gameObject.transform.position,gameObject.transform.rotation);

        GameObject copyCoinSound=Instantiate(coinSound,gameObject.transform.position,gameObject.transform.rotation);
        copyCoinSound.GetComponent<AudioSource>().Play(); 
        Destroy(copyBlastCoin,0.5f);
        Destroy(copyCoinSound,0.8f);
        Destroy(this.gameObject);

       

      }

      if(col.gameObject.tag=="Player" || col.gameObject.tag=="enemy"){

         Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(),GetComponent<Collider2D>());
      }

        
      
    }
}
