using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Floating : MonoBehaviour {

    [SerializeField] private float verticalSpeed;
    [SerializeField] private float amplitude; //how high object can get

    private Vector3 origPos;
    private Vector3 tempPos;
    private static System.Random rnd = new System.Random();

    void Start() {
        tempPos = origPos = new Vector3(transform.position.x, (float)rnd.NextDouble() + .3f, transform.position.z);
        verticalSpeed = (float)rnd.NextDouble();
    }

    void FixedUpdate() {
        tempPos = origPos;
        tempPos.y += Mathf.Sin(Time.realtimeSinceStartup * (verticalSpeed + 3)) * amplitude;
        transform.position = tempPos;
    }
}
