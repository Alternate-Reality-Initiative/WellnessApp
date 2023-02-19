using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideAndShow : MonoBehaviour
{
  public GameObject the_back; 

  public void hide() {
    the_back.SetActive(false);
  }
  public void show(){
    the_back.SetActive(true);
  }
}
