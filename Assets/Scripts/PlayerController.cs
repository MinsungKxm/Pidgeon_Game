using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    public float hopDistance = 1.0f;

    // How many degrees the pigeon rotates per second
    public float turnSpeed = 360.0f;

    public InputAction MoveAction;
    public Vector2 moveInput;

    public Vector2 previousInput;

    // The Y rotation we want to eventually reach
    private float targetRotation;

    // Whether the pigeon is currently turning
    private bool isRotating = false;

    void Start() {
        MoveAction.Enable();

        // Start with the pigeon's current rotation
        targetRotation = transform.eulerAngles.y;
    }

    void Update() {
        moveInput = MoveAction.ReadValue<Vector2>();

        // W was just pressed
        if (moveInput.y > 0 && previousInput.y <= 0) {
            transform.Translate(Vector3.forward * hopDistance);
        }

        // D was just pressed
        if (moveInput.x > 0 && previousInput.x <= 0 && !isRotating) {
            targetRotation += 90.0f;
            isRotating = true;
        }

        // A was just pressed
        if (moveInput.x < 0 && previousInput.x >= 0 && !isRotating) {
            targetRotation -= 90.0f;
            isRotating = true;
        }

        // If we're currently turning
        if (isRotating) {
            float newRotation = Mathf.MoveTowardsAngle(
                transform.eulerAngles.y,
                targetRotation,
                turnSpeed * Time.deltaTime
            );

            transform.rotation = Quaternion.Euler(0, newRotation, 0);

            // Check whether we've finished the 90-degree turn
            if (Mathf.Approximately(newRotation, targetRotation)) {
                isRotating = false;
            }
        }

        previousInput = moveInput;
    }
}