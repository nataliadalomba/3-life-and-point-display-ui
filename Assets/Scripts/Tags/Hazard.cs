using UnityEngine;
using UnityEngine.Serialization;

public class Hazard : MonoBehaviour {
    [Tooltip("Defines how high and low this object will bob up and down, measured in world-space units.")]
    [SerializeField] private float amplitude = 0.2f;

    [Tooltip("The rate at which this object will rotate over time, measured in degrees per second.")]
    [FormerlySerializedAs("rotSpeed")]
    [SerializeField] private float angularSpeed = 60;

    [Tooltip("Defines the range within which a vertical speed will be randomly chosen for this object.\n\n" +
        "This object's vertical speed describes the frequency of the up and down bobbing motion.")]
    [SerializeField] private Vector2 verticalSpeedRange = new Vector2(2, 3);

    private Vector3 originalPosition;
    private float verticalSpeed;
    private Vector3 rotationalAxis;

    private void Start() {
        originalPosition = transform.position;
        verticalSpeed = Random.Range(verticalSpeedRange.x, verticalSpeedRange.y);
        rotationalAxis = Random.onUnitSphere;
    }

    private void Update() {
        UpdatePosition();
        UpdateRotation();
    }

    private void UpdatePosition() {
        Vector3 pos = originalPosition;
        pos.y = originalPosition.y + amplitude * Mathf.Sin(Time.time * verticalSpeed);
        transform.position = pos;
    }

    private void UpdateRotation() {
        Quaternion deltaRotation = Quaternion.AngleAxis(angularSpeed * Time.deltaTime, rotationalAxis);
        transform.rotation = deltaRotation * transform.rotation;
    }
}
