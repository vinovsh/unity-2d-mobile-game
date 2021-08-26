using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterButtonController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject red;
    public GameObject green;

    public GameObject water;

    public string whatIDo;  //increase ,reduce,static

    public float waterLevelCordinate;

    public bool isButtonActive=false;

    public bool isOperationDone=false;

    public  float speed;

    public bool operationFinishStatus=false;
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {

        if(isOperationDone==false && isButtonActive==true && operationFinishStatus==false){


            if(whatIDo=="increase"){

                if(waterLevelCordinate >water.GetComponent<waterWaveEffectCustom>().waterLevel){

                   water.GetComponent<waterWaveEffectCustom>().waterLevel+=speed*Time.deltaTime;
                }else{

                   operationFinishStatus=true;
                }   
               

            }else if(whatIDo=="reduce"){

               if(waterLevelCordinate <water.GetComponent<waterWaveEffectCustom>().waterLevel){ 

                  water.GetComponent<waterWaveEffectCustom>().waterLevel-=speed*Time.deltaTime;

               }else{

                   operationFinishStatus=true;
               }

            }else{

                //nothing to do
                operationFinishStatus=true;
            }


        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        string tag=other.gameObject.tag;
        if(tag=="Player"){

            isButtonActive=true;
            red.SetActive(false);
            green.SetActive(true);
            isButtonActive=true;
        }
        
    }
}
