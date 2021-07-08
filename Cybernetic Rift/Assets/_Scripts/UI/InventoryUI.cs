using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private List<BaseItem> _playerInventory;
    private GameObject _inventorySlots;
    private InventorySlot _inventorySlot;

    private void OnEnable() 
    {
        _inventorySlots = GameObject.FindGameObjectWithTag("InventorySlots");
        _playerInventory = null;
        ClearUI();
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().GetInventory();
        PopulateInventory();
    }
    private void PopulateInventory()
    {
        foreach(BaseItem item in _playerInventory)
        {
            InventorySlot slot = Instantiate(_inventorySlot);
            slot.transform.SetParent(_inventorySlots.transform);
            slot.LoadData(item);           
        }
    }

    private void ClearUI()
    {
        foreach(Transform child in _inventorySlots.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void UpdateUI()
    {
        ClearUI();
        PopulateInventory();
    }
}
