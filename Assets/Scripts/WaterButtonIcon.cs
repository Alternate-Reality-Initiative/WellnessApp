using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterButtonIcon : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    private int[] plantHealths;
    private int plantIndex;
    private int currentHealth;
    public Button button;
    public Sprite water;
    public Sprite revive;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        plantHealths = _player.plantHealth;
        plantIndex = _player.selectedPlant;
        currentHealth = plantHealths[plantIndex];
    }

    // Update is called once per frame
    void Update()
    {
        ChangeIcon();
    }

    private void ChangeIcon()
    {
        if (currentHealth > 0)
        {
            button.image.sprite = water;
        }
        else
        {
            button.image.sprite = revive;
        }
    }
}
