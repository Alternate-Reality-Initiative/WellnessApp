using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    // Start is called before the first frame update
    public string name;
    public int waterL;
    public int[] tasks;
    public int[] weeklyTasks;
    public bool[] completedDailyTasks;
    public bool[] completedWeeklyTasks;
    public int selectedPlant;
    public int[] plantHealth;
    public int[] surplusWater;
    public bool[] unlockedPlants;
    public string previous; 
    public int numDaysSinceDownload;
    public int[] daysNotWatered;
    public bool newDay;
    
    public PlayerData (Player player){
        name = player.name;
        waterL = player.waterLevel;
        tasks = player.tasks;
        weeklyTasks = player.weeklyTasks;
        completedDailyTasks = player.completedDailyTasks;
        completedWeeklyTasks = player.completedWeeklyTasks;
        selectedPlant = player.selectedPlant;
        plantHealth = player.plantHealth;
        surplusWater = player.surplusWater;
        unlockedPlants = player.unlockedPlants;
        previous = player.previous;
        numDaysSinceDownload = player.numDaysSinceDownload;
        daysNotWatered = player.daysNotWatered;
        newDay = player.newDay;
    }
    
    public PlayerData() { // DEFAULT CONSTRUCTOR
        name = "";
        waterL = 10;
        tasks = new int[30]; //just picked a random size idk
        weeklyTasks = new int[30];
        completedDailyTasks = new bool[30];
        completedWeeklyTasks = new bool[30];
        selectedPlant = Player.SPROUT_INDEX;
        plantHealth = new int[Player.NUM_PLANTS];
        newDay = true;
        for (int i = 0; i < Player.NUM_PLANTS; i++) {
            plantHealth[i] = 3;
        }
        surplusWater = new int[Player.NUM_PLANTS];
        for (int i = 0; i < Player.NUM_PLANTS; i++) {
            surplusWater[i] = 0;
        }
        unlockedPlants = new bool[Player.NUM_PLANTS];
        for (int i = 0; i < Player.NUM_PLANTS; i++) {
            unlockedPlants[i] = false;
        }
        unlockedPlants[Player.SPROUT_INDEX] = true;
        previous = System.DateTime.UtcNow.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");
        numDaysSinceDownload = 0;

        daysNotWatered = new int[Player.NUM_PLANTS];
        for (int i = 0; i < Player.NUM_PLANTS; i++) {
            daysNotWatered[i] = 0;
        }
    }

    // Update is called once per frame
   
}
