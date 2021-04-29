using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondInventory : MonoBehaviour
{
    public Transform itemParent;
    protected inventorySlot[] slots;
    Inventory inventory;
    void Start()
    {

        inventory = Inventory.instance;
        slots = itemParent.GetComponentsInChildren<inventorySlot>();
        
    }

    public void UpdateUI()
    {
        if (slots != null)
        {
            for (int i = 0; i < slots.Length; ++i)
            {
                if (i < inventory.inventoryItems.Count && inventory.inventoryItems[i] != null)
                {
                    slots[i].AddItem(inventory.inventoryItems[i]);
                }
                else
                {
                    slots[i].ClearSlot();
                }
            }
        }
    }


}
