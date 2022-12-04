using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceARObjectOnHand : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private HandPositionSolver handPositionSolver;
    [SerializeField] private GameObject arObject;
    [SerializeField] private float speedMovement = 0.5f;
    [SerializeField] private float speedRotation = 25.0f;

    private float MiNDistance = 0.05f;
    private float minAngleMagnitude = 2.0f;
    private bool shouldAdjustRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
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
