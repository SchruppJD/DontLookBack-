﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public List<Door> doors;
    private bool grabbed;

    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrabKey()
    {
        if(!grabbed)
        {
            grabbed = true;
            foreach(Door d in doors)
            {
                d.OpenLock();
            }
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            Vector3 cameraPos = camera.transform.position;
            int numOfKeys = camera.transform.childCount;
            transform.position = new Vector3((cameraPos.x - 4.0f) + (transform.localScale.x * numOfKeys), cameraPos.y + 1.0f, -4.0f);
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            transform.parent = camera.transform;
            Destroy(this);
        }
    }
}
