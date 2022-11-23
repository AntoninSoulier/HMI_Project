using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Trophy Item", menuName = "Inventory System/Item/Trophy Item", order = 0)]
public class ItemTrophy : ItemDefault
{
    public ItemTrophy()
    {
        itemCategory = CategoryItem.Trophy;
        isUnique = true;
    }
}
