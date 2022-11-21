using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static void SavePlayer (Player player){
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        formatter.Serialize(strem, data);
        stream.Close();
    }

    public static void LoadPlayer (Player player){

        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream strem = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else{
            Debug.LogError("File not found in " + path);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
