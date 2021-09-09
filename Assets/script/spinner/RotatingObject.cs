using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    // Start is called before the first frame update

    public float spiner_speed;
    public int moveDirection;

    public GameObject roatatingObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(moveDirection==1){

            roatatingObject.transform.Rotate(0,0, spiner_speed * Time.fixedDeltaTime*-1*5);

        }else{

            roatatingObject.transform.Rotate(0,0, spiner_speed * Time.deltaTime*1*5);
        }

            
        
    }
}
