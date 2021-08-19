using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class playerData{
    // Start is called before the first frame update
  
    public int coin;
    public string player_name;

    public playerData(healthController health){

       coin=health.totalCoin;
       player_name="vinoth";
    }

}
