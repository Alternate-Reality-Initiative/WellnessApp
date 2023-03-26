using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class elapsedtime : MonoBehaviour
{

    DateTime previous;
    DateTime today;
    public bool newDay;
    int numDays; //tracks number of active days app is used
    
    //edge case - playing game at midnight 
    //what if app is opened after 12am
    void Awake () {
        
        //most recent time the app was last closed
       
        previous = DateTime.Parse("03/11/2023"); //change 
        today = System.DateTime.Now;

        //compare a stored previous date to the current date
        //int result = DateTime.Compare(previous, today); if (result < 0) == previous < today {}

        // 1. date needs to be different 
        //even if not new day, should the previous DateTime still get updated
        if (previous.Date < today.Date) { 

            previous = System.DateTime.Now; //needs to be saved
        
            newDay = true;
            numDays++; //needs to be saved
            
        }
 
    }

}
