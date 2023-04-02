using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "raindrop" && _player.plantHealth[_player.selectedPlant] < 3)
        {
            // GetComponent<Renderer>().material.color = new Color (
            //Random.Range(0f,1f),
            //Random.Range(0f,1f),
            //Random.Range(0f,1f));
            _player.plantHealth[_player.selectedPlant]++;
        }
    }
    
}
