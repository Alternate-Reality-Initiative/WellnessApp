using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
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
    }
      
    public void Update()
    {
        setHearts();
    }

    public void setHearts() {
        if (plantHealths[plantIndex] == 0) {
            hearts[0].sprite = emptyHeart;
            hearts[1].sprite = emptyHeart;
            hearts[2].sprite = emptyHeart;
        }
        else if (plantHealths[plantIndex] == 1) {
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = emptyHeart;
            hearts[2].sprite = emptyHeart;
        }
        else if (plantHealths[plantIndex] == 2) {
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = fullHeart;
            hearts[2].sprite = emptyHeart;
        }
        else if (plantHealths[plantIndex] == 3) {
            hearts[0].sprite = fullHeart;
            hearts[1].sprite = fullHeart;
            hearts[2].sprite = fullHeart;
        }
    }

}

