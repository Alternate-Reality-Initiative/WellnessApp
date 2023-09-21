using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaporate : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "plant")
            {
                Destroy(gameObject);
            }
    }
}
