using UnityEngine;
using UnityEngine.InputSystem;

public class CameraView : MonoBehaviour {
    public Transform player;
    public InputAction cameraAction;

    public float rotationSpeed = 360.0f;

    // Camera collision
    public LayerMask obstacleLayers;
    public float cameraRadius = 0.5f;
    public float collisionBuffer = 0.2f;

    private Vector3 offset;

    private float currentRotation = 0.0f;
    private float targetRotation = 0.0f;

    void Start() {
        cameraAction.Enable();

        // Remember original camera position relative to pigeon
        offset = transform.position - player.position;
    }

    void LateUpdate() {
        // Q / E rotation
        if (cameraAction.WasPressedThisFrame()) {
            float input = cameraAction.ReadValue<float>();

            // E
            if (input > 0) {
                targetRotation += 90.0f;
            }

            // Q
            if (input < 0) {
                targetRotation -= 90.0f;
            }
        }

        // Smooth rotation
        currentRotation = Mathf.MoveTowardsAngle(
            currentRotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        // Rotate original offset
        Quaternion rotation =
            Quaternion.Euler(0, currentRotation, 0);

        Vector3 rotatedOffset =
            rotation * offset;

        // Where camera wants to be
        Vector3 desiredPosition =
            player.position + rotatedOffset;

        // Direction from player toward camera
        Vector3 direction =
            desiredPosition - player.position;

        float desiredDistance = direction.magnitude;

        direction.Normalize();

        RaycastHit hit;

        // Check a VOLUME instead of a single thin ray
        if (Physics.SphereCast(
            player.position,
            cameraRadius,
            direction,
            out hit,
            desiredDistance,
            obstacleLayers,
            QueryTriggerInteraction.Ignore
        )) {
            // Stay on the player's side of the obstacle
            float safeDistance =
                hit.distance - collisionBuffer;

            safeDistance =
                Mathf.Max(safeDistance, 0.1f);

            transform.position =
                player.position +
                direction * safeDistance;
        } else {
            transform.position = desiredPosition;
        }

        // Always look at pigeon
        transform.LookAt(player.position);
    }
}