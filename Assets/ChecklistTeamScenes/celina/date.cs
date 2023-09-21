using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class date : MonoBehaviour
{
    public TextMeshPro largeText;

    
    void Start()
    {
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("M/dd/yy  hh:mm tt");
        largeText.text = time;
    }
    
    
}
