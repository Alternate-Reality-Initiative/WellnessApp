using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int currentHealth;
    public const int maxHealth = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Player _player;
    public int[] plantHealths;
    public int plantIndex;
  
    public void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        plantHealths = _player.plantHealth;
        plantIndex = _player.selectedPlant;
        currentHealth = plantHealths[plantIndex];
        //currentHealth = 2; // testing
    }
      
    public void Update()
    {
        setHearts();
    }

    public void setHearts() {
        if (currentHealth == 0) {
            hearts[0].sprite = emptyHeart;
            hearts[1].sprite = emptyHeart;
            hearts[2].sprite = emptyHeart;
        }
        else if (currentHealth == 1) {
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = emptyHeart;
            hearts[2].sprite = emptyHeart;
        }
        else if (currentHealth == 2) {
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = fullHeart;
            hearts[2].sprite = emptyHeart;
        }
        else if (currentHealth == 3) {
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = fullHeart;
            hearts[2].sprite = fullHeart;
        }
    }

}

