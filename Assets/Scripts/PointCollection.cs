using Unity.VisualScripting;
using UnityEngine;

public class PointCollection : MonoBehaviour {
    [SerializeField] private GameObject point;
    private int pointCount;

    void Update() {
        OnTriggerEnter(point.GetComponent<SphereCollider>());
    }

    private int OnTriggerEnter(Collider collider) {
        Destroy(point.GetComponent<MeshRenderer>());
        pointCount++;
        Debug.Log("Points: " + pointCount);
        return pointCount;
    }
}