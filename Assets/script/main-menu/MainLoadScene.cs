using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoadScene : MonoBehaviour
{
    // Start is called before the first frame update


    public string sceneName;
    public GameObject Transition;

    public Animator loading;
    public string  loading_pos;
    void Start()
    {

       if(loading_pos=="end"){

           StartCoroutine(endAnim()); 
       }
       
    }
public void startButton(){

   StartCoroutine(LoadScene());
}

public void quitButton(){

     Application.Quit();
}

IEnumerator LoadScene(){

    

       Transition.SetActive(true);
       loading.SetInteger("start",1);
       yield return new WaitForSeconds(1.5f);
       SceneManager.LoadScene(sceneName);
  

 
}

IEnumerator endAnim(){

    

       Transition.SetActive(true);
       loading.SetInteger("end",1);
       yield return new WaitForSeconds(1.5f);
       Transition.SetActive(false);
  

 
}

}
