using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class InputFieldManager : MonoBehaviour
{
    public TMP_InputField name;
    //public static string saveName;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        //string text = inputField.GetComponent<TMP_InputField>().text;
        //name.text = PlayerData.name;
        player.LoadPlayer();
        name.text = player.name;
    }

    public void GetName(){
        //saveName = name.text;
        player.name = name.text;
        player.SavePlayer();
        //Debug.Log("hi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
