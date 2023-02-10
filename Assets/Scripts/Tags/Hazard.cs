using UnityEngine;

public class Hazard : MonoBehaviour {

    [SerializeField] private float verticalSpeed;
    [SerializeField] private float amplitude;

    private Vector3 originalPos;
    private Vector3 tempPos;

    private Quaternion originalRot;
    private Quaternion tempRot;

    private static System.Random rnd = new System.Random();

    private void Start () {
        tempPos = originalPos = new Vector3(transform.position.x, (float) rnd.NextDouble() + .3f, transform.position.z);
        verticalSpeed = (float)rnd.NextDouble();

        tempRot = originalRot;
    }

    private void FixedUpdate() {
        tempPos = originalPos;
        tempRot = originalRot = transform.rotation;

        float elapsedTime = 0;

        tempPos.y += Mathf.Sin(Time.realtimeSinceStartup * (verticalSpeed + 2)) * amplitude;
        transform.position = tempPos;

        transform.rotation = Quaternion.Lerp(originalRot, tempRot, (elapsedTime));
        elapsedTime += Time.deltaTime;
    }
}
