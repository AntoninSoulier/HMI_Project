using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Item/Armor Item", order = 0)]
public class ItemArmor : ItemDefault
{
    public enum ArmorType { Boots, Helmet, Chest};
    [field: SerializeField] protected float armorPoints;
    public float ArmorPoints
    {
        get => armorPoints;
        set => armorPoints = value;
    }
    [field: SerializeField] protected ArmorType armorType;
    public ArmorType TypeArmor
    {
        get => armorType;
        set => armorType = value;
    }
    
    [field: SerializeField] protected float hpBonus;
    public float HpBonus
    {
        get => hpBonus;
        set => hpBonus = value;
    }
    public ItemArmor()
    {
        itemCategory = CategoryItem.Armor;
        isUnique = true;
    }


}
