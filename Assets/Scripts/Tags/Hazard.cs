using UnityEngine;

public class Hazard : MonoBehaviour {

    [SerializeField] private float verticalSpeed;
    [SerializeField] private float amplitude;

    [SerializeField] private float rotSpeed;

    private Vector3 origPos;
    private Vector3 tempPos;

    private Vector3 rot = new Vector3(45f, 45f, 45f);

    private float rotDegreesPerSecond = 45f;

    private static System.Random rndFloat = new System.Random();
    private static System.Random rndRot = new System.Random();

    private void Start () {
        tempPos = origPos = new Vector3(transform.position.x, (float) rndFloat.NextDouble() + .3f, transform.position.z);
        verticalSpeed = (float)rndFloat.NextDouble();

        //rot = Quaternion.Euler((float)rndRot.NextDouble(), (float)rndRot.NextDouble(), (float)rndRot.NextDouble());

    }

    private void FixedUpdate() {
        RandomFloating();
        Rotation();
    }

    private void RandomFloating() {
        tempPos = origPos;
        tempPos.y += Mathf.Sin(Time.realtimeSinceStartup * (verticalSpeed + 2)) * amplitude;
        transform.position = tempPos;
    }

    private void Rotation() {
        //float yAngle = transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Euler(rot * Time.deltaTime) * transform.rotation;
        //transform.rotation = Quaternion.AngleAxis(yAngle + (Time.deltaTime * rotDegreesPerSecond), Vector3.up);
    }
}
