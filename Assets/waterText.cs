using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waterText : MonoBehaviour
{
    public TextMeshProUGUI waterCounter;
    Player _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        UpdateWaterText();
    }

    public void UpdateWaterText() {
      waterCounter.text = _player.waterLevel.ToString();
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
