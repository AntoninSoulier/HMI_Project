using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionScript : MonoBehaviour, IPointerExitHandler
{
    public static InteractionScript  Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //print("exit intera");//gameObject.SetActive(false);
    }
}
