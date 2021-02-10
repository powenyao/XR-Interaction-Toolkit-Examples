﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{

    public GameObject HeadLocation2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//        print("Head Rotation: " + HeadLocation2.GetComponent<Transform>().eulerAngles);
//        print("Head Rotation2: " + HeadLocation2.GetComponent<Transform>().localEulerAngles);

        var rot = HeadLocation2.transform.localEulerAngles;
//        print(rot);
        //this.transform.localEulerAngles = new Vector3(rot.x, 0, rot.z);
        this.transform.localEulerAngles = new Vector3(0, rot.y, 0);
    }
}
