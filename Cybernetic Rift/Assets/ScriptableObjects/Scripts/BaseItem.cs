using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite sprite;
    public GameObject model;

    public abstract void Interact();

}
