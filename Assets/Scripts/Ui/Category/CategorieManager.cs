using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class CategorieManager : MonoBehaviour
{
    [SerializeField] private GameObject categorieButton;
    [SerializeField] private Transform categorieButtonParent;
    [SerializeField] private TMP_FontAsset font;
    [SerializeField] private float fontSize = 15;


    private void Start()
    {
        GenerateButtons();
    }

    private void GenerateButtons()
    {
        foreach (string categorie in Enum.GetNames(typeof(ItemBase.CategoryItem)))
        {
            GameObject button = Instantiate(categorieButton, categorieButtonParent);
            CategorieButtonUI categorieButtonUI = button.GetComponent<CategorieButtonUI>();
            categorieButtonUI.SetCategorieButton(categorie);
            categorieButtonUI.SetFontText(font);
            categorieButtonUI.SetFontSize(fontSize);
        }
    }


}
