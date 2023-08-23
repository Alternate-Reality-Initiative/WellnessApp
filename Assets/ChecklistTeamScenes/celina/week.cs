using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Globalization;


public class week : MonoBehaviour
{   
    
    DateTime date = System.DateTime.UtcNow.ToLocalTime();
    Calendar day;
    DayOfWeek val;
    public bool newWeek;

    //detects new week that starts Sunday
    void Start(){
        //mesh_renderer = gameObject.GetComponent<MeshRenderer>();

        day = CultureInfo.InvariantCulture.Calendar;

        DayOfWeek dayOfWeek = date.DayOfWeek;

        // Convert the enumeration value to a string
        string dayOfWeekString = dayOfWeek.ToString();

        Debug.Log("Day of the week: " + dayOfWeekString);
        
        //start of with monday and then later we can go by user's choice ?
        if (dayOfWeek == DayOfWeek.Monday) {
            newWeek = true; 
        }


        

    }
}
