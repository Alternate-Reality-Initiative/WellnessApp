using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : Monobehaviour
{
    public int currentHealth;
    public const int maxHealth = 3;
    public Image[] heartImageDisplay; // array of heart images to display
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public DateTime lastDecreaseTime;
  
    public void Start()
    {
        currentHealth = maxHealth;
        lastDecreaseTime = DateTime.Now;
    }
      
    public void Update()
    {
        TimeSpan timeSinceLastDecrease = DateTime.Now - lastDecreaseTime;
        if (timeSinceLastDecrease >= 24)  {
            lastDecreaseTime = DateTime.Now;
            if (currentHealth > 1)
            {
                --currentHealth;
                UpdateHealthDisplay();
            }
           else
            {
                return; // this is absolute BS for now
                // instead, DISPLAY EMPTY POT        
            }
        }
    }


    public void UpdateHealthDisplay()
    {
        for (int i = 0; i < maxHealth; ++i) {
            if (i < currentHealth)
                heartImageDisplay[i] = fullHeart;
            else
                heartImageDisplay[i] = emptyHeart;
        }
    }
}

