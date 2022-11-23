using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : ScriptableObject
{
    public enum CategoryItem { All, Armor, Consumable, Others, Resources, Trophy, Weapon};
    public enum RarityItem { Common, Basic, Rare, Epic, Legendary};

    [field: SerializeField] protected CategoryItem itemCategory;
    public CategoryItem ItemCategory { get => itemCategory; set => itemCategory = value; }
    
    [field: SerializeField] protected String nameItem;
    public string NameItem { get => nameItem; set => nameItem = value; }

    [field: SerializeField] protected RarityItem rarity;
    public RarityItem Rarity { get => rarity; set => rarity = value; }
    [TextArea]
    [field: SerializeField] protected String description;
    public String Description
    {
        get => description;
        set => description = value;
    }
    [field: SerializeField] protected bool isUnique;
    public bool IsUnique
    {
        get => isUnique;
        set => isUnique = value;
    }
    
    [field: SerializeField] protected Sprite imgSprite;
    public Sprite ImgSprite
    {
        get => imgSprite;
        set => imgSprite = value;
    }
    [field: SerializeField] protected String id;
    public String  ID { get => id; set => id = value; }

}
