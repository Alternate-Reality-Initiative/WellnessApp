using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class hideAndShow : MonoBehaviour
{
  public GameObject plantParent;
  private GameObject currentActiveBg;
  [HideInInspector]
  Player player;
  public GameObject promptPanel;
  public TextMeshProUGUI promptWaterCost;
  public Button spendWaterButton;
  private int indexOfPlantInPrompt = -1;
  private List<PlantScriptableObject> plantArr; 

  void Start() {
    player = GameObject.Find("Player").GetComponent<Player>();

    plantArr = new List<PlantScriptableObject>();
    plantArr = Resources.LoadAll<PlantScriptableObject>("Plant SO").Cast<PlantScriptableObject>().ToList();

    // sets selected plant to the saved plant from the save data
    GameObject bgOfAlreadySelected = plantParent.transform.GetChild(player.selectedPlant).Find("YellowBackground").gameObject;
    SelectThisPlant(bgOfAlreadySelected, player.selectedPlant);

    for(int i = 0; i < Player.NUM_PLANTS; i++) {
      if (player.unlockedPlants[i] == true) {
        Transform plantCard = plantParent.transform.GetChild(i);
        plantCard.Find("LockedPlant").gameObject.SetActive(false);
        plantCard.GetComponent<InventoryScript>().isUnlocked = true;
        plantCard.GetComponent<InventoryScript>().SetUpHeart(player.plantHealth[i]);
      }
    }
  }

  public void ShowPrompt(int index) {
    promptPanel.SetActive(true);

    PlantScriptableObject plantInfo = plantArr[index];
    TextMeshProUGUI spendButtonText = spendWaterButton.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    if (player.waterLevel < 3) {
      spendButtonText.text = "Not Enough Water";
      spendButtonText.fontSize = 50;
    } else {
      spendWaterButton.interactable = true;
      spendButtonText.text = "YES";
      spendButtonText.fontSize = 60;
      promptWaterCost.text = "Spend 3 Water\n to Unlock \n" + plantInfo.name + "?";
      indexOfPlantInPrompt = index;
    }
  }

  public void HidePromptOnClick() {
    promptPanel.SetActive(false);
    indexOfPlantInPrompt = -1; 
  }

  public void SpendWaterToUnlockOnClick() {
    if (indexOfPlantInPrompt != -1) {
      player.waterLevel -= 3;

      // set to unlocked in data
      player.unlockedPlants[indexOfPlantInPrompt] = true;
      player.selectedPlant = indexOfPlantInPrompt;

      // set to unlocked in script sitting on card in collection
      // set up heart
      InventoryScript inventoryScript = plantParent.transform.GetChild(player.selectedPlant).GetComponent<InventoryScript>();
      inventoryScript.isUnlocked = true;
      player.plantHealth[indexOfPlantInPrompt] = 3; // set health to 3 on unlock
      inventoryScript.SetUpHeart(player.plantHealth[indexOfPlantInPrompt]);

      // hide gray locked art
      RemoveLockedImage(player.selectedPlant);
      
      // show 'selected' art
      GameObject bgToSelect = plantParent.transform.GetChild(player.selectedPlant).Find("YellowBackground").gameObject;
      SelectThisPlant(bgToSelect, player.selectedPlant);

      // hide this menu
      HidePromptOnClick();

      // update water counter
      GameObject.Find("watertext").GetComponent<waterText>().UpdateWaterText();
    }
  }
  
  private void RemoveLockedImage(int index) {
    plantParent.transform.GetChild(index).Find("LockedPlant").gameObject.SetActive(false);
  }

  public void SelectThisPlant(GameObject plantBg, int index) {
   
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

  public void ResetUnlocksOnClick() {
    for(int i = 0; i < Player.NUM_PLANTS; i++) {
      player.unlockedPlants[i] = false;
    }
    player.unlockedPlants[Player.SPROUT_INDEX] = true;
    player.selectedPlant = Player.SPROUT_INDEX;
     // reload the scene
    GameObject.Find("SceneManager").GetComponent<SceneController>().SwitchScene("Plant Collection Team");
    
  }

  public void UnlockAllOnClick() {
    for(int i = 0; i < Player.NUM_PLANTS; i++) {
      player.unlockedPlants[i] = true;
    }
    // reload the scene 
    GameObject.Find("SceneManager").GetComponent<SceneController>().SwitchScene("Plant Collection Team");
  }

  public void ResetWaterOnClick() {
    player.waterLevel = 10;
    GameObject.Find("watertext").GetComponent<waterText>().UpdateWaterText();
  }
}
