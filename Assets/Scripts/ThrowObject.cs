//Standard Unity/C# functionality
using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//These tell our project to use pieces from the Lightship ARDK
using Niantic.ARDK.AR;
using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.Utilities;
using Niantic.ARDK.Utilities.Input.Legacy;

using TMPro;

//Define our main class
public class ThrowObject : MonoBehaviour
{
    
    [SerializeField] 

    //Variables we'll need to reference other objects in our game
    public GameObject _objectPrefab;  //This will store the Object Prefab we created earlier, so we can spawn a new Object whenever we want
    public Camera _mainCamera;  //This will reference the MainCamera in the scene, so the ARDK can leverage the device camera
    IARSession _ARsession;  //An ARDK ARSession is the main piece that manages the AR experience
    public TMP_Text _waterCounter; //Need to get the amount of water from saved data
    public Player _player;
    public int[] plantHealths;
    public int plantIndex;
    public int currentHealth;
    //public Collision collision;
    public GameObject plant;
    public GameObject promptPanel;
    public Button spendWaterButton;
    public TextMeshProUGUI promptWaterCost;
    private List<PlantScriptableObject> plantArr;

    // Start is called before the first frame update
    void Start()
    {
        //ARSessionFactory helps create our AR Session. Here, we're telling our 'ARSessionFactory' to listen to when a new ARSession is created, then call an 'OnSessionInitialized' function when we get notified of one being created
        ARSessionFactory.SessionInitialized += OnSessionInitialized;

        _player = GameObject.Find("Player").GetComponent<Player>();
        plantHealths = _player.plantHealth;
        plantIndex = _player.selectedPlant;
        currentHealth = plantHealths[plantIndex];
        PlaceARObjectOnHand script = GameObject.Find("ExampleManager").GetComponent<PlaceARObjectOnHand>();
        plant = script.arObject;
        //collision = plant.GetComponent<Collision>();
        plantArr = new List<PlantScriptableObject>();
        plantArr = Resources.LoadAll<PlantScriptableObject>("Plant SO").Cast<PlantScriptableObject>().ToList();


        //_player.waterLevel = int.Parse(_waterCounter.text);
        _waterCounter.text = _player.waterLevel.ToString();
        //Debug.Log(_player.waterLevel);
    }

    //This function will be called when a new AR Session has been created, as we instructed our 'ARSessionFactory' earlier
    public void OnSessionInitialized(AnyARSessionInitializedArgs args)
    {
        //Now that we've initiated our session, we don't need to do this again so we can remove the callback
        ARSessionFactory.SessionInitialized -= OnSessionInitialized;

        //Here we're saving our AR Session to our '_ARsession' variable, along with any arguments our session contains
        _ARsession = args.Session;
    }

    //This function will be called when the player touches the screen. For us, we'll have this trigger the shooting of our object from where we touch.
    public void ClickButton()
    {
        if (_player.waterLevel > 0 && plantHealths[plantIndex] > 0) { // water button
            System.Random rnd = new System.Random();
            var radius = .2;

            for(int i = 0; i < 5; i++){
                double angle = rnd.NextDouble() * (2 * Math.PI);

                GameObject newObject = Instantiate(_objectPrefab);  //Spawn a new object from our Ball Prefab
                newObject.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));   //Set the rotation of our new object
                newObject.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward;    //Set the position of our new object to just in front of our Main Camera
                newObject.transform.Translate((float)(radius * Math.Cos(angle)), (float)(radius * Math.Sin(angle)), 0);
                Rigidbody rigbod = newObject.GetComponent<Rigidbody>();
                rigbod.velocity = new Vector3(0f, 0f, 0f);
                float force = 300.0f;
                rigbod.AddForce(_mainCamera.transform.forward * force);
                //StartCoroutine(Evaporate(newObject));
            }

            _player.waterLevel--; // decrement the player's water level
            _waterCounter.text = _player.waterLevel.ToString(); // display new water level

            //Debug.Log(_player.waterLevel);
        }
        else if (plantHealths[plantIndex] == 0) // revive button
        {
            Debug.Log("hi");
            ShowPrompt();
        }
        //else if (_player.waterLevel == 0)             // FOR TESTING
        //{
        //    _player.waterLevel = 10;
        //    _waterCounter.text = _player.waterLevel.ToString();
        //}
    }
    //IEnumerator Evaporate(GameObject droplet){
    //    if (collision.gameObject.tag == "raindrop" && _player.plantHealth[_player.selectedPlant] < 3)
    //    {
    //        _player.plantHealth[_player.selectedPlant]++;
    //        Destroy(droplet);
    //    }
    //    else
    //    {
    //        yield return new WaitForSeconds(2f);
    //        Destroy(droplet);
    //    }
    //}
    private void ShowPrompt()
    {
        Debug.Log("hello");
        promptPanel.SetActive(true);

        PlantScriptableObject plantInfo = plantArr[plantIndex];
        TextMeshProUGUI spendButtonText = spendWaterButton.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if (_player.waterLevel < 5)
        {
            spendButtonText.text = "Not Enough Water";
            spendButtonText.fontSize = 50;
        }
        else
        {
            spendWaterButton.interactable = true;
            spendButtonText.text = "YES";
            spendButtonText.fontSize = 60;
            promptWaterCost.text = "Spend 5 Water\n to Revive \n" + plantInfo.name + "?";
        }
    }
    public void HidePrompt()
    {
        promptPanel.SetActive(false);
    }

    public void SpendWaterToReviveOnClick()
    {
        if (_player.waterLevel >= 5)
        {
            _player.waterLevel -= 5;
            _waterCounter.text = _player.waterLevel.ToString();
            _player.plantHealth[plantIndex] = 3; // revive the selected plant's health back to 3

            // hide this menu
            HidePrompt();

            // set model back from empty pot to normal plant
            GameObject plantModel = plantArr[plantIndex].plantObject;
            plant = Instantiate(plantModel, new Vector3(0, 0, 5), Quaternion.Euler(new Vector3(-90, 0, 0)));
            plant.transform.localScale = new Vector3(10, 10, 10);
            if (plantArr[plantIndex].name == "Sprout")
            {
                plant.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }
    }
}