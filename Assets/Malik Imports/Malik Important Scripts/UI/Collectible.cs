using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        PlayerInventory playerInventory = col.GetComponent<PlayerInventory>();
        
        if (playerInventory != null)
        {
            Debug.Log("I have made contact");
            playerInventory.FruitsCollected();
            gameObject.SetActive(false);
        }
    }
}
