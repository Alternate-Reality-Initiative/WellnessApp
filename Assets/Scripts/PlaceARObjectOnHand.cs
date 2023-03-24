using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaceARObjectOnHand : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private HandPositionSolver handPositionSolver;
    private PlantScriptableObject plant;
    [SerializeField] private float speedMovement = 0.5f;
    [SerializeField] private float speedRotation = 25.0f;

    private float MiNDistance = 0.05f;
    private float minAngleMagnitude = 2.0f;
    private bool shouldAdjustRotation;

    public Player _player;
    private int[] _plantHealth;
    private int _plantIndex;
    private int currentHealth;
    public GameObject emptyPot;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject arObject; 
    List<PlantScriptableObject> plantArr; 

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        //_plantHealth = _player.plantHealth;
        _plantIndex = _player.selectedPlant;
        _plantIndex = 0; // temporary
        //currentHealth = _plantHealth[_plantIndex];
        plantArr = new List<PlantScriptableObject>();
        plantArr = Resources.LoadAll<PlantScriptableObject>("Plant SO").Cast<PlantScriptableObject>().ToList();
        plant = plantArr[_plantIndex];
        arObject = plant.plantObject;
    }

    //Update is called once per frame
    void Update()
    {
        PlaceObjectOnHand(handPositionSolver.HandPosition);
    }

    private void PlaceObjectOnHand(Vector3 handPosition)
    {
        float distance = Vector3.Distance(handPosition, arObject.transform.position);
        arObject.transform.position = handPosition;
            //Vector3.MoveTowards(arObject.transform.position, handPosition, speedMovement * Time.deltaTime);
        if (distance >= MiNDistance)
        {
            arObject.transform.LookAt(handPosition);
            shouldAdjustRotation = true;
        }
        else
        {
            if (shouldAdjustRotation)
            {
                arObject.transform.rotation =
                    Quaternion.Slerp(arObject.transform.rotation, Quaternion.identity, 2 * Time.deltaTime);
                Vector3 angles = arObject.transform.rotation.eulerAngles;
                shouldAdjustRotation = angles.magnitude >= minAngleMagnitude;
            }
            else
            {
                arObject.transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);
            }
        }
    }
    
}
