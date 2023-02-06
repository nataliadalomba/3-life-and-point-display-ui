using UnityEngine;

//name of class shows it's attached to an object that will collect points
public class PointCollector : MonoBehaviour {
    private int pointCount;

    private void OnTriggerEnter(Collider other) {
        Collectable c = other.GetComponent<Collectable>();
        if (c != null) {
            pointCount++;
            Debug.Log("Points: " + pointCount);
            GameObject.Destroy(other.gameObject);
        }
    }
}

//for Unity methods, don't call them because they're magical and already get called per Unity and don't
//change their signature (return type, name, parameters)

//all monobehaviour scripts need to be attached to a GameObject or a prefab (instances must be in scene)