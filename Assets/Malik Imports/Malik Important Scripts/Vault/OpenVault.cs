using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVault : MonoBehaviour
{
   [SerializeField] private GameObject _vault;   
    
    // Start is called before the first frame update
    void Start()
    {
        _vault.SetActive(true);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Keycard"))
        {
            _vault.SetActive(false);
            Debug.Log("I made contact with the player");
        }
    }
    
}
