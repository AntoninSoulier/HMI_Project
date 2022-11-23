using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotEquipedScript : MonoBehaviour, IPointerClickHandler
{
    public enum EquipedItem
    {
        EquipedHelmet,
        EquipedChest,
        EquipedBoots,
        EquipedWeapon
    };

    private EquipedItem equipedItem;

    // Start is called before the first frame update
    void Start()
    {
        equipedItem = ParseEnum<EquipedItem>(transform.parent.name);
    }
    
    public static T ParseEnum<T>(string value)
    {
        return (T) Enum.Parse(typeof(T), value, true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            InventoryManager.Instance.DesequipItem(equipedItem);
            gameObject.SetActive(false);
        }
    }
}
