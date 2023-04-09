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

    public elapsedtime dayChange;
    public GameObject myParent;

    public TextMeshProUGUI debugText;
    List<TaskScriptableObject> TaskArr; 
    Player _player;
    private List<int> localTasks = new List<int>(5);
    
    //int[] arr = {1,2};
    void Start()
    {
        // if (dayChange.GetComponent<bool>()) {

        // }
        //taskArr = Resources.Load<TaskScriptableObject[]>("Tasks");
        //taskArr = (TaskScriptableObject[])Resources.LoadAll("Tasks", typeof(TaskScriptableObject));
        //TaskScriptableObject[] taskArr = Resources.LoadAll("Tasks") as TaskScriptableObject[];
        _player = GameObject.Find("Player").GetComponent<Player>();
        dayChange = GameObject.Find("DayChange").GetComponent<elapsedtime>();

        //edit player data so that the new info comes in everyday

        TaskArr = new List<TaskScriptableObject>();
        TaskArr = Resources.LoadAll<TaskScriptableObject>("Tasks").Cast<TaskScriptableObject>().ToList();
        // _player.tasks = new int[8];

        Debug.Log(TaskArr.Count);
        // for (int i = 0; i < 3; i++) {
        //     int task = Random.Range(0, TaskArr.Count);
        //     _player.tasks[i] = task;
        // }
        //this grabs the task number 2 and puts it in there 
        
        //debugText.text = "num days since dl: " + _player.numDaysSinceDownload;
      
        // int task = Random.Range(0, taskObjects.Length);
        if (dayChange.newDay || _player.numDaysSinceDownload == 0) {
           
            localTasks.Clear();

            for (int i = 0; i < 5; i++) {
                int task = Random.Range(0, TaskArr.Count);
                 while (localTasks.Contains(task)) {
                    task = Random.Range(0, TaskArr.Count);
                 }
                 localTasks.Add(task);
                 _player.tasks[i] = task;
            }
            
            
            _player.numDaysSinceDownload += 1; 
        }

        for(int i = 0; i<5; i++){
            GameObject newTask = GameObject.Instantiate(taskToGenerate, myParent.transform);
            GameObject header = newTask.transform.GetChild(0).gameObject;
            GameObject taskDescript = newTask.transform.GetChild(1).gameObject;
            header.GetComponent<TextMeshProUGUI>().text = TaskArr[_player.tasks[i]].taskName;
            taskDescript.GetComponent<TextMeshProUGUI>().text = TaskArr[_player.tasks[i]].description;
        }
  
    }

    public void DebugReRollOnClick() {

        for (int i = 0; i < myParent.transform.childCount; i++) {
            GameObject.Destroy(myParent.transform.GetChild(i).gameObject);
        }

        localTasks.Clear();

        for (int i = 0; i < 5; i++) {
            int task = Random.Range(0, TaskArr.Count);
            //  _player.tasks[i] = task;
            while (localTasks.Contains(task)) {
                task = Random.Range(0, TaskArr.Count);
            }
            localTasks.Add(task);
            _player.tasks[i] = task;
        }


        for(int i = 0; i< 5; i++){
            GameObject newTask = GameObject.Instantiate(taskToGenerate, myParent.transform);
            GameObject header = newTask.transform.GetChild(0).gameObject;
            GameObject taskDescript = newTask.transform.GetChild(1).gameObject;
            header.GetComponent<TextMeshProUGUI>().text = TaskArr[_player.tasks[i]].taskName;
            taskDescript.GetComponent<TextMeshProUGUI>().text = TaskArr[_player.tasks[i]].description;
        }

        for (int i = 0; i < 5; i++) {
            localTasks[i] = _player.tasks[i];
        }
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
