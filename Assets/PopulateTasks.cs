using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateTasks : MonoBehaviour
{
    public GameObject taskToGenerate; 
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
      // TaskScriptableObject obj1 = generator.getTask();
      _player = GameObject.Find("Player").GetComponent<Player>();

      // Instantiate(taskToGenerate);
      
    }

    // Update is called once per frame
    // void Update()x
    // {
        
    // }
}
