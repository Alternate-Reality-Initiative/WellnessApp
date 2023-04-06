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
    public int[] completedTasks;
    public int selectedPlant;
    public int[] plantHealth;
    public bool[] unlockedPlants;
    public string previous; 
    public int numDaysSinceDownload;
    
    public PlayerData (Player player){
        name = player.name;
        waterL = player.waterLevel;
        tasks = player.tasks;
        completedTasks = player.completedTasks;
        selectedPlant = player.selectedPlant;
        plantHealth = player.plantHealth;
        unlockedPlants = player.unlockedPlants;
        previous = player.previous;
        numDaysSinceDownload = player.numDaysSinceDownload;
    }
    
    public PlayerData() { // DEFAULT CONSTRUCTOR
        name = "";
        waterL = 10;
        tasks = new int[30]; //just picked a random size idk
        completedTasks = new int[30];
        selectedPlant = Player.SPROUT_INDEX;
        plantHealth = new int[Player.NUM_PLANTS];
        for (int i = 0; i < Player.NUM_PLANTS; i++) {
            plantHealth[i] = 3;
        }
        unlockedPlants = new bool[Player.NUM_PLANTS];
        for (int i = 0; i < Player.NUM_PLANTS; i++) {
            unlockedPlants[i] = false;
        }
        unlockedPlants[Player.SPROUT_INDEX] = true;
        previous = System.DateTime.UtcNow.ToLocalTime().ToString("M/dd");
        numDaysSinceDownload = 0;
    }

    // Update is called once per frame
   
}
