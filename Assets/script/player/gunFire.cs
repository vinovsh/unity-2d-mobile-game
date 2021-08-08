using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunFire : MonoBehaviour
{
    // Start is called before the first frame update
public GameObject bulletprefab;
public GameObject fireSpark;
public Transform firepoint;

private bool canFire=false;

public float bulletForce=10f;

//AudioSource fireSparkSound;

public float fireRate = 0.3f;
 private float lastShot = 0.0f;
    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(1) || canFire){

            if (Time.time > fireRate + lastShot)
            {

               fireBullet();
               lastShot = Time.time;

            }
        }
        
    }

    public void fireBullet(){

       // yield return new WaitForSeconds(0.5f);

        GameObject bullet=Instantiate(bulletprefab,firepoint.position,firepoint.rotation);
        GameObject fireSparkClone=Instantiate(fireSpark,firepoint.position,firepoint.rotation);
        Rigidbody2D rb=bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.right*bulletForce,ForceMode2D.Impulse);


        //fireSparkSound=GetComponent<AudioSource>();

        //fireSparkSound.Play();

       

         Destroy(bullet,3f);
         Destroy(fireSparkClone,0.05f);
    
    }

    public void  canFireButtonHold(){
        canFire=true;

        
    }

    public void canFireButtonRelese(){ 

        canFire=false;
    }
}
