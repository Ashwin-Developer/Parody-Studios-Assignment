using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private GravityManager _gravityState;
    private Animator _animator;

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
        //Animation
        if(rb.velocity.sqrMagnitude > 0)
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

        switch (_gravityState.CurrentState)
        {
            case GravityState.Up:
                movement = new Vector3(moveHorizontal, 0, -moveVertical) * moveSpeed;
                rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
                break;
            case GravityState.Down:
                movement = new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed;
                rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
                break;
            case GravityState.Right:
                movement = new Vector3(0, moveHorizontal, moveVertical) * moveSpeed;
                rb.velocity = new Vector3(rb.velocity.x, movement.y, movement.z);
                break;
            case GravityState.Left:
                movement = new Vector3(0, -moveHorizontal, moveVertical) * moveSpeed;
                rb.velocity = new Vector3(rb.velocity.x, movement.y, movement.z);
                break;
        }
    }
}
