using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region 
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than an instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    public List<Item> inventoryItems = new List<Item>();
    public int space = 30;
    public bool AddItem(Item item)
    {
        if (item != null)
        {
            if (inventoryItems.Count >= space)
            {
                Debug.Log("Inventory full");
                return false;
            }
            inventoryItems.Add(item);

        }
        return true;
    }

    public void RemoveItem(Item item)
    {
        if (item != null)
        {
            inventoryItems.Remove(item);
        }
    }
}
