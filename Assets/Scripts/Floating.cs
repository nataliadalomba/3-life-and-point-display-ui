using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {

    public float verticalSpeed;
    public float amplitude; //how high object can get

    public Vector3 tempPos;

    void Start() {
        tempPos = new Vector3 (transform.position.x, transform.position.y+2, transform.position.z);
    }

    void FixedUpdate() {
        tempPos.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPos;
    }
}
