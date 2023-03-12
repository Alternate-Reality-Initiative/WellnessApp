using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTask : MonoBehaviour
{
    void Start() {
        TaskScriptableObject[] taskObjects = Resources.LoadAll<TaskScriptableObject>("Tasks/");
        Debug.Log(taskObjects.Length);
        int task = Random.Range(0, taskObjects.Length);
        Debug.Log(taskObjects[task].name);
    }
}
