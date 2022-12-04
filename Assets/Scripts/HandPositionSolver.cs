using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARDK.Extensions;
using Niantic.ARDK.AR.Awareness;

public class HandPositionSolver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ARHandTrackingManager handTrackingManager;
    [SerializeField] private Camera arCamera;
    [SerializeField] private float minHandConf = 0.55f;

    private Vector3 handPosition;
    public Vector3 HandPosition
    {
        get => handPosition;
    }
    void Start()
    {
        handTrackingManager.HandTrackingUpdated += HandTrackingUpdated;
    }

    private void OnDestroy()
    {
        handTrackingManager.HandTrackingUpdated -= HandTrackingUpdated;
    }

    private void HandTrackingUpdated(HumanTrackingArgs handData)
    {
        var detections = handData.TrackingData?.AlignedDetections;
        if (detections == null)
        {
            return;
        }

        foreach (var detection in detections)
        {
            if (detection.Confidence < minHandConf)
            {
                return;
            }

            Vector3 detectionSize = new Vector3(detection.Rect.width, detection.Rect.height, 0);
            float depthEstimation = 0.2f + Math.Abs(1 - detectionSize.magnitude);

            handPosition = arCamera.ViewportToWorldPoint(new Vector3(detection.Rect.center.x,
                1 - detection.Rect.center.y, depthEstimation));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
