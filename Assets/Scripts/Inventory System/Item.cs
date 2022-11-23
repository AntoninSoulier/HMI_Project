using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemDefault itemData;

    private bool isEquipped;
    [field: SerializeField] protected String id;
    public String  ID { get => id; set => id = value; }
    public bool IsEquipped
    {
        get => isEquipped;
        set => isEquipped = value;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (itemData.IsUnique)
        {
            id = Guid.NewGuid().ToString();
        }
        else
        {
            id = itemData.ID;
        }
        
    }
    
    void Pickup()
    {
        GameObject inventory;
        inventory = GameObject.FindWithTag("InventoryTag");
        bool allowedToPickup = inventory.GetComponent<InventoryManager>().inventoryOpen;
        if (!allowedToPickup)
        {
            InventoryManager.Instance.AddItem(id, this);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Pickup();
    }
    
}
