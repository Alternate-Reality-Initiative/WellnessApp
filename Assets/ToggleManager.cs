using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void SaveCompletedTask(int index){
        //player.completedDailyTasks.Add(index);
        Debug.Log(index);
        player.completedDailyTasks[index] = true;
    }

    public void SaveCompletedWeeklyTask(int index){
        //player.completedDailyTasks.Add(index);
        Debug.Log(index);
        player.completedWeeklyTasks[index] = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
