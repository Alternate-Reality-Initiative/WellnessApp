using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantObject", menuName = "ScriptableObjects/Plant")]
public class PlantScriptableObject : ScriptableObject
{
    public string name;
    public string desc;
    public GameObject plantObject;
    public Sprite plantSprite;
}