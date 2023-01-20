using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : InputFieldManager
{
    public string name;
    void SavePlayer()
    {
        name = InputFieldManager.saveName;
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
    }
}
