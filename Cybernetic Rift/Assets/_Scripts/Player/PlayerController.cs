using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int _health = 100;
    private int _exp = 0;
    private BaseItem _equippedItem = null;

    public int Health
    {
        get{ return _health; }
    }

    public int Exp
    {
        get { return _exp; }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(_equippedItem != null)
            {
                _equippedItem.Interact();
            }            
        }
    }

    public void EquipItem(BaseItem item, EquippedItem itemObject)
    {
        _equippedItem = item;
    }
}
