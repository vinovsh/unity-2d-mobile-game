using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

   public GameObject background2;
   public GameObject background3;
   public GameObject background4;
   public GameObject background5;
   public GameObject background6;
   private Renderer rend2;
   private Renderer rend3;
   private Renderer rend4;
   private Renderer rend5;
   private Renderer rend6;
   public float scrollSpeed2=250f;
   public float scrollSpeed3=230f;

   public float scrollSpeed4=110f;
   public float scrollSpeed5=100f;
   public float scrollSpeed6=90f;
    // Start is called before the first frame update


    //top movement
    public float background4_top_movement=0f;
    public float background5_top_movement=301f;
    public float background6_top_movement=130f;
    void Start()
    {

        rend2 = background2.GetComponent<Renderer> ();
        rend3 = background3.GetComponent<Renderer> ();
        rend4 = background4.GetComponent<Renderer> ();
        rend5 = background5.GetComponent<Renderer> ();
        rend6 = background6.GetComponent<Renderer> ();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //background 2
        background2.transform.position= new Vector3(transform.position.x,transform.position.y,3.69f);//sprite follow the same camera x and y a position
        float offset2 = transform.position.x/scrollSpeed2;
        rend2.material.SetTextureOffset("_MainTex", new Vector2(offset2, 0)); //scroll the sprite material loop in realistic speed background
        
        //background 3
        background3.transform.position= new Vector3(transform.position.x,transform.position.y-6.4f,1.08f);//sprite follow the same camera x and y a position
        float offset3 = transform.position.x/scrollSpeed3;
        rend3.material.SetTextureOffset("_MainTex", new Vector2(offset3, 0)); //scroll the sprite material loop in realistic speed background
        
         //background 4
        background4.transform.position= new Vector3(transform.position.x,transform.position.y-7.05f,1.07f);//sprite follow the same camera x and y a position
        float offset4 = transform.position.x/scrollSpeed4;
        rend4.material.SetTextureOffset("_MainTex", new Vector2(offset4, 0)); //scroll the sprite material loop in realistic speed background
        

         //background 5
        background5.transform.position= new Vector3(transform.position.x,transform.position.y,1.06f);//sprite follow the same camera x and y a position
        float offset5 = transform.position.x/scrollSpeed5;  
        rend5.material.SetTextureOffset("_MainTex", new Vector2(offset5, transform.position.y/background5_top_movement)); //scroll the sprite material loop in realistic speed background
        

         //background 6
        background6.transform.position= new Vector3(transform.position.x,transform.position.y,1.05f);//sprite follow the same camera x and y a position
        float offset6 = transform.position.x/scrollSpeed6; 
        rend6.material.SetTextureOffset("_MainTex", new Vector2(offset6, transform.position.y/background6_top_movement)); //scroll the sprite material loop in realistic speed background
    }
}
