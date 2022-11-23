using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Display : MonoBehaviour, IPointerClickHandler
{
    private GameObject description;
    public Item item;
    public Image image;
    public GameObject counter;
    public TextMeshProUGUI TextNumber;
    public int number;
    public Transform descriptionPosition;
    private float offsetBottom;

    public void Start()
    {
        description = Description.Instance.gameObject;
        TextNumber = counter.transform.Find("Number").GetComponent<TextMeshProUGUI>();
        TextNumber.text = number.ToString();
    }


    public void OnPointerClick(PointerEventData eventData){
        if (eventData.button == PointerEventData.InputButton.Left &&
            eventData.clickCount == 2) {
            InventoryManager.Instance.EquipItem(item.ID);
                description.SetActive(false);
        }
        else if(eventData.button == PointerEventData.InputButton.Right){
            description.SetActive(true);
            description.GetComponentInChildren<TMPro.TextMeshProUGUI>().text=InventoryManager.Instance.getDescriptionText(item.ID);
            AdaptPosition();
            InventoryManager.Instance.showStatItem(item.ID);
        }
    } 

    public void AdaptPosition(){
        Vector3 im = this.GetComponent<RectTransform>().anchoredPosition;
        im = transform.position;
        description.transform.position = descriptionPosition.position;
    }

    public void Update(){
    }
    

    public void DeleteItem()
    {
        InventoryManager.Instance.DelAllItemCpt(item.ID);
        Destroy(gameObject);
    }
}
