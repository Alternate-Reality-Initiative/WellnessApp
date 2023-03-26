using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideAndShow : MonoBehaviour
{
  public GameObject plantParent;
  private GameObject currentActiveBg;
  private Player player;

  void Start() {
    player = GameObject.Find("Player").GetComponent<Player>();

    // sets selected plant to the saved plant from the save data
    GameObject bgOfAlreadySelected = plantParent.transform.GetChild(player.selectedPlant).Find("YellowBackground").gameObject;
    ShowThis(bgOfAlreadySelected, player.selectedPlant);
  }

  public void ShowThis(GameObject plantBg, int index) {
   
    if (currentActiveBg == null) {
      // selecting a plant when none is selected
      currentActiveBg = plantBg;
      currentActiveBg.SetActive(true);
    }
    else if (plantBg != currentActiveBg) {
      // selecting one when there is already one selected and it's different than the one just clicked
      currentActiveBg.SetActive(false); 
      currentActiveBg = plantBg;
      currentActiveBg.SetActive(true);
    }

    // Important! This changes the selected plant index in data
    player.selectedPlant = index;
  }
}
