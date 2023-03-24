using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public Player _player;

    void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        string path = Path.Combine(Application.persistentDataPath, "player.wow");
        if (File.Exists(path))
        {
            _player.LoadPlayer();
            //Debug.Log(_player.waterLevel);
            //name.text = player.name;
            //water.text = player.waterLevel.ToString();
        }

    }

}