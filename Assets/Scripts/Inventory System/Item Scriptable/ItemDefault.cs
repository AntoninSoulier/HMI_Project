using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Item/Default Item", order = 0)]
public class ItemDefault : ItemBase
{
    public ItemDefault()
    {
        itemCategory = CategoryItem.All;
    }
}
