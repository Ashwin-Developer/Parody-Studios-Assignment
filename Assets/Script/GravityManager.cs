using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityState
{
    Up,
    Down, 
    Left, 
    Right
}
public class GravityManager : MonoBehaviour
{
    public static GravityManager instance;
    public GravityState CurrentState;

    private static readonly Vector3 _gravityUpVector = new Vector3(0, 9.8f, 0);
    private static readonly Vector3 _gravityDownVector = new Vector3(0, -9.8f, 0);
    private static readonly Vector3 _gravityLeftVector = new Vector3(-9.8f, 0, 0);
    private static readonly Vector3 _gravityRightVector = new Vector3(9.8f, 0, 0);

    [SerializeField] private Transform _player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Gravity Left"))
        {
            ChangeGravity(_gravityLeftVector, "Left arrow clicked", new Vector3(0, 0, -90), GravityState.Left);
        }
        else if (Input.GetButtonDown("Gravity Right"))
        {
            ChangeGravity(_gravityRightVector, "Right arrow clicked", new Vector3(0, 0, 90), GravityState.Right);
        }
        else if (Input.GetButtonDown("Gravity Up"))
        {
            ChangeGravity(_gravityUpVector, "Up arrow clicked", new Vector3(180, 0, 0), GravityState.Up);
        }
        else if (Input.GetButtonDown("Gravity Down"))
        {
            ChangeGravity(_gravityDownVector, "Down arrow clicked", Vector3.zero, GravityState.Down);
        }
    }

    private void ChangeGravity(Vector3 gravityVector, string message, Vector3 rotation, GravityState state)
    {
        Physics.gravity = gravityVector;
        Debug.Log(message);
        _player.rotation = Quaternion.Euler(rotation);
        CurrentState = state;
    }

}
