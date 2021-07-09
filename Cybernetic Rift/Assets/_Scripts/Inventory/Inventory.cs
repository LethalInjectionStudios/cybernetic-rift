using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<BaseItem> _inventory = new List<BaseItem>();

    public void RemoveItem(BaseItem item) => _inventory.Remove(item);
    

    public void AddItem(BaseItem item) => _inventory.Add(item);

    public List<BaseItem> GetInventory() => _inventory;
    
}
