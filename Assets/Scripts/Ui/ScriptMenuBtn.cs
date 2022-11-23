using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMenuBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCloseMenu(GameObject menu)
    {
        menu.SetActive(!menu.activeSelf);
    }
}
