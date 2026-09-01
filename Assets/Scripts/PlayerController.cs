using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    public float hopDistance = 1.0f;
    public float hopHeight = 0.5f;
    public float hopDuration = 0.25f;

    public float turnSpeed = 360.0f;

    public InputAction MoveAction;
    public Vector2 moveInput;
    public Vector2 previousInput;

    private float targetRotation;
    private bool isRotating = false;

    private bool isHopping = false;
    private Vector3 hopStartPosition;
    private Vector3 hopEndPosition;
    private float hopTimer = 0.0f;

    public bool isDead = false;

    public GameObject deathScreen;
    void Start() {
        MoveAction.Enable();
        targetRotation = transform.eulerAngles.y;
    }

    void Update() {

        if (isDead)
            return;

        moveInput = MoveAction.ReadValue<Vector2>();

        // W was just pressed
        if (moveInput.y > 0 && previousInput.y <= 0 && !isHopping) {
            StartHop();
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

        if (isRotating) {
            float newRotation = Mathf.MoveTowardsAngle(
                transform.eulerAngles.y,
                targetRotation,
                turnSpeed * Time.deltaTime
            );

            transform.rotation = Quaternion.Euler(0, newRotation, 0);

            if (Mathf.Abs(Mathf.DeltaAngle(newRotation, targetRotation)) < 0.01f) {
                isRotating = false;
            }
        }

        if (isHopping) {
            UpdateHop();
        }

        previousInput = moveInput;

    }

    void StartHop() {
        isHopping = true;
        hopTimer = 0.0f;

        hopStartPosition = transform.position;

        hopEndPosition =
            hopStartPosition +
            transform.forward * hopDistance;
    }

    void UpdateHop() {
        hopTimer += Time.deltaTime;

        float t = hopTimer / hopDuration;

        // Move forward
        Vector3 position = Vector3.Lerp(
            hopStartPosition,
            hopEndPosition,
            t
        );

        // Move upward, then downward
        float height = Mathf.Sin(t * Mathf.PI) * hopHeight;

        position.y += height;

        transform.position = position;

        if (t >= 1.0f) {
            transform.position = hopEndPosition;
            isHopping = false;
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Car")) {
            Die();
        }
    }
    void Die() {
        isDead = true;

        // Make the pidgeon fall sideways
        transform.Rotate(0, 0, 90);
        deathScreen.SetActive(true);

    }
}