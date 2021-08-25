using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterWaveEffectCustom : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject waterWaveSprite;
    public string SortingLayer;

    public Vector2 wave_Tiling;
    public Vector2 wave_Offset;
    public float speed;

    public float wave_Top_offset=1.08f;//dont change
    public float wave_Top_offset_x=0f; //dont change

    
    AudioSource waterSound;
    MeshRenderer mR;

    Renderer waveRender;

    
    void Start()
    {
        mR=waterWaveSprite.GetComponent<MeshRenderer>();
        waveRender=waterWaveSprite.GetComponent<Renderer>();
        waterSound=gameObject.GetComponent<AudioSource>();

       

      

       
       
        
    }

    // Update is called once per frame
    void Update()
    {
       //water wave top offset

        waterWaveSprite.transform.position=new Vector3(wave_Top_offset_x*transform.localScale.x+transform.position.x,wave_Top_offset*transform.localScale.y+transform.position.y,0);
        waterWaveSprite.transform.localScale=new Vector3(transform.localScale.x,waterWaveSprite.transform.localScale.y,0);
 print(waterWaveSprite.transform.position);

        wave_Offset.x=wave_Offset.x+speed*Time.deltaTime; 
        mR.sortingLayerName = SortingLayer;
        waveRender.material.SetTextureOffset("_MainTex", new Vector2(wave_Offset.x, wave_Offset.y)); 
        waveRender.material.SetTextureScale("_MainTex",new Vector2(wave_Tiling.x,wave_Tiling.y));
       
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tag=other.gameObject.tag;
        if(tag=="Player"){

           other.gameObject.GetComponent<playerController>().isWater=true;
           other.gameObject.GetComponent<playerController>().isGround=true;

        }

        if(tag=="Player" || tag=="enemy" || tag=="platform"){

               waterSound.Play();
        }
      
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player"){

           other.gameObject.GetComponent<playerController>().isWater=false;
           other.gameObject.GetComponent<playerController>().isGround=false;

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        string tag=other.gameObject.tag;
        if(tag=="Player"){

           other.gameObject.GetComponent<playerController>().isWater=true;
           other.gameObject.GetComponent<playerController>().isGround=true;

        }
        
    }
}
