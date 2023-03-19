using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LoadTasks : MonoBehaviour
{
    // Start is called before the first frame update
    //Object[] taskArr;
    List<TaskScriptableObject> TaskArr; 
    Player _player;
    
    //int[] arr = {1,2};
    void Start()
    {
        //taskArr = Resources.Load<TaskScriptableObject[]>("Tasks");
        //taskArr = (TaskScriptableObject[])Resources.LoadAll("Tasks", typeof(TaskScriptableObject));
        //TaskScriptableObject[] taskArr = Resources.LoadAll("Tasks") as TaskScriptableObject[];
        _player = GameObject.Find("Player").GetComponent<Player>();
        TaskArr = new List<TaskScriptableObject>();
        TaskArr = Resources.LoadAll<TaskScriptableObject>("Tasks").Cast<TaskScriptableObject>().ToList();
        
        Debug.Log(TaskArr.Count);


        for(int i = 0; i<_player.tasks.Length; i++){
           Debug.Log( TaskArr[_player.tasks[i]].taskName);
        }
        _player.tasks = new int[2];

        for(int i = 0; i<_player.tasks.Length; i++){
           Debug.Log( TaskArr[_player.tasks[i]].taskName);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
