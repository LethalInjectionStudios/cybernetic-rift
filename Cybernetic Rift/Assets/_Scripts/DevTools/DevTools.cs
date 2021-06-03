using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTools : MonoBehaviour
{
    public List<BaseItem> itemDB = new List<BaseItem>();
    public Pickup pickupPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Pickup pickup = Instantiate(pickupPrefab);
            pickup.transform.position = new Vector3(0,0.5f,0);
            int rand = Random.Range(0,2);
            pickup.LoadData(itemDB[rand]);
        }
    }
}
