﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRIC : MonoBehaviour {

    public static DestroyRIC DesInstance;
    // Use this for initialization
    void Start()
    {

            DesInstance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DesRIC()
    {
        Destroy(gameObject);
    }
}
