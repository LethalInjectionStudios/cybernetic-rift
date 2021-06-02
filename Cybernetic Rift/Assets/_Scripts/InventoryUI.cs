using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private List<BaseItem> _playerInventory;

    private void Awake() 
    {
        _playerInventory = null;
        ClearUI();
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().inventory;
    }

    private void ClearUI()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
