﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.0f);

        GetComponent<Rigidbody2D>().AddForce(transform.up * 400);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
