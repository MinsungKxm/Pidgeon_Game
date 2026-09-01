using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float hopDistance = 1.0f;

    public InputAction MoveAction;
    public Vector2 moveInput;

    public Vector2 previousInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = MoveAction.ReadValue<Vector2>();
        // W was just pressed
        if (moveInput.y > 0 && previousInput.y <= 0) {
            transform.Translate(Vector3.forward * hopDistance);
        }
        // D was just pressed
        if(moveInput.x > 0 && previousInput.x <= 0) {
            transform.Rotate(Vector3.up, 90);
        }
        previousInput = moveInput;
    }
}
