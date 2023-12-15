using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private GameObject _invisibleexitbarrier;

    // There is a barrier blocking the exit at the bgeinning of the game. Once the player collects the money, the barrier
    // will be set as false and the player will be able to exit the bank effectively winning the game.
    private void Start()
    {
        _invisibleexitbarrier.SetActive(true);
    }

    private void OnTriggerEnter(Collider col)
    {
        PlayerInventory playerInventory = col.GetComponent<PlayerInventory>();
        
        if (playerInventory != null)
        {
            Debug.Log("I have made contact");
            playerInventory.FruitsCollected();
            gameObject.SetActive(false);
            _invisibleexitbarrier.SetActive(false);
        }
    }
}
