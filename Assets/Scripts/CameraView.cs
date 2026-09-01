using UnityEngine;
using UnityEngine.InputSystem;

public class CameraView : MonoBehaviour {
    public Transform player;
    public InputAction cameraAction;

    void Start() {
        cameraAction.Enable();
    }

    void LateUpdate() {
        // Keep the CameraPivot centered on the pigeon
        transform.position = player.position;

        // Check whether Q or E was just pressed
        if (cameraAction.WasPressedThisFrame()) {
            float input = cameraAction.ReadValue<float>();

            // E: rotate camera 90 degrees one way
            if (input > 0) {
                transform.Rotate(0, 90, 0);
            }

            // Q: rotate camera 90 degrees the other way
            if (input < 0) {
                transform.Rotate(0, -90, 0);
            }
        }
    }
}