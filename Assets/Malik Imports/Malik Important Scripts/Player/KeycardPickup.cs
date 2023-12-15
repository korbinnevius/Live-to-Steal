using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardPickup : MonoBehaviour
{
    [SerializeField] private GameObject _keyCard;
    [SerializeField] private bool isPickup =false;

    private void Update()
    {
    // If the player collides with the gameobject tagged keycard, set the player gameobject as the parent of the gameobject
    // tagged keycard.
        if (isPickup)
        {
            _keyCard.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Keycard"))
        {
            isPickup = true;
            Debug.Log("I made contact with the player");
        }
        
    }
}
