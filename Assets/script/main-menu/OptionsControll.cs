using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsControll : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject activeHand;
    public GameObject inActiveHand;
    public Toggle toggle;

     void Start()
    {
       ToggleOnChange(); 
       // toggle.isOn = true;
    }

    public void ToggleOnChange(){

         if(toggle.isOn){
          activeHand.SetActive(true);
          inActiveHand.SetActive(false);

         }else{

           activeHand.SetActive(false);
           inActiveHand.SetActive(true);
        }
    }
}
