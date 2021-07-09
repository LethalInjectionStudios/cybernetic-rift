using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItem : MonoBehaviour
{
    private BaseItem _itemData;
    private BoxCollider _collider;

    void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(BaseItem item)
    {
        _itemData = item;
        SetupObject();
    }

    private void SetupObject()
    {
        GameObject itemModel = Instantiate(_itemData.model);
        itemModel.transform.position = transform.position;
        itemModel.transform.parent = transform;
    }
}
