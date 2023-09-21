using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButtonScriptChecklist : MonoBehaviour
{
    public GameObject debugPanel1;
    public void ToggleDebugMenuOnClick() {  
        debugPanel1.SetActive(!debugPanel1.activeInHierarchy);
    }
}
