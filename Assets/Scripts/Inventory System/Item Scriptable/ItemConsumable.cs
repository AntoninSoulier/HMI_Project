using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Item/Consumable Item", order = 0)]
public class ItemConsumable : ItemDefault
{
    public ItemConsumable()
    {
        itemCategory = CategoryItem.Consumable;
        isUnique = false;
    }
}
