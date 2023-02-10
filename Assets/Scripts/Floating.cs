using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {

    [SerializeField] private float verticalSpeed;
    [SerializeField] private float amplitude; //how high object can get

    private Vector3 originalPos;
    private Vector3 tempPos;
        private static System.Random rnd = new System.Random();

    void Start() {
        tempPos = originalPos = new Vector3(transform.position.x, (float)rnd.NextDouble() + .3f, transform.position.z);
        verticalSpeed = (float)rnd.NextDouble();
    }

    void FixedUpdate() {
        tempPos = originalPos;
        tempPos.y += Mathf.Sin(Time.realtimeSinceStartup * (verticalSpeed + 3)) * amplitude;
        transform.position = tempPos;
    }
}
