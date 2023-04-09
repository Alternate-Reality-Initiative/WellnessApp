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
    public bool newDay;
 
    void Start () {
        _player = GameObject.Find("Player").GetComponent<Player>();
        //most recent time the app was last closed
        Debug.Log("Player Prev Elapsed Time" + _player.previous);

        // try{
        //    prev = DateTime.ParseExact(_player.previous, "MM-dd-yyyy h:mm:ss tt", CultureInfo.InvariantCulture); 
        //    Debug.Log("inside try branch "+ prev);
        // }
        // catch(FormatException){
        //     Debug.Log("Unable to parse");
        // }

        prev = DateTime.Parse(_player.previous);
        
        today = System.DateTime.UtcNow.ToLocalTime();
        // Debug.Log(today.ToString());
        //compare a stored previous date to the current date
        //int result = DateTime.Compare(previous, today); if (result < 0) == previous < today {}

        // 1. date needs to be different 
        //even if not new day, should the previous DateTime still get updated
        if (prev.Date < today.Date) { 
            // prev = System.DateTime.Now;
            // Debug.Log(""prev.ToString());
            _player.previous = System.DateTime.UtcNow.ToLocalTime().ToString(); 
            newDay = true;
            // Debug.Log(prev);
            // Debug.Log(_player.previous);
        }
 
    }

}
