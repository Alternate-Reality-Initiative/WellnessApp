using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name;
    public int waterLevel = 1;

    public static Player Instance; 

    public void SavePlayer()
    {
        //name = InputFieldManager.saveName;
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        name = data.name;
        waterLevel = data.waterL++;
    }
}
