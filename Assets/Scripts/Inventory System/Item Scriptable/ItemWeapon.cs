using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Item", menuName = "Inventory System/Item/Weapon Item", order = 0)]
public class ItemWeapon : ItemDefault
{
    [field: SerializeField] protected float attackPoints;
    public float AttackPoints
    {
        get => attackPoints;
        set => attackPoints = value;
    }
    public enum WeaponType { Sword, Arc, Spear};
    [field: SerializeField] protected WeaponType weaponType;
    public WeaponType TypeWeapon
    {
        get => weaponType;
        set => weaponType = value;
    }
    public ItemWeapon()
    {
        itemCategory = CategoryItem.Weapon;
        isUnique = true;
    }
}
