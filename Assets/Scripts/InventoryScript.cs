using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public int index;
    private hideAndShow hideAndShow;
    private GameObject myBg;
    void Start () {
        myBg = transform.Find("YellowBackground").gameObject;
        if (myBg == null) {
            Debug.LogError("Could not retrieve background obj for plant card");
        }

        hideAndShow = GameObject.Find("HideAndShow").GetComponent<hideAndShow>();
        if (hideAndShow == null) {
            Debug.LogError("Collection item could not resolve hide and show reference");
        } 
    }

    public void OnClick() {
        hideAndShow.ShowThis(myBg, index);
    }
}
