﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLocationOfCamera : MonoBehaviour
{
    public GameObject Destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLocation(string message)
    {
        Debug.Log("change location!!");
        if (message.Equals("ChangeLocation"))
        {
            GameObject.Find("XRRig_XROS").transform.position = Destination.transform.position;
            GameObject.Find("XRRig_XROS").transform.forward= -Destination.transform.forward;
        }
    }
}
