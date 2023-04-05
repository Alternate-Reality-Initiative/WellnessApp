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

    // Update is called once per frame
   
}
