using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerBody;  // The player's transform
    public float mouseSensitivity = 100f;
    public float distanceFromPlayer = 2f;  // Distance of the camera from the player

    [SerializeField] private float xRotation = 0f;
    [SerializeField] private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMouseLook();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;

        playerBody.localRotation = Quaternion.Euler(0f, yRotation, 0f);

        // Update camera position and rotation
        Vector3 desiredPosition = playerBody.position - playerBody.forward * distanceFromPlayer;
        transform.position = desiredPosition;
        transform.LookAt(playerBody); 
    }
}
