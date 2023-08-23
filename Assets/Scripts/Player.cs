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
    public int[] surplusWater;
    public bool[] unlockedPlants; //plant id numbers
    public string previous;
    public int numDaysSinceDownload;
    public int[] daysNotWatered;
    public bool newDay;

    [HideInInspector]
    public const int NUM_PLANTS = 10;
    [HideInInspector]
    public const int SPROUT_INDEX = 4;
    public const int WATER_REWARD_FOR_DAILY = 1;
    public const int WATER_REWARD_FOR_WEEKLY = 3;
    // public days_passed daysPassed;

    public void SavePlayer()
    {
        //name = InputFieldManager.saveName;
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        //Debug.Log("inside load player player script");
        PlayerData data = SaveSystem.LoadPlayer();

        // if(data == null){
        //     Debug.Log("data is null");
        // }
        // else{
        //     Debug.Log("data is fine");
        // }
       
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
        
        surplusWater = data.surplusWater;
        
        if (surplusWater.Length == 0) {
            surplusWater = new int[NUM_PLANTS];
            Array.Fill(surplusWater,0);
        }

        daysNotWatered = data.daysNotWatered;

        if (daysNotWatered.Length == 0) {
            daysNotWatered = new int[NUM_PLANTS];
            Array.Fill(daysNotWatered,0);
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
            previous =  System.DateTime.UtcNow.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");
        }

        newDay = data.newDay;
        if (newDay == null) {
            newDay = true;
        }
    }
}
