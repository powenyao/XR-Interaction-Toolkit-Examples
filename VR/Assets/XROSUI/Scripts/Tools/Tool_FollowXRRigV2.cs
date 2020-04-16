﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool_FollowXRRigV2 : MonoBehaviour
{
    public GameObject GO_XRRigCamera;

    public float UpdateFrequencyInSeconds = 0.05f;
    public float DistanceToStopMoving = 0.3f;
    public float distanceInFrontOfPlayer = 0.5f;

    public float speed = 1.0f;
    private Vector3 startPositon;
    private Vector3 goalPosition;
    private float startTime;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        //GO_XRRigCamera = Core.Ins.XRManager.GetCamera().gameObject;
        GO_XRRigCamera = Camera.main.gameObject;
        goalPosition = this.transform.position;
        SetNewGoal();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 newGoalPosition = GO_XRRigCamera.transform.position + GO_XRRigCamera.transform.forward * distanceInFrontOfPlayer;
        //print(Vector3.Distance(newGoalPosition, this.transform.position));
        if (Vector3.Distance(newGoalPosition, this.transform.position) > DistanceToStopMoving)
        {
            if (startTime + UpdateFrequencyInSeconds < Time.time)
            {
                SetNewGoal();
            }
        }
        FollowCamera();
    }

    void SetNewGoal()
    {
        //print("Set new goal");
        //GoalPosition = GO_XRRigCamera.transform.position;
        startPositon = this.transform.position;
        goalPosition = GO_XRRigCamera.transform.position + GO_XRRigCamera.transform.forward * distanceInFrontOfPlayer;
        journeyLength = Vector3.Distance(startPositon, goalPosition);
        startTime = Time.time;
    }

    void FollowCamera()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        //print("fraction: " + fractionOfJourney);
        this.transform.position = Vector3.Lerp(startPositon, goalPosition, fractionOfJourney);
        //this.transform.position = GO_XRRigCamera.transform.position + GO_XRRigCamera.transform.forward * distanceInFrontOfPlayer;
        this.transform.LookAt(GO_XRRigCamera.transform);
    }
}
