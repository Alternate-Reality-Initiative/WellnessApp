using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;



public class days_passed : MonoBehaviour
{
    // private static System.DateTime startDate;
    DateTime today;
    // PlayerPrefs numDays; //needs to be saved 
    // public string numdays;
    DateTime prev;
    Player _player;
    public TextMeshProUGUI plant1;
    public TextMeshProUGUI plant2;
    public TextMeshProUGUI plant3;
    public TextMeshProUGUI plant4;
    public TextMeshProUGUI plant5;
    public TextMeshProUGUI plant6;
    public TextMeshProUGUI plant7;
    public TextMeshProUGUI plant8;
    public TextMeshProUGUI plant9;
    public TextMeshProUGUI plant10;


    //when app is launched for the first time, save the date 
    //to update days-passed, subtract current date from saved start date

    
    //keep track of active days when user uses the app
    //when app is opened, incremented number of days 
    
    

    void Awake()
    {
          _player = GameObject.Find("Player").GetComponent<Player>();

          today = System.DateTime.UtcNow.ToLocalTime();
          prev = DateTime.Parse(_player.previous); //change 
          Debug.Log("Prev in Days Passed" + prev.ToString());

         Debug.Log("Prev Add Days" + prev.AddDays(1).ToString());
         Debug.Log("today date " + today.Date.ToString());
         

          if (prev.Date.AddDays(1) != today.Date && prev.Date != today.Date) { //subtract health by the number of days missed or if didnt play in a while?
            // Debug.Log("prev.")
            if (_player.plantHealth[_player.selectedPlant] > 0) {
                _player.plantHealth[_player.selectedPlant] -= 1;
            }
            if (_player.selectedPlant == 0) {
              plant1.text =  _player.plantHealth[_player.selectedPlant].ToString();
            }
            else if (_player.selectedPlant == 1) {
              plant2.text =  _player.plantHealth[_player.selectedPlant].ToString();
            }
            else if (_player.selectedPlant == 2) {
               plant3.text =  _player.plantHealth[_player.selectedPlant].ToString();
            }
            else if (_player.selectedPlant == 3) {
               plant4.text =  _player.plantHealth[_player.selectedPlant].ToString();
            }
            else if (_player.selectedPlant == 4)  {
               plant5.text =  _player.plantHealth[_player.selectedPlant].ToString();
            }
            else if (_player.selectedPlant == 5) {
               plant6.text =  _player.plantHealth[_player.selectedPlant].ToString();
            }
            else if (_player.selectedPlant == 6) {
               plant7.text =  _player.plantHealth[_player.selectedPlant].ToString();
            }
            else if (_player.selectedPlant == 7) {
               plant8.text =  _player.plantHealth[_player.selectedPlant].ToString();
            }
            else if (_player.selectedPlant == 8) {
              plant9.text =  _player.plantHealth[_player.selectedPlant].ToString();
            }
            else if (_player.selectedPlant == 9) {
               plant10.text =  _player.plantHealth[_player.selectedPlant].ToString();
            }
          }
           Debug.Log( "Plant Health" + _player.plantHealth[_player.selectedPlant]);
           Debug.Log("Player Prev days_passed" + _player.previous);

        // SetStartDate(); //current start date is 2/19/2023 at 2:33 pm
        // numdays = GetDaysPassed();

        // Debug.Log(numdays); //prints the number of days
        // Debug.Log(startDate);

        //count active days
        
    }

    public void ResetHearts() {
      for (int i = 0; i < 10; i++) {
        _player.plantHealth[i]=3;
      }
      plant1.text = "3";
      plant2.text = "3";
      plant3.text = "3";
      plant4.text = "3";
      plant5.text = "3";
      plant6.text = "3";
      plant7.text = "3";
      plant8.text = "3";
      plant9.text = "3";
      plant10.text = "3";

    }
 
    // void SetStartDate()
    // { //use date not datetime
    //     if(PlayerPrefs.HasKey("DateInitialized")) //if we have the start date saved, we'll use that
    //         startDate = System.Convert.ToDateTime(PlayerPrefs.GetString("DateInitialized"));
    //     else //otherwise...
    //     {
    //         startDate = System.DateTime.Now ; //save the start date ->
    //         PlayerPrefs.SetString("DateInitialized", startDate.ToString()); 
    //     }
    // }
 
 
    // public static string GetDaysPassed()
    // {
    //     today = System.DateTime.Now;
    //     //days between today and start date -->
    //     System.TimeSpan elapsed = today.Subtract(startDate);
    //     int days = (int)elapsed.TotalDays;
    //     //print(days);
    //     return days.ToString();
    // }
   
}

//problems...
//making things last for 24 hours / 7 days 
// testing how many days have passed 