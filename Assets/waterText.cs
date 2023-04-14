using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waterText : MonoBehaviour
{
    public TextMeshProUGUI waterCounter;
    // Start is called before the first frame update
      Player _player;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        waterCounter.text = _player.waterLevel.ToString();
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
