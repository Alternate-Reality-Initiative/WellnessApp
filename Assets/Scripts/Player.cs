using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name;
    public int waterLevel;
    public int[] tasks;
    public int[] completedTasks;
    public int selectedPlant;
    public int[] plantHealth;
    public bool[] unlockedPlants; //plant id numbers
    public string previous;
    // public days_passed daysPassed;

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
        
        tasks = data.tasks;
        if (tasks == null) {
            tasks = new int[0];
        }

        completedTasks = data.completedTasks;
        if (completedTasks == null) {
            completedTasks = new int[0];
        }

        selectedPlant= data.selectedPlant;
        
        plantHealth= data.plantHealth;
        if (plantHealth == null) {
            plantHealth = new int[0];
        }

        unlockedPlants= data.unlockedPlants;
        if (unlockedPlants == null) {
            unlockedPlants = new bool[0];
        }
        previous = data.previous;
        if (previous == null) {
            previous =  System.DateTime.UtcNow.ToLocalTime().ToString("M/dd");
        }
    }
}
