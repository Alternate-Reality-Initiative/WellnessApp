using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Player player;
    private waterText waterText;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        waterText = GameObject.Find("waterText").GetComponent<waterText>();
    }

    public void SaveCompletedTask(int index){
        player.completedDailyTasks[index] = true;
        player.waterLevel += Player.WATER_REWARD_FOR_DAILY;
        waterText.UpdateWaterText();
    }

    public void SaveCompletedWeeklyTask(int index){
        player.completedWeeklyTasks[index] = true;
        player.waterLevel += Player.WATER_REWARD_FOR_WEEKLY;
        waterText.UpdateWaterText();
    }

}
