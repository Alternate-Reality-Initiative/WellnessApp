// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
<<<<<<< HEAD

// public class Health : Monobehaviour
// {
//     public int currentHealth;
//     const public int maxHealth = 3;
//     public Image[] heartImageDisplay; // array of heart images to display
//     public Sprite fullHeart;
//     public Sprite emptyHeart;
//     public DateTime lastDecreaseTime;
  
//     public void Start()
//     {
//         currentHealth = maxHealth;
//         lastDecreaseTime = DateTime.Now;
//     }
      
//     public void Update()
//     {
//         TimeSpan timeSinceLastDecrease = DateTime.Now - lastDecreaseTime;
//         if (timeSinceLastDecrease >= 24)  {
//             lastDecreaseTime = DateTime.Now;
//             if (currentHealth > 1)
//             {
//                 --currentHealth;
//                 UpdateHealthDisplay();
//             }
//            else
//             {
//                 return; // this is absolute BS for now
//                 // instead, DISPLAY EMPTY POT        
//             }
//         }
//     }
=======
// using System;
// using UnityEngine.UI;

// public class Health : MonoBehaviour
// {
//     public int currentHealth;
//     public const int maxHealth = 3;
//     public Sprite[] heartImageDisplay; // array of heart images to display
//     public Sprite fullHeart;
//     public Sprite emptyHeart;
//     public DateTime lastDecreaseTime;
//     public Player _player;
//     public int[] plantHealths;
//     public int plantIndex;

//     public Plant[] plants;
//     public GameObject emptyPot;

//     //public GameObject arManager;

//     //GameObject[] plants = Resources.LoadAll("PlantSO");
  
//     public void Start()
//     {
//         _player = GameObject.Find("Player").GetComponent<Player>();
//         plantHealths = _player.plantHealth;
//         plantIndex = _player.selectedPlant;
//         currentHealth = plantHealths[plantIndex];
//         plants = Resources.LoadAll("Plant SO") as Plant[];
//         //PlaceARObjectOnHand arComponent = arManager.GetComponent<PlaceARObjectOnHand>();

//         if (currentHealth == 0) {
//             heartImageDisplay[0] = emptyHeart;
//             heartImageDisplay[1] = emptyHeart;
//             heartImageDisplay[2] = emptyHeart;
//         }
//         else if (currentHealth == 1) {
//             heartImageDisplay[0] = fullHeart;
//             heartImageDisplay[1] = emptyHeart;
//             heartImageDisplay[2] = emptyHeart;
//         }
//         else if (currentHealth == 2) {
//             heartImageDisplay[0] = fullHeart;
//             heartImageDisplay[1] = fullHeart;
//             heartImageDisplay[2] = emptyHeart;
//         }
//         else if (currentHealth == 3) {
//             heartImageDisplay[0] = fullHeart;
//             heartImageDisplay[1] = fullHeart;
//             heartImageDisplay[2] = fullHeart;
//         }

//         // lastDecreaseTime = DateTime.Now;
//     }
      
//     // public void Update()
//     // {
//     //     TimeSpan timeSinceLastDecrease = DateTime.Now - lastDecreaseTime;
//     //     if (timeSinceLastDecrease >= 24)  {
//     //         lastDecreaseTime = DateTime.Now;
//     //         if (currentHealth > 0)
//     //         {
//     //             --currentHealth;
//     //             UpdateHealthDisplay();
//     //         }
//     //        else
//     //         {
//     //             //arComponent.ArObject = emptyPot;
//     //             return; // this is absolute BS for now
//     //             // instead, DISPLAY EMPTY POT        
//     //         }
//     //     }
//     // }
>>>>>>> cc14f64fb153a18c281f378165c666ab3f8964f7

    

//     public void UpdateHealthDisplay()
//     {
//         for (int i = 0; i < maxHealth; ++i) {
//             if (i < currentHealth)
//                 heartImageDisplay[i] = fullHeart;
//             else
//                 heartImageDisplay[i] = emptyHeart;
//         }
//     }
// }

