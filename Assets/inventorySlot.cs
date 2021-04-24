using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventorySlot : MonoBehaviour
{
    Item Item;
    public Image icon;
    public void AddItem (Item newItem)
    {
        Item = newItem;
        icon.sprite = Item.image;
        icon.enabled = true;
    }
    public void ClearSlot ()
    {
        Item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
