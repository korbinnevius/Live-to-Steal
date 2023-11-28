using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LazerMovement : MonoBehaviour
{
    public float amp;
    public float freq;
    private Vector3 initPos;
    void Start()
    {
        //Get the initial position of the lazer
        initPos = transform.position;
    }
    
    void Update()
    {
        //Moves the lazer up and down vertically.
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, initPos.z);
    }
}
