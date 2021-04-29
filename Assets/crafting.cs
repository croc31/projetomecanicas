using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crafting : MonoBehaviour
{
    public Recipe recipe;
    public SecondInventory inve;
    private Inventory inventory;

    public void Start()
    {
        inventory = Inventory.instance;
    }
    public void TryCraft()
    {
        bool it1 = false, it2 = false;
        
        if (recipe != null ) {
            Debug.Log("tá indo");
            for (int i = 0; i < inventory.inventoryItems.Count; ++i)
            {
                if (!it1)
                {
                    if (inventory.inventoryItems[i].name.Equals(recipe.item1.name))
                    {
                        it1 = true;
                    }
                    
                }
                else
                {
                    if (inventory.inventoryItems[i].name.Equals(recipe.item2.name))
                    {
                        it2 = true;
                    }
                }
                Debug.Log(inventory.inventoryItems[i].name + " " + recipe.item1.name);
                
            }
        }
        if (it1 && it2)
        {
            Craft();
            Debug.Log("Achou");
        }
        Debug.Log("Tentou");
    }

    private void Craft()
    {
        bool it1 = false;
        for (int i = 0; i <= inventory.inventoryItems.Count; ++i)
        {
            if (!it1)
            {
                if (inventory.inventoryItems[i].name == recipe.item1.name)
                {
                    inventory.inventoryItems.RemoveAt(i);
                    --i;
                    it1 = true;
                }

            }
            else
            {
                if (inventory.inventoryItems[i].name == recipe.item2.name)
                {
                    inventory.inventoryItems.RemoveAt(i);
                    break;
                }
            }

        }
        inventory.AddItem(recipe.result);
        inve.UpdateUI();
    }
}
