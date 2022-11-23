using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Item/Other Item", order = 0)]
public class ItemOthers : ItemDefault
{
    public ItemOthers()
    {
        itemCategory = CategoryItem.Others;
        isUnique = false;
    }
}
