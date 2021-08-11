using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxController : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 lastposition;

 

    AudioSource box_drag_sound;
    void Start()
    {

        lastposition=transform.position;
       box_drag_sound= gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position != lastposition){

            lastposition=transform.position;

        if (!box_drag_sound.isPlaying)
        {

             box_drag_sound.Play();

        }

           

           // print("its moving");
        }else{

            // print("its not moving");
             box_drag_sound.Stop();
        }
        
    }
}
