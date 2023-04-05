using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public int numDaysSinceDownload;

    private const int NUM_PLANTS = 10;
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
        numDaysSinceDownload = data.numDaysSinceDownload;
        
        tasks = data.tasks;
        if (tasks.Length == 0) {
            tasks = new int[NUM_PLANTS];
        }

        completedTasks = data.completedTasks;
        if (completedTasks.Length == 0) {
            completedTasks = new int[NUM_PLANTS];
        }

        selectedPlant = data.selectedPlant;
        
        plantHealth = data.plantHealth;
        
        if (plantHealth.Length == 0) {
            plantHealth = new int[NUM_PLANTS];
        }

        unlockedPlants = data.unlockedPlants;
        if (unlockedPlants.Length == 0) {
            unlockedPlants = new bool[NUM_PLANTS];
        }

        previous = data.previous;
        if (String.IsNullOrWhiteSpace(previous)) {
            previous =  System.DateTime.UtcNow.ToLocalTime().ToString("M/dd");
        }
    }
}
