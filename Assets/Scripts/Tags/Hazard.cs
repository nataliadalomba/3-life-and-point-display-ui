using UnityEngine;

public class Hazard : MonoBehaviour {

    [SerializeField] private float verticalSpeed;
    [SerializeField] private float amplitude;

    private Vector3 origPos;
    private Vector3 tempPos;

    private Quaternion origRot;
    private Quaternion tempRot;

    private static System.Random rnd = new System.Random();

    private void Start () {
        tempPos = origPos = new Vector3(transform.position.x, (float) rnd.NextDouble() + .3f, transform.position.z);
        verticalSpeed = (float)rnd.NextDouble();

        tempRot = origRot = transform.rotation;
    }

    private void FixedUpdate() {
        RandomFloating();
        tempRot = origRot = transform.rotation;

        float elapsedTime = 0;

        transform.rotation = Quaternion.Lerp(origRot, tempRot, (elapsedTime));
        elapsedTime += Time.deltaTime;
    }

    private void RandomFloating() {
        tempPos = origPos;
        tempPos.y += Mathf.Sin(Time.realtimeSinceStartup * (verticalSpeed + 2)) * amplitude;
        transform.position = tempPos;

    }
}
