using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private TextMeshProUGUI fruitText;
    // Start is called before the first frame update
    void Start()
    {
        fruitText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateFruitText(PlayerInventory playerInventory)
    {
        fruitText.text = playerInventory.NumberOfItems.ToString();
    }
}
