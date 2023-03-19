using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    // Start is called before the first frame update
    public string name;
    public int waterL;
    public int[] arr;
    
    public PlayerData (Player player){
        name = player.name;
        waterL = player.waterLevel;
        arr = player.arr;
    }

    // Update is called once per frame
   
}
