using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTask : MonoBehaviour
{
    public TaskScriptableObject[] taskObjects;


    void Start() {
        taskObjects = Resources.LoadAll<TaskScriptableObject>("Tasks/");
        // Debug.Log(taskObjects.Length);
        // int task = Random.Range(0, taskObjects.Length);
        // string taskName = taskObjects[task].taskName;
        // Debug.Log(taskName);
        // string description = taskObjects[task].description;
        // Debug.Log(description);
        
    }
    
    // public TaskScriptableObject getTask() {
    //     int task = Random.Range(0, taskObjects.Length);
    //     return taskObjects[task];
    // }
}
