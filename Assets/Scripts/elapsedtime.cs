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
    
    //edge case - playing game at midnight 
    //what if app is opened after 12am
    void Awake () {
        _player = GameObject.Find("Player").GetComponent<Player>();
        //most recent time the app was last closed
       
        Debug.Log("player.previoius is " + _player.previous);
        prev = DateTime.Parse(_player.previous); //change 
        Debug.Log("prev is " + prev);
        today = System.DateTime.Now;

        //compare a stored previous date to the current date
        //int result = DateTime.Compare(previous, today); if (result < 0) == previous < today {}

        // 1. date needs to be different 
        //even if not new day, should the previous DateTime still get updated
        if (prev.Date < today.Date) { 
            Debug.Log("it's a new day");

            prev = System.DateTime.Now; 
        
            newDay = true;
            
        }
 
    }

}
