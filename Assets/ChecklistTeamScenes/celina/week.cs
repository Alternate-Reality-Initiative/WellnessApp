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
        val = day.GetDayOfWeek(date);
        

        if (val == DayOfWeek.Monday) {
            newWeek = true; 
                 
        }


        

    }
}
