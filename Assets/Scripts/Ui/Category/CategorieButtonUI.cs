using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CategorieButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI categorieName;
    private InventoryManager inventoryManager;
    private void Start()
    {
        inventoryManager = InventoryManager.Instance;
    }

    public void SetCategorieButton(string categorie)
    {
        categorieName.text = categorie;
    }
    
    public void SetFontText(TMP_FontAsset font)
    {
        categorieName.font = font;
    }
    
    public void SetFontSize(float size)
    {
        categorieName.fontSize = size;
    }

    public void OnButtonClick()
    {
        transform.parent.GetComponent<CategorieButtonManager>().Reset();
        categorieName.fontStyle = FontStyles.Bold;

        inventoryManager.SelectedCategory = categorieName.text;
        inventoryManager.ListItemsByCategory();
        //LOAD CATEGORIE ICI
    }


}
