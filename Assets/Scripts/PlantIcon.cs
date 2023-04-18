using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlantIcon : MonoBehaviour
{
    [SerializeField] private GameObject Sprout;
    [SerializeField] private GameObject Inwe;
    [SerializeField] private GameObject Arabella;
    [SerializeField] private GameObject BlockySakura;
    [SerializeField] private GameObject Guppers;
    [SerializeField] private GameObject Kirbs;
    [SerializeField] private GameObject Tootsie;
    [SerializeField] private GameObject VenusFly;
    [SerializeField] private GameObject Wellington;
    [SerializeField] private GameObject Sunflower;

    public Player _player;
    List<PlantScriptableObject> plantArr;
    public string plantName;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        plantArr = new List<PlantScriptableObject>();
        plantArr = Resources.LoadAll<PlantScriptableObject>("Plant SO").Cast<PlantScriptableObject>().ToList();
        plantName = plantArr[_player.selectedPlant].name;
        UpdateIcon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateIcon()
    {
        if (plantName == "Arabella")
        {
            Sprout.SetActive(false);
            Inwe.SetActive(false);
            Arabella.SetActive(true);
            BlockySakura.SetActive(false);
            Guppers.SetActive(false);
            Kirbs.SetActive(false);
            Tootsie.SetActive(false);
            VenusFly.SetActive(false);
            Wellington.SetActive(false);
            Sunflower.SetActive(false);
        }
        else if (plantName == "Blocky Sakura")
        {
            Sprout.SetActive(false);
            Inwe.SetActive(false);
            Arabella.SetActive(false);
            BlockySakura.SetActive(true);
            Guppers.SetActive(false);
            Kirbs.SetActive(false);
            Tootsie.SetActive(false);
            VenusFly.SetActive(false);
            Wellington.SetActive(false);
            Sunflower.SetActive(false);
        }
        else if (plantName == "Inwe")
        {
            Sprout.SetActive(false);
            Inwe.SetActive(true);
            Arabella.SetActive(false);
            BlockySakura.SetActive(false);
            Guppers.SetActive(false);
            Kirbs.SetActive(false);
            Tootsie.SetActive(false);
            VenusFly.SetActive(false);
            Wellington.SetActive(false);
            Sunflower.SetActive(false);
        }
        else if (plantName == "Kirbs")
        {
            Sprout.SetActive(false);
            Inwe.SetActive(false);
            Arabella.SetActive(false);
            BlockySakura.SetActive(false);
            Guppers.SetActive(false);
            Kirbs.SetActive(true);
            Tootsie.SetActive(false);
            VenusFly.SetActive(false);
            Wellington.SetActive(false);
            Sunflower.SetActive(false);
        }
        else if (plantName == "Sprout")
        {
            Sprout.SetActive(true);
            Inwe.SetActive(false);
            Arabella.SetActive(false);
            BlockySakura.SetActive(false);
            Guppers.SetActive(false);
            Kirbs.SetActive(false);
            Tootsie.SetActive(false);
            VenusFly.SetActive(false);
            Wellington.SetActive(false);
            Sunflower.SetActive(false);
        }
        else if (plantName == "Sunflower")
        {
            Sprout.SetActive(false);
            Inwe.SetActive(false);
            Arabella.SetActive(false);
            BlockySakura.SetActive(false);
            Guppers.SetActive(false);
            Kirbs.SetActive(false);
            Tootsie.SetActive(false);
            VenusFly.SetActive(false);
            Wellington.SetActive(false);
            Sunflower.SetActive(true);
        }
        else if (plantName == "Tootsie")
        {
            Sprout.SetActive(false);
            Inwe.SetActive(false);
            Arabella.SetActive(false);
            BlockySakura.SetActive(false);
            Guppers.SetActive(false);
            Kirbs.SetActive(false);
            Tootsie.SetActive(true);
            VenusFly.SetActive(false);
            Wellington.SetActive(false);
            Sunflower.SetActive(false);
        }
        else if (plantName == "Venus Fly Trap")
        {
            Sprout.SetActive(false);
            Inwe.SetActive(false);
            Arabella.SetActive(false);
            BlockySakura.SetActive(false);
            Guppers.SetActive(false);
            Kirbs.SetActive(false);
            Tootsie.SetActive(false);
            VenusFly.SetActive(true);
            Wellington.SetActive(false);
            Sunflower.SetActive(false);
        }
        else if (plantName == "Wellington")
        {
            Sprout.SetActive(false);
            Inwe.SetActive(false);
            Arabella.SetActive(false);
            BlockySakura.SetActive(false);
            Guppers.SetActive(false);
            Kirbs.SetActive(false);
            Tootsie.SetActive(false);
            VenusFly.SetActive(false);
            Wellington.SetActive(true);
            Sunflower.SetActive(false);
        }
        else if (plantName == "Guppers")
        {
            Sprout.SetActive(false);
            Inwe.SetActive(false);
            Arabella.SetActive(false);
            BlockySakura.SetActive(false);
            Guppers.SetActive(true);
            Kirbs.SetActive(false);
            Tootsie.SetActive(false);
            VenusFly.SetActive(false);
            Wellington.SetActive(false);
            Sunflower.SetActive(false);
        }
    }
}
