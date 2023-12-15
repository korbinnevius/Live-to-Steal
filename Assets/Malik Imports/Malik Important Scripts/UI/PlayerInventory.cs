using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    // This script is responsible for collecting the gold.
    public int NumberOfItems { get; private set; }
    
    public UnityEvent<PlayerInventory> OnItemsCollected;
    
    
    
    public void FruitsCollected()
    {
        NumberOfItems++;
        OnItemsCollected.Invoke(this);
    
    }
}
