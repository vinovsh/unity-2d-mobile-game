using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject point1;
    public GameObject point2;

    public GameObject spinner;

    public string moveDirection; //top or bottom

    public float speed;


    private Vector3 nextPos;

    

    void Start()
    {

       GetComponent<AudioSource>().Play();   

        if(moveDirection=="top"){

            nextPos=point1.transform.position;
         

        }else{

            nextPos=point2.transform.position;
          


        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if(point1.transform.position.y <=spinner.transform.position.y){
           
           nextPos=point2.transform.position;
      

        }else if(point2.transform.position.y >= spinner.transform.position.y){

            nextPos=point1.transform.position;
           
        }

        //spinner.transform.position=new Vector3(spinner.transform.position.x,speed*Time.deltaTime*dir,spinner.transform.position.z);
        spinner.transform.position = Vector3.MoveTowards(spinner.transform.position,new Vector3(spinner.transform.position.x,nextPos.y,spinner.transform.position.z), speed * Time.deltaTime);  
    }


   
}
