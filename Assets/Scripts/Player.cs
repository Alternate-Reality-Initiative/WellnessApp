using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public string name = ReturnName();
    void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    // Update is called once per frame
    void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
    }
}
