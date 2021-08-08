using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthController : MonoBehaviour
{
    // Start is called before the first frame update

    public int maxHealth=3;
    public int currentHealth=3;

    public Image[] heart;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int totalCoin;
    public Text coinTextCounter;

    private float preventAttackTime;
    public float preventAttackRate;
   
    // Update is called once per frame

    public GameObject sprite_player_object;
    void Update()
    {

        if(currentHealth > maxHealth){

            currentHealth=maxHealth;
        }

         if(currentHealth < 0){

            currentHealth=0;
        }


      
        for(int i=0;i<heart.Length;i++){

            if(i<maxHealth){

              heart[i].enabled=true;

              if(i<currentHealth){

                heart[i].sprite=fullHeart;

              }else{

               heart[i].sprite=emptyHeart; 
              }

            }else{
               heart[i].enabled=false;  
            }
        }

        //coin section

        coinTextCounter.text=totalCoin.ToString();




        
    }

     public void healthIncrease(int medipack){
        
        currentHealth+=medipack;
    }

    public void healthReduce(int damage){
       if (Time.time >preventAttackTime){
         currentHealth-=damage;

           preventAttackTime = Time.time+preventAttackRate;

        }

        
    }



    public void CoinAdd(int coin){
        
        totalCoin+=coin;
        coinTextCounter.text=totalCoin.ToString();
    }

    public void CoinMinus(int coin){
        
        totalCoin-=coin;
        coinTextCounter.text=totalCoin.ToString();
    }
}
