using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveSystem{
    

    public static void savePlayer(healthController health){

        BinaryFormatter formatter=new BinaryFormatter();
        string path=Application.persistentDataPath+"/playerData.fun";
        FileStream stream=new FileStream(path,FileMode.Create);
        playerData data=new playerData(health);
        formatter.Serialize(stream,data);
        stream.Close();
    }

    public static playerData loadPlayer(){

        string path=Application.persistentDataPath+"/playerData.fun";
        if(File.Exists(path)){

            BinaryFormatter formatter=new BinaryFormatter();
            FileStream stream =new FileStream(path,FileMode.Open);
            playerData data=formatter.Deserialize(stream)as playerData;
            stream.Close();
            return data;
        }else{

          //  Debug.LogError("save file not found in"+path);
            return null;
        }
    } 

}
