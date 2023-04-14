using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public string name;
    public int waterLevel;
    public int[] tasks;
    public int[] weeklyTasks;
    public bool[] completedDailyTasks;
    public bool[] completedWeeklyTasks;
    public int selectedPlant;
    public int[] plantHealth;
    public bool[] unlockedPlants; //plant id numbers
    public string previous;
    public int numDaysSinceDownload;

    [HideInInspector]
    public const int NUM_PLANTS = 10;
    [HideInInspector]
    public const int SPROUT_INDEX = 4;
    public const int WATER_REWARD_FOR_DAILY = 3;
    public const int WATER_REWARD_FOR_WEEKLY = 5;
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

        completedDailyTasks = data.completedDailyTasks;
        if (completedDailyTasks.Length == 0) {
            completedDailyTasks = new bool[NUM_PLANTS];
        }

        weeklyTasks = data.weeklyTasks;
        if (weeklyTasks.Length == 0) {
            weeklyTasks = new int[NUM_PLANTS];
        }

        completedWeeklyTasks = data.completedWeeklyTasks;
        if (completedWeeklyTasks.Length == 0) {
            completedWeeklyTasks = new bool[NUM_PLANTS];
        }

        selectedPlant = data.selectedPlant;
        
        plantHealth = data.plantHealth;
        
        if (plantHealth.Length == 0) {
            plantHealth = new int[NUM_PLANTS];
            Array.Fill(plantHealth,3);
        }
        int healthSum = 0;
        for (int i = 0; i < NUM_PLANTS; i++) {
            healthSum += plantHealth[i];
        }

        if(healthSum == 0){
            for(int i = 0; i < NUM_PLANTS; i++){
                plantHealth[i] = 3;
            }
        }


        unlockedPlants = data.unlockedPlants;

        previous = data.previous;
        if (previous == "") {
            previous =  System.DateTime.UtcNow.ToLocalTime().ToString();
        }
    }
}
