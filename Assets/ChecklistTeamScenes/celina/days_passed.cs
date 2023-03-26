using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class days_passed : MonoBehaviour
{
    private static System.DateTime startDate;
    private static System.DateTime today;
    // PlayerPrefs numDays; //needs to be saved 
    string numdays;

    //when app is launched for the first time, save the date 
    //to update days-passed, subtract current date from saved start date

    
    //keep track of active days when user uses the app
    //when app is opened, incremented number of days 
    
    

    void Awake()
    {
        SetStartDate(); //current start date is 2/19/2023 at 2:33 pm
        numdays = GetDaysPassed();
        // Debug.Log(numdays); //prints the number of days
        // Debug.Log(startDate);

        //count active days
        
    }
 
    void SetStartDate()
    { //use date not datetime
        if(PlayerPrefs.HasKey("DateInitialized")) //if we have the start date saved, we'll use that
            startDate = System.Convert.ToDateTime(PlayerPrefs.GetString("DateInitialized"));
        else //otherwise...
        {
            startDate = System.DateTime.Now ; //save the start date ->
            PlayerPrefs.SetString("DateInitialized", startDate.ToString()); 
        }
    }
 
 
    public static string GetDaysPassed()
    {
        today = System.DateTime.Now;
        //days between today and start date -->
        System.TimeSpan elapsed = today.Subtract(startDate);
        int days = (int)elapsed.TotalDays;
        //print(days);
        return days.ToString();
    }
   
}

//problems...
//making things last for 24 hours / 7 days 
// testing how many days have passed 