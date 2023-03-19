using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantObject", menuName = "ScriptableObjects/Plant")]
public class Plant : ScriptableObject
{
    public string name;
    public string desc;
    public GameObject plantObject;
    public Sprite plantSprite;
}