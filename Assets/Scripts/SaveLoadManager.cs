using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class SaveLoadManager : MonoBehaviour
{
    public TMP_InputField name;
    public TextMeshProUGUI water;
    //public static string saveName;
    public Player player;

    //private IEnumerator coroutine;

    void Awake()
    {
        //string text = inputField.GetComponent<TMP_InputField>().text;
        //name.text = PlayerData.name;
        string path = Path.Combine(Application.persistentDataPath, "player.wow");
        if (File.Exists(path))
        {
            player.LoadPlayer();
            name.text = player.name;
            water.text = player.waterLevel.ToString();
        }

        //coroutine = UpdateWater();
        //StartCoroutine(coroutine);
    }

    public void GetName(){
        //saveName = name.text;
        Debug.Log("hi");
        player.name = name.text;
        Debug.Log(water.text);
        player.waterLevel = int.Parse(water.text);
        
        player.SavePlayer();
    }

    // IEnumerator UpdateWater()
    // {
    //     while (true)
    //     {
    //         player.waterLevel = int.Parse(water.text);
    //         yield return new WaitForSeconds(1f);
    //         //player.waterLevel--;

    //         water.text = player.waterLevel.ToString();
    //         Debug.Log("hi");
    //         player.SavePlayer();
    //     }
    // }
    public void UpdateWater()
    {
        //while (true)
        //{
            player.waterLevel = int.Parse(water.text);
            //yield return new WaitForSeconds(1f);
            //player.waterLevel--;

            water.text = player.waterLevel.ToString();
            Debug.Log("ho");
            player.SavePlayer();
        //}
    }
}
