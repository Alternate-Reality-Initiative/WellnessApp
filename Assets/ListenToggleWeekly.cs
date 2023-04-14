using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListenToggleWeekly : MonoBehaviour
{
    // Start is called before the first frame update
    public ToggleManager manager;
    public Toggle myToggle;
    public int index;
    void Start()
    {
        manager = GameObject.Find("ToggleManager").GetComponent<ToggleManager>();
        myToggle.onValueChanged.AddListener( delegate{ 
            myToggle.interactable = false;
            manager.SaveCompletedWeeklyTask(index);} );

    }


    // void OnToggle(){
    //     myToggle.interactable = false;
    //     Debug.Log("interactables");
    //     manager.SaveCompletedTask(index);
    //     //myToggle.interactable = false;
        
    // }

    // Update is called once per frame
    void Update()
    {
        
    }


}
