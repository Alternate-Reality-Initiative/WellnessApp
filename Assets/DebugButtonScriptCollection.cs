using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButtonScriptCollection : MonoBehaviour
{
    public GameObject debugPanel1;
    public GameObject debugPanel2;

    public void ToggleDebugMenuOnClick() {  
        debugPanel2.SetActive(!debugPanel1.activeInHierarchy);
        debugPanel1.SetActive(!debugPanel1.activeInHierarchy);
    }
}
