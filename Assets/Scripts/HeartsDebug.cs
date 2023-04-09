using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsDebug : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int[] plantHealths;
    [SerializeField] private int plantIndex;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        plantHealths = _player.plantHealth;
        plantIndex = _player.selectedPlant;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HeartsIncrement()
    {
        if (plantHealths[plantIndex] < 3) plantHealths[plantIndex]++;
    }

    public void HeartsDecrement()
    {
        if (plantHealths[plantIndex] > 0) plantHealths[plantIndex]--;
    }
}
