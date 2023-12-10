using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = UnityEngine.Input;

public class Tilt5Movement : MonoBehaviour

{
    public float speed = 5;
    public GameObject _player;
    private Rigidbody _rigidbody;
    private CharacterController cc;
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (TiltFive.Input.TryGetStickTilt(out Vector2 joystick, TiltFive.ControllerIndex.Right, TiltFive.PlayerIndex.One))
        {
            _player.transform.Translate(joystick.x * Time.deltaTime * speed, 0.0f, joystick.y * Time.deltaTime * speed);
        }
    }
}