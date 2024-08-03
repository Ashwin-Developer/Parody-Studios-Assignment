using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private GravityManager _gravityState;
    private Animator _animator;
    public Transform cameraTransform;  // Reference to the camera transform

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _gravityState = GravityManager.instance;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();

        Debug.Log(rb.velocity.sqrMagnitude);
        // Animation
        if (rb.velocity.sqrMagnitude > 0)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = Vector3.zero;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        
        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirectionXandZ = (forward * moveVertical + right * moveHorizontal).normalized * moveSpeed;
        Vector3 desiredMoveDirectionZandY = (forward * moveHorizontal + right * moveVertical).normalized * moveSpeed;


        switch (_gravityState.CurrentState)
        {
            case GravityState.Up:
                movement = new Vector3(desiredMoveDirectionXandZ.x, 0, desiredMoveDirectionXandZ.z);
                rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
                break;
            case GravityState.Down:
                movement = new Vector3(desiredMoveDirectionXandZ.x, 0, desiredMoveDirectionXandZ.z);
                rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
                break;
            case GravityState.Right:
                movement = new Vector3(0, -desiredMoveDirectionZandY.z, desiredMoveDirectionZandY.y);
                rb.velocity = new Vector3(rb.velocity.x, movement.y, movement.z);
                break;
            case GravityState.Left:
                movement = new Vector3(0, desiredMoveDirectionZandY.z, -desiredMoveDirectionZandY.y);
                rb.velocity = new Vector3(rb.velocity.x, movement.y, movement.z);
                break;
        }
    }
}