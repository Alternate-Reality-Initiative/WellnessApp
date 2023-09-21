using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class PlaceARObjectOnHand : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private HandPositionSolver handPositionSolver;
    private PlantScriptableObject plant;
    [SerializeField] private float speedRotation = 25.0f;

    private float MiNDistance = 0.05f;
    private float minAngleMagnitude = 2.0f;
    private bool shouldAdjustRotation;

    public Player _player;
    private int _plantIndex;
    private int startingHealth;
    public GameObject emptyPot;

    public GameObject arObject; 
    List<PlantScriptableObject> plantArr;

    private bool changeOncePot;
    private bool changeOncePlant;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _plantIndex = _player.selectedPlant;
        startingHealth = _player.plantHealth[_plantIndex];
        plantArr = new List<PlantScriptableObject>();
        plantArr = Resources.LoadAll<PlantScriptableObject>("Plant SO").Cast<PlantScriptableObject>().ToList();
        
        plant = plantArr[_plantIndex];

        changeOncePot = true;
        changeOncePlant = true;

        SetPlantObject();
    }

    //Update is called once per frame
    void Update()
    {
        UpdatePlantObject();
        PlaceObjectOnHand(handPositionSolver.HandPosition);
    }

    void SetPlantObject()
    {
        if (startingHealth == 0)
        {
            arObject = Instantiate(emptyPot, new Vector3(0, 0, 5), Quaternion.Euler(new Vector3(-90, 0, 0)));
            arObject.transform.localScale = new Vector3(6, 6, 264);
        }
        else
        {
            GameObject plantModel = plant.plantObject;
            arObject = Instantiate(plantModel, new Vector3(0, 0, 5), Quaternion.Euler(new Vector3(-90, 0, 0)));
            arObject.transform.localScale = plant.scale;
            arObject.transform.Rotate(plant.rotation);
        }
    }

    void UpdatePlantObject()
    {
        if (_player.plantHealth[_plantIndex] == 0 && changeOncePot)
        {
            Destroy(arObject);
            arObject = Instantiate(emptyPot, new Vector3(0, 0, 5), Quaternion.Euler(new Vector3(-90, 0, 0)));
            arObject.transform.localScale = new Vector3(6, 6, 264);
            changeOncePot = false;
            changeOncePlant = true;
        }
        else if (_player.plantHealth[_plantIndex] != 0 && changeOncePlant)
        {
            Destroy(arObject);
            GameObject plantModel = plant.plantObject;
            arObject = Instantiate(plantModel, new Vector3(0, 0, 5), Quaternion.Euler(new Vector3(-90, 0, 0)));
            arObject.transform.localScale = plant.scale;
            arObject.transform.Rotate(plant.rotation);
            changeOncePot = true;
            changeOncePlant = false;
        }
    }

    private void PlaceObjectOnHand(Vector3 handPosition)
    {
        float distance = Vector3.Distance(handPosition, arObject.transform.position);
        arObject.transform.position = handPosition;
        //arObject.transform.rotation = Quaternion.Euler(new Vector3(-90,0,0));
        if (distance >= MiNDistance)
        {
            arObject.transform.LookAt(handPosition);
            shouldAdjustRotation = true;
        }
        // else
        // {
        //     if (shouldAdjustRotation)
        //     {
        //         arObject.transform.rotation =
        //             Quaternion.Slerp(arObject.transform.rotation, Quaternion.identity, 2 * Time.deltaTime);
        //         Vector3 angles = arObject.transform.rotation.eulerAngles;
        //         shouldAdjustRotation = angles.magnitude >= minAngleMagnitude;
        //     }
        //     else
        //     {
        //         arObject.transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);
        //     }
        // }
    }
    
}
