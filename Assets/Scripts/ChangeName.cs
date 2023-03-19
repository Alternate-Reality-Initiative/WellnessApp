using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeName : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    private Player playerdata;
    
    void Start() {
        playerdata = GameObject.Find("Player").GetComponent<Player>();
       nameText.text = "Welcome Back, " + playerdata.name;  
    }
    // Start is called before the first frame update
    // void Update() {
    //     nameText = name;
    // }
    
}
