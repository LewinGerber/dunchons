using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    string id = Guid.NewGuid().ToString();
    new public string name = "Item name";
    public Sprite sprite;


    public string GetId() {
        return id;
    }
    
}
