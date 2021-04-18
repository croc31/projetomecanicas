using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    public void Drop()
    {
        Debug.Log(" Dropado ");
    }

    public void Pickup()
    { 
        Debug.Log(item.name +" Pegado ");
        if (Inventory.instance.AddItem(item))
        {
            Destroy(gameObject);
        }
    } 
}
