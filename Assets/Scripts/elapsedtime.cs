using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class elapsedtime : MonoBehaviour
{

    DateTime prev; //needs to be saved
    Player _player;
    DateTime today;
    public bool newDay;
    public int numDays = 0; //tracks number of active days app is used
    
    //edge case - playing game at midnight 
    //what if app is opened after 12am
    void Awake () {
        _player = GameObject.Find("Player").GetComponent<Player>();
        //most recent time the app was last closed
       
        prev = DateTime.Parse(_player.previous); //change 
        today = System.DateTime.Now;

        //compare a stored previous date to the current date
        //int result = DateTime.Compare(previous, today); if (result < 0) == previous < today {}

        // 1. date needs to be different 
        //even if not new day, should the previous DateTime still get updated
        if (prev.Date < today.Date) { 

            prev = System.DateTime.Now; 
        
            newDay = true;
            // numDays++; //needs to be saved
            
        }
 
    }

}
