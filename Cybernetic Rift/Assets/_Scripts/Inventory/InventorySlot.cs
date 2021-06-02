using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private BaseItem _itemData;
    private InventoryUI _inventoryUI;
    [SerializeField] private Pickup pickupPrefab;
    //[SerializeField] private ItemDescriptionWindow descriptionWindow;

    private void Start() 
    {
        _inventoryUI = GetComponentInParent<InventoryUI>();
    }

    public void RemoveItem()
    {
        Pickup droppedItem = Instantiate(pickupPrefab);
        droppedItem.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(5,0,0);
        droppedItem.LoadData(_itemData);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().RemoveItem(_itemData);
        _inventoryUI.UpdateUI();
    }

    public void LoadData(BaseItem item)
    {
        _itemData = item;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
         
    }

    public void OnPointerExit(PointerEventData eventData)
    {
         
    }
}
