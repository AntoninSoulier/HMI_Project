using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Description : MonoBehaviour,IPointerClickHandler
{
    public static GameObject Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = gameObject;
        gameObject.SetActive(false);
    }

    void Start()
    {
        //gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Left){
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


