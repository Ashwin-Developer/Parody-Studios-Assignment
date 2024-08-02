using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    private static readonly Vector3 _gravityUpVector = new Vector3(0, 9.8f, 0);
    private static readonly Vector3 _gravityDownVector = new Vector3(0, -9.8f, 0);
    private static readonly Vector3 _gravityLeftVector = new Vector3(-9.8f, 0, 0);
    private static readonly Vector3 _gravityRightVector = new Vector3(9.8f, 0, 0);

    [SerializeField] private Transform _player;

    void Update()
    {
        if (Input.GetButtonDown("Gravity Left"))
        {
            ChangeGravity(_gravityLeftVector, "Left arrow clicked");
            Vector3 rotation =  new Vector3(0, 0, -90);
            _player.rotation = Quaternion.Euler(rotation);
        }
        else if (Input.GetButtonDown("Gravity Right"))
        {
            ChangeGravity(_gravityRightVector, "Right arrow clicked");
            Vector3 rotation = new Vector3(0, 0, 90);
            _player.rotation = Quaternion.Euler(rotation);
        }
        else if (Input.GetButtonDown("Gravity Up"))
        {
            ChangeGravity(_gravityUpVector, "Up arrow clicked");
            Vector3 rotation = new Vector3(180, 0, 0);
            _player.rotation = Quaternion.Euler(rotation);
        }
        else if (Input.GetButtonDown("Gravity Down"))
        {
            ChangeGravity(_gravityDownVector, "Down arrow clicked");
            Vector3 rotation = new Vector3(0, 0, 0);
            _player.rotation = Quaternion.Euler(rotation);
        }
    }

    private void ChangeGravity(Vector3 gravityVector, string message)
    {
        Physics.gravity = gravityVector;
        Debug.Log(message);
    }

}
