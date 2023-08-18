using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    BasementKey,
    Spanner,
    Valve,
    Hammer,
    Screwdriver,
    MedKit
}

public class Item
{
    ItemType type;

    public ItemType Type
    {
        get { return type; }
    }

    public Item(ItemType itemType)
    {
        type = itemType;
    }
}
