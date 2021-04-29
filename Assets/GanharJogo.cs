using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanharJogo : MonoBehaviour
{
    private Inventory inventory;
    public Recipe recipe;
    public void Start()
    {
        inventory = Inventory.instance;
    }

    void Update()
    {

        bool it1 = false, it2 = false;
        if (recipe != null)
        {
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

            }
        }
        if (it1 && it2)
        {
            Ganhar();
        }
    }
    private void Ganhar()
    {

    }
}
