using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name;
    public int waterLevel;
    public int[] tasks;
    public int selectedPlant;
    public int[] plantHealth;
    public bool[] unlockedPlants;

    public void SavePlayer()
    {
        //name = InputFieldManager.saveName;
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        name = data.name;
        waterLevel = data.waterL;
        tasks = data.arr;
        if (tasks == null) {
            tasks = new int[0];
        }

        selectedPlant= data.selectedPlant;
        plantHealth= data.plantHealth;
        unlockedPlants= data.unlockedPlants;
    }
}
