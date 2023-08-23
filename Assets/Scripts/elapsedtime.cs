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
        Debug.Log("Player Prev Elapsed Time" + _player.previous);

        // try{
        //    prev = DateTime.ParseExact(_player.previous, "MM-dd-yyyy h:mm:ss tt", CultureInfo.InvariantCulture); 
        //    Debug.Log("inside try branch "+ prev);
        // }
        // catch(FormatException){
        //     Debug.Log("Unable to parse");
        // }


        //yyyy-MM-ddTHH:mm:ss.fffffffZ


        prev = DateTime.Parse(_player.previous);
        // DateTime parsedDateTime;
        // if (DateTime.TryParseExact(_player.previous, "yyyy-MM-ddTHH:mm:ss.fffffffZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDateTime)){
        //     // Parsing successful, 'parsedDateTime' contains the parsed value
        //     Debug.Log("Parsed DateTime: " + parsedDateTime);
        // }
        // else
        // {
        //     Debug.Log("Parsing failed");
        //     // Handle the parsing failure as needed
        // }
        // prev = parsedDateTime;
        
        today = System.DateTime.UtcNow.ToLocalTime();
        
        Debug.Log(today.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ"));
        //compare a stored previous date to the current date
        //int result = DateTime.Compare(previous, today); if (result < 0) == previous < today {}

        // 1. date needs to be different 
        //even if not new day, should the previous DateTime still get updated?
       TimeSpan timeDifference = today.Date - prev.Date;
        if (timeDifference.Days >= 1) { 
            // prev = System.DateTime.Now;
            // Debug.Log(prev.ToString());
            _player.previous = System.DateTime.UtcNow.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ"); 
            _player.newDay = true;
            // Debug.Log(prev);
            // Debug.Log(_player.previous);
        }
        else {
            _player.newDay = false;
        }


        //if 24hrs have passed and not have watered
        //checks for when app last opened 
        // when was the last time a plant was watered
        //case: where user opens app but forgets to water plant
        //TimeSpan hoursPassed = today - last time plant was watered;
        // if (hoursPassed >= 24 && _player.daysNotWatered[_player.selectedPlant] > 0){
        //     _player.plantHealth[_player.selectedPlant] -= _player.daysNotWatered[_player.selectedPlant];
        // }
        // else{
        //     Debug.Log("heart stays!!!!");
        // }


    }

}
