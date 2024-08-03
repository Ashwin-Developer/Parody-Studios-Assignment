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
    private GravityManager _gravityManager;

    void Start()
    {
        _gravityManager = GravityManager.instance;
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

        Quaternion gravityRotation = Quaternion.identity;

        switch (_gravityManager.CurrentState)
        {
            case GravityState.Up:
                gravityRotation = Quaternion.Euler(0f, 0f, 180f);
                break;
            case GravityState.Down:
                gravityRotation = Quaternion.Euler(0f, 0f, 0f);
                break;
            case GravityState.Left:
                gravityRotation = Quaternion.Euler(0f, 0f, -90f);
                break;
            case GravityState.Right:
                gravityRotation = Quaternion.Euler(0f, 0f, 90f);
                break;
        }

        playerBody.rotation = gravityRotation * Quaternion.Euler(0f, yRotation, 0f);
    }
}
