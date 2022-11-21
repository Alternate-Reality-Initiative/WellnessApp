using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    public string name;
    
    public PlayerData (Player player){
        name = player.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
