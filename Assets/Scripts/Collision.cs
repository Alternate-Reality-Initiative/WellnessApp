using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "raindrop")
        {	
            GetComponent<Renderer>().material.color = new Color (
											Random.Range(0f,1f),
											Random.Range(0f,1f),
											Random.Range(0f,1f));
        }
    }
    
}
