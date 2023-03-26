using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideAndShowChecklist : MonoBehaviour
{
    public GameObject weekly;
    public GameObject daily;

    private void Start() {
        weekly.SetActive(false);
        daily.SetActive(true);
    }
    public void weeklyScreen() {
        weekly.SetActive(true);
        daily.SetActive(false);

    }
    public void dailyScreen() {
        weekly.SetActive(false);
        daily.SetActive(true);
    }
}
