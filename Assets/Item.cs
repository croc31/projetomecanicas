using UnityEngine;

[CreateAssetMenu (fileName = "New item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name;
    public Sprite image;
    public string descriptioin;

}
