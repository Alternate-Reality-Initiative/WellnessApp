using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    // Start is called before the first frame update
    public static void SavePlayer (Player player){
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Path.Combine(Application.persistentDataPath, "player.wow");
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);
        Debug.Log(path);
        PlayerData data = new PlayerData(player);
        

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer (){

        string path = Path.Combine(Application.persistentDataPath, "player.wow");
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //Debug.Log(data.waterL);
            stream.Close();

            return data;
        }
        else{
            Debug.LogError("File not found in " + path);
            return null;
        }
        
    }

    // Update is called once per frame
}
