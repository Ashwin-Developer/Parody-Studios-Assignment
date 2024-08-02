using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private GravityManager _gravityState;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _gravityState = GravityManager.instance;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {

        if (_gravityState.CurrentState == GravityState.Up)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, -moveVertical) * moveSpeed;
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }

        else if (_gravityState.CurrentState == GravityState.Down)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed;
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }

        else if (_gravityState.CurrentState == GravityState.Right)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(0, moveHorizontal, moveVertical) * moveSpeed;
            rb.velocity = new Vector3(rb.velocity.x, movement.y, movement.z);
        }

        else if (_gravityState.CurrentState == GravityState.Left)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(0, -moveHorizontal, moveVertical) * moveSpeed;
            rb.velocity = new Vector3(rb.velocity.x, movement.y, movement.z);
        }


    }
}
