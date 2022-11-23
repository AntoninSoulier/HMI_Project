using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private Item equipedHelmet;
    private Item equipedChest;
    private Item equipedBoots;
    private Item equipedWeapon;
    
    [SerializeField] private GameObject slotHelmet;
    [SerializeField] private GameObject slotChest;
    [SerializeField] private GameObject slotBoots;
    [SerializeField] private GameObject slotWeapon;

    [Serializable]
    public struct ItemCount {
        public Item item;
        public int nb;
        public ItemCount(Item item, int nb)
        {
            this.item = item;
            this.nb = nb;
        }
    }
    // id, number
    private Dictionary<String,ItemCount> _items = new Dictionary<String, ItemCount>();

    //[SerializeField] private GameObject boxItem;

    [SerializeField] private Transform itemContent;
    [SerializeField] private GameObject ItemBox;
    [SerializeField] private GameObject Inventory;
    [SerializeField] private GameObject StatItem;

    [SerializeField] private GameObject instructionsMenu;

    private TextMeshProUGUI textStatItem;
    [SerializeField]private TextMeshProUGUI textStatCharacter;
    public static InventoryManager Instance;
    public bool inventoryOpen;

    private String selectedCategory;  
    public String SelectedCategory { get => selectedCategory; set => selectedCategory = value; }
    
    private void Awake()
    {
        Instance = this;
        selectedCategory = ItemBase.CategoryItem.All.ToString();
    }
    // Start is called before the first frame update

    void Start()
    {
        textStatItem = StatItem.transform.Find("Text").GetComponent<TextMeshProUGUI>();

        textStatItem.text = "";
        textStatCharacter.text = "Total Hp : 0\n"
        +"Total Armor : 0\n"
        +"Attack : 0";
        ListItemsByCategory();

        inventoryOpen = Inventory.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryOpen = !inventoryOpen;
            Inventory.SetActive(!Inventory.activeSelf);
        }

        if (Input.GetMouseButtonDown(0))
        {
            //InteractionScript.Instance.gameObject.SetActive(false);
            if(Description.Instance is not null)
            {
                Description.Instance.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InteractionScript.Instance.gameObject.SetActive(false);
            Description.Instance.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            instructionsMenu.SetActive(!instructionsMenu.activeSelf);
        }
        
    }
    
    
    public void ListItemsByCategory()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var id in _items.Keys)
        {
            if (_items[id].item.itemData.ItemCategory.ToString() == selectedCategory 
                || selectedCategory.ToString() == ItemBase.CategoryItem.All.ToString())
            {
                GameObject obj = Instantiate(ItemBox, itemContent);
                TextMeshProUGUI itemName = obj.transform.Find("ItemIconeName").Find("ItemName").GetComponent<TextMeshProUGUI>();
                Image itemIcone = obj.transform.Find("ItemIconeName").Find("ItemIcone").GetComponent<Image>();

                Display display = obj.GetComponent<Display>();
                display.number = _items[id].nb;
                display.item = _items[id].item;

                itemName.text = _items[id].item.itemData.NameItem;
                itemIcone.sprite = _items[id].item.itemData.ImgSprite;
            }
        }
    }

    public void AddItem(string id, Item item)
    {
        if(item.itemData.IsUnique)
        {
            _items.Add(id, new ItemCount(item,1));
        }
        else
        {
            if (!_items.ContainsKey(id))
            {
                _items.Add(id, new ItemCount(item,1));
            }
            else
            {
                int cpt = _items[id].nb+1;
                _items.Remove(id);
                _items.Add(id,new ItemCount(item,cpt));  
            }
        }
        
        ListItemsByCategory();
    }

    public void DelItem(string id,Item item)
    {
        if (!_items.ContainsKey(id))
        {
            return;
        }

        if (_items[id].nb == 1)
        {
            _items.Remove(id);

        }
        else
        {
            int cpt = _items[id].nb - 1;
            _items.Remove(id);
            _items.Add(id,new ItemCount(item,cpt));  

        }

        ListItemsByCategory();
    }

    
    public void DelAllItemCpt(string id)
    {
        if (!_items.ContainsKey(id))
        {
            return;
        }
        _items.Remove(id);
        ListItemsByCategory();
    }

    public void EquipItem(String id)
    {
        if (_items.ContainsKey(id))
        {
            Item item = _items[id].item;
            if (item.itemData.ItemCategory != ItemBase.CategoryItem.Armor &&
                item.itemData.ItemCategory != ItemBase.CategoryItem.Weapon)
            {
                return;
            }
            this.DelAllItemCpt(id);
            if (item.itemData.ItemCategory == ItemBase.CategoryItem.Weapon)
            {
                if (equipedWeapon is not null)
                {
                    AddItem(equipedWeapon.ID,equipedWeapon);
                }
                equipedWeapon = item;
                slotWeapon.GetComponent<Image>().sprite = item.itemData.ImgSprite;
                slotWeapon.SetActive(true);
            }
            else if (item.itemData.ItemCategory == ItemBase.CategoryItem.Armor)
            {
                ItemArmor itemData = (ItemArmor)item.itemData;
                if (itemData.TypeArmor == ItemArmor.ArmorType.Boots)
                {
                    if (equipedBoots is not null)
                    {
                        AddItem(equipedBoots.ID,equipedBoots);
                    }
                    equipedBoots = item;
                    slotBoots.GetComponent<Image>().sprite = item.itemData.ImgSprite;
                    slotBoots.SetActive(true);
                }
                else if (itemData.TypeArmor == ItemArmor.ArmorType.Chest)
                {
                    if (equipedChest is not null)
                    {
                        AddItem(equipedChest.ID,equipedChest);
                    }
                    equipedChest = item;
                    slotChest.GetComponent<Image>().sprite = item.itemData.ImgSprite;
                    slotChest.SetActive(true);
                }
                else if (itemData.TypeArmor == ItemArmor.ArmorType.Helmet)
                {
                    if (equipedHelmet is not null)
                    {
                        AddItem(equipedHelmet.ID,equipedHelmet);
                    }
                    equipedHelmet = item;
                    slotHelmet.GetComponent<Image>().sprite = item.itemData.ImgSprite;
                    slotHelmet.SetActive(true);
                }
            }
        }

        UpdateStatCharacter();
    }

    public void showEquipedItems()
    {
        List<Item> itemsEquiped = new List<Item>();
        itemsEquiped.Add(equipedBoots);
        itemsEquiped.Add(equipedChest);
        itemsEquiped.Add(equipedHelmet);
        itemsEquiped.Add(equipedWeapon);

        if (equipedBoots)
        {
            //slotBoots
        }

    }

    public void DesequipItem(SlotEquipedScript.EquipedItem equipedItem)
    {
        if (equipedItem == SlotEquipedScript.EquipedItem.EquipedBoots)
        {
            AddItem(equipedBoots.ID,equipedBoots);
            equipedBoots = null;
        }
        else if (equipedItem == SlotEquipedScript.EquipedItem.EquipedChest)
        {
            AddItem(equipedChest.ID,equipedChest);
            equipedChest = null;  
        }
        else if (equipedItem == SlotEquipedScript.EquipedItem.EquipedHelmet)
        {
            AddItem(equipedHelmet.ID,equipedHelmet);
            equipedHelmet = null;
        }
        else if (equipedItem == SlotEquipedScript.EquipedItem.EquipedWeapon)
        {
            AddItem(equipedWeapon.ID,equipedWeapon);
            equipedWeapon = null;
        }

        UpdateStatCharacter();
    }

    public int getNumberItem(string id, ItemBase item)
    {
        if (_items.ContainsKey(id))
        {
            return _items[id].nb;
        }
        return 0;
    }

    public void UpdateStatCharacter()
    {
        float hp = 0;
        float attack = 0;        
        float armor = 0;

        String text = "";
        if (equipedHelmet is not null)
        {
            ItemArmor statHelmet = (ItemArmor)equipedHelmet.itemData;
            hp += statHelmet.HpBonus;
            armor += statHelmet.ArmorPoints;
        }
        if (equipedChest is not null)
        {
            ItemArmor statChest = (ItemArmor)equipedChest.itemData;
            hp += statChest.HpBonus;
            armor += statChest.ArmorPoints;
        }
        if (equipedBoots is not null)
        {
            ItemArmor statBoots = (ItemArmor)equipedBoots.itemData;
            hp += statBoots.HpBonus;
            armor += statBoots.ArmorPoints;
        }
        if (equipedWeapon is not null)
        {
            ItemWeapon statWeapon = (ItemWeapon)equipedWeapon.itemData;
            attack += statWeapon.AttackPoints;
        }

        text = "Total Hp : " + hp + "\n"
               + "Total Armor : " + armor+"\n"
               + "Attack : "+attack;


        textStatCharacter.text = text;
    }
    public void showStatItem(string id)
    {
        if (_items.ContainsKey(id))
        {
            
            if (_items[id].item.itemData is ItemWeapon)
            {
                ItemWeapon obj = (ItemWeapon)_items[id].item.itemData;
                textStatItem = StatItem.transform.Find("Text").GetComponent<TextMeshProUGUI>();
                textStatItem.text = obj.TypeWeapon+"\n";
                textStatItem.text += "<b>ATK</b> : "+obj.AttackPoints;
            }
            else if (_items[id].item.itemData is ItemArmor)
            {
                ItemArmor obj = (ItemArmor)_items[id].item.itemData;

                textStatItem.text = obj.TypeArmor+"\n";
                textStatItem.text += "<b>HP</b> : "+ obj.HpBonus;
                textStatItem.text += "\n<b>ARMOR</b> : "+obj.ArmorPoints;
            }
            else
            {
                textStatItem.text = "";
            }

        }
    }

    public String getDescriptionText(String id)
    {
        String text = "";
        if (_items.ContainsKey(id))
        {
            String color = "white";
            ItemBase itemData = _items[id].item.itemData;
            if (itemData.Rarity == ItemBase.RarityItem.Basic)
            {
                color = "green";
            }
            else if (itemData.Rarity == ItemBase.RarityItem.Rare)
            {
                color = "blue";
            }
            else if (itemData.Rarity == ItemBase.RarityItem.Epic)
            {
                color = "purple";
            }
            else if (itemData.Rarity == ItemBase.RarityItem.Legendary)
            {
                color = "yellow";
            }
            text += "<b><color="+color+">"+itemData.Rarity+"</color>";
            text+="\n<size=85%><u>Description :</u></b></size>\n";
            text += "<size=70%>"+itemData.Description+"</size>";
        }

        return text;
    }
}
