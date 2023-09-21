using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;

public class elapsedtime : MonoBehaviour
{

    DateTime prev; 
    Player _player;
    DateTime today;

 
    void Start () {
        _player = GameObject.Find("Player").GetComponent<Player>();
      
        
        //most recent time the app was last closed
        // Debug.Log("Player Prev Elapsed Time" + _player.previous);
        prev = DateTime.Parse(_player.previous);
        today = System.DateTime.UtcNow.ToLocalTime();
        // Debug.Log(today.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ"));
        
        //int result = DateTime.Compare(previous, today); if (result < 0) == previous < today {}

        // 1. date needs to be different 
        //even if not new day, should the previous DateTime still get updated?
       TimeSpan timeDifference = today.Date - prev.Date;
        if (timeDifference.Days >= 1) { 
            _player.previous = System.DateTime.UtcNow.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ"); 
            _player.newDay = true;
        }
        else {
            _player.newDay = false;
        }
        //save the date of when the watered 
        // checkDaysPassed();


    }

    // public void checkDaysPassed() {
    //     if (_player.lastWatered[_player.selectedPlant] != "") {
    //       TimeSpan daysPassed = today.Date - (DateTime.Parse(_player.lastWatered[_player.selectedPlant])).Date;
    //      if (daysPassed.Days >= 1){
    //         _player.daysNotWatered[_player.selectedPlant] = daysPassed.Days;
    //         if (_player.daysNotWatered[_player.selectedPlant] >= 3){
    //             _player.plantHealth[_player.selectedPlant] = 0;
    //         }
    //         else {
    //             _player.plantHealth[_player.selectedPlant] -= _player.daysNotWatered[_player.selectedPlant]; 
    //         }
    //     }
    //     }
        
    // }

}
