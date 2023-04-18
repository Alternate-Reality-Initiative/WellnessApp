using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
public class LoadTasks : MonoBehaviour
{
    // Start is called before the first frame update
    //Object[] taskArr;
    public GameObject daily; 
    public GameObject weekly;

    public elapsedtime dayChange;
    public week weekChange;
    public GameObject DailyParent;
    public GameObject WeeklyParent;

    public TextMeshProUGUI debugText;
    List<TaskScriptableObject> TaskArrDaily; 
    List<TaskScriptableObject> TaskArrWeekly; 
    Player _player;
    private List<int> localTasks = new List<int>(5);
    private List<int> localWeeklyTasks = new List<int>(5);
    
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
        weekChange = GameObject.Find("weekChange").GetComponent<week>();

        //edit player data so that the new info comes in everyday

        TaskArrDaily = new List<TaskScriptableObject>();
        TaskArrDaily = Resources.LoadAll<TaskScriptableObject>("Tasks").Cast<TaskScriptableObject>().ToList();

        TaskArrWeekly = new List<TaskScriptableObject>();
        TaskArrWeekly = Resources.LoadAll<TaskScriptableObject>("WeeklyTasks").Cast<TaskScriptableObject>().ToList();
        // _player.tasks = new int[8];

        Debug.Log("Weekly count " + TaskArrWeekly.Count);
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
                int task = Random.Range(0, TaskArrDaily.Count);
                 while (localTasks.Contains(task)) {
                    task = Random.Range(0, TaskArrDaily.Count);
                 }
                 localTasks.Add(task);
                 _player.tasks[i] = task;
            }
            
            
            _player.numDaysSinceDownload += 1; 
        }

        if (weekChange.newWeek || _player.numDaysSinceDownload == 0) {

            localWeeklyTasks.Clear();

            for (int i = 0; i < 5; i++) {
                int taskW = Random.Range(0, TaskArrWeekly.Count);
                Debug.Log("task" + taskW);
                 while (localWeeklyTasks.Contains(taskW)) {
                    taskW = Random.Range(0, TaskArrWeekly.Count);
                    Debug.Log("Goes into while loop iteration : " + i);
                 }
                 localWeeklyTasks.Add(taskW);
                 _player.weeklyTasks[i] = taskW;
            }
        }

        for(int i = 0; i<5; i++){
            GameObject newTask = GameObject.Instantiate(daily, DailyParent.transform);
            ListenToggle tog = newTask.GetComponent<ListenToggle>();
            tog.myToggle.isOn = _player.completedDailyTasks[i];
            
            tog.myToggle.interactable = !(_player.completedDailyTasks[i]);
            tog.index = i;
            
            GameObject header = newTask.transform.GetChild(0).gameObject;
            GameObject taskDescript = newTask.transform.GetChild(1).gameObject;
            header.GetComponent<TextMeshProUGUI>().text = TaskArrDaily[_player.tasks[i]].taskName;
            taskDescript.GetComponent<TextMeshProUGUI>().text = TaskArrDaily[_player.tasks[i]].description;
        }

        for(int i = 0; i<5; i++){
            GameObject newTaskWeekly = GameObject.Instantiate(weekly, WeeklyParent.transform);
            ListenToggleWeekly tog2 = newTaskWeekly.GetComponent<ListenToggleWeekly>();
            tog2.myToggle.isOn = _player.completedWeeklyTasks[i];
            
            tog2.myToggle.interactable = !(_player.completedWeeklyTasks[i]);
            tog2.index = i;
            
            GameObject headerWeekly = newTaskWeekly.transform.GetChild(0).gameObject;
            GameObject taskDescriptWeekly = newTaskWeekly.transform.GetChild(1).gameObject;
            Debug.Log(_player.weeklyTasks[i]);
            headerWeekly.GetComponent<TextMeshProUGUI>().text = TaskArrWeekly[_player.weeklyTasks[i]].taskName;
            taskDescriptWeekly.GetComponent<TextMeshProUGUI>().text = TaskArrWeekly[_player.weeklyTasks[i]].description;
        }

  
    }

    public void DebugReRollOnClick() {

        // destroy prefabs
        for (int i = 0; i < DailyParent.transform.childCount; i++) {
            GameObject.Destroy(DailyParent.transform.GetChild(i).gameObject);
        }

        // clear list
        localTasks.Clear();

        // generate new tasks
        for (int i = 0; i < 5; i++) {
            int task = Random.Range(0, TaskArrDaily.Count);
            while (localTasks.Contains(task)) {
                task = Random.Range(0, TaskArrDaily.Count);
            }
            localTasks.Add(task);
            _player.tasks[i] = task;
        }

        // spawn new prefabs
        for(int i = 0; i < 5; i++){
            GameObject newTask = GameObject.Instantiate(daily, DailyParent.transform);
            newTask.GetComponent<ListenToggle>().index = i;
            GameObject header = newTask.transform.GetChild(0).gameObject;
            GameObject taskDescript = newTask.transform.GetChild(1).gameObject;
            header.GetComponent<TextMeshProUGUI>().text = TaskArrDaily[_player.tasks[i]].taskName;
            taskDescript.GetComponent<TextMeshProUGUI>().text = TaskArrDaily[_player.tasks[i]].description;
        }

        // repopulate local list
        for (int i = 0; i < 5; i++) {
            localTasks[i] = _player.tasks[i];
        }

        // reset save data for which tasks you've already completed
        for (int i = 0; i < 30; i++) {
            _player.completedDailyTasks[i] = false;
            _player.completedWeeklyTasks[i] = false;
        }
  
    }
}
