using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TasksObject", menuName = "ScriptableObjects/Task")]
public class TaskScriptableObject : ScriptableObject
{
    public string taskName;
    // public int duration;
    public string description;
}


