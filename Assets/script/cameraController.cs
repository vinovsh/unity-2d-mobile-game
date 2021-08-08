using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;

    public float smoothFactor;
    public Vector3 offset;
    public float offset2;
    void Start()
    {
      
       player = GameObject.FindWithTag("Player");
      //Destroy(player1);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

    Vector3 targetPosition=player.transform.position+offset;

      Vector3 smoothPosition=Vector3.Lerp(transform.position,targetPosition,smoothFactor*Time.fixedDeltaTime);

 //transform.position=new Vector3(player.transform.position.x,player.transform.position.y+offset2,transform.position.z);
  transform.position=smoothPosition;
     
        
    }
}
