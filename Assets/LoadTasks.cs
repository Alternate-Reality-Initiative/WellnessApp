using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
public class LoadTasks : MonoBehaviour
{
    // Start is called before the first frame update
    //Object[] taskArr;
    public GameObject taskToGenerate; 
    public GameObject parent;
    List<TaskScriptableObject> TaskArr; 
    Player _player;
    
    //int[] arr = {1,2};
    void Start()
    {

        //taskArr = Resources.Load<TaskScriptableObject[]>("Tasks");
        //taskArr = (TaskScriptableObject[])Resources.LoadAll("Tasks", typeof(TaskScriptableObject));
        //TaskScriptableObject[] taskArr = Resources.LoadAll("Tasks") as TaskScriptableObject[];
        _player = GameObject.Find("Player").GetComponent<Player>();

        //edit player data so that the new info comes in everyday
        
        TaskArr = new List<TaskScriptableObject>();
        TaskArr = Resources.LoadAll<TaskScriptableObject>("Tasks").Cast<TaskScriptableObject>().ToList();
        
        Debug.Log(TaskArr.Count);

      
        // int task = Random.Range(0, taskObjects.Length);
        _player.tasks = new int[2]; //this grabs the task number 2 and puts it in there 

        for(int i = 0; i<_player.tasks.Length; i++){
        //    Debug.Log( TaskArr[_player.tasks[i]].taskName);
            GameObject newTask = GameObject.Instantiate(taskToGenerate, parent.transform);
            GameObject header = newTask.transform.GetChild(0).gameObject;
            GameObject taskDescript = newTask.transform.GetChild(1).gameObject;
            header.GetComponent<TextMeshProUGUI>().text = TaskArr[_player.tasks[i]].taskName;
            taskDescript.GetComponent<TextMeshProUGUI>().text = TaskArr[_player.tasks[i]].description;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
