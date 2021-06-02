using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject _inventoryUI;
    private bool isUIActive = false;
    
    void Start()
    {
        _inventoryUI = GameObject.FindGameObjectWithTag("InventoryUI");
        _inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            _inventoryUI.SetActive(!_inventoryUI.activeSelf);
            isUIActive = !isUIActive;        
        }

        if(isUIActive)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;   
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;  
        }

    }

    public void OnBtnClck()
    {
        Debug.Log("Click!");
    }
      
}
