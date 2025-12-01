using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraScript : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 2f;
    float camerVerticalRotation = 0f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Toggle cursor lock/unlock with LeftControl
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;   // Show cursor when unlocked
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;  // Hide cursor when locked
            }
        }

        // Only rotate camera when cursor is locked
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            camerVerticalRotation -= inputY;
            camerVerticalRotation = Mathf.Clamp(camerVerticalRotation, -90f, 90f);
            transform.localEulerAngles = Vector3.right * camerVerticalRotation;

            player.Rotate(Vector3.up * inputX);
        }
    }
}