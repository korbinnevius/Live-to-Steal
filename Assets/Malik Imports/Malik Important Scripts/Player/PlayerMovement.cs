using System.Collections;
using System.Collections.Generic;
using TiltFive;
using UnityEngine;
using Input = UnityEngine.Input;

//using Input = TiltFive.Input;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public GameObject _player;
    public bool canMove;
    private Rigidbody _rigidbody;
    private CharacterController cc;
    
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        cc = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // // When the player moves the joystick, their character will walk in that direction times the movement speed and 
        // // time.
        //
        // if (canMove && TiltFive.Input.TryGetStickTilt(out Vector2 joystick, TiltFive.ControllerIndex.Right,
        //         TiltFive.PlayerIndex.One))
        // {
        //     _player.transform.Translate(joystick.x * Time.deltaTime * movementSpeed, 0.0f,
        //         joystick.y * Time.deltaTime * movementSpeed);
        //     
        //     
        // }

        if (canMove)
        {
            float hAxis = Input.GetAxis("Horizontal");
            float zAxis = Input.GetAxis("Vertical");
        
            Vector3 movement = new Vector3(hAxis,0,zAxis) * (movementSpeed * Time.deltaTime);
            cc.Move(movement);
        }
        
        
    }
    
}
