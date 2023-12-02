using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerInputScript : MonoBehaviour
{
    public CameraSystem _cameraSystem;
    // Start is called before the first frame update
    void Start()
    {
        _cameraSystem.GetComponent<CameraSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            _cameraSystem.NextCamera();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _cameraSystem.PreviousCamera();
        }

    }
}
