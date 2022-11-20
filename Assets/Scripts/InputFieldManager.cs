using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class InputFieldManager : MonoBehaviour
{
    public TMP_InputField name;
    string saveName;
    // Start is called before the first frame update
    void Start()
    {
        //string text = inputField.GetComponent<TMP_InputField>().text;
    }

    public void GetName(){
        saveName = name.text;
        Debug.Log(saveName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
