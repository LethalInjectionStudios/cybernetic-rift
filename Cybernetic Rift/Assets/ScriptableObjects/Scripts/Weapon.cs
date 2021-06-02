using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Weapon")]
public class Weapon : BaseItem
{
    public override void Interact()
    {
        Debug.Log("Weapon Used");
    }

    public override void UIInteract()
    {
        throw new System.NotImplementedException();
    }
}
 