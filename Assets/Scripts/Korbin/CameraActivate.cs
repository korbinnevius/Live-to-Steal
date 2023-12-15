using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;
using Input = UnityEngine.Input;

public class CameraActivate : MonoBehaviour
{

    public GameObject CameraLayoutPrefab;
    public TiltFive.Input.WandButton interactButton;
    private bool isCollided = false;
   // [SerializeField] private GameObject _securityGuardOne;

    public bool IsCollided => isCollided;
    
    
    void Start()
    {
       // _securityGuardOne.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if that boolean is true and the input is pressed the cams turn on  
        if (isCollided && TiltFive.Input.GetButtonDown(interactButton, ControllerIndex.Right, PlayerIndex.One) || isCollided && Input.GetKeyDown(KeyCode.Space))
        {
            CameraLayoutPrefab.SetActive(true);
           // _securityGuardOne.SetActive(true);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //triggers only once
        if (CameraLayoutPrefab.activeInHierarchy == false)
        {
            //makes a boolean that stays true instead being frame specific
            if (other.gameObject.CompareTag("Interactable"))
            {
                isCollided = true;
                Debug.Log("Collided");
            }
        }
    }
}
