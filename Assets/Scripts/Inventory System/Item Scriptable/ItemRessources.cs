using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Item/Ressource Item", order = 0)]
public class ItemRessources : ItemDefault
{
    public ItemRessources()
    {
        itemCategory = CategoryItem.Resources;
        isUnique = false;
    }
}
