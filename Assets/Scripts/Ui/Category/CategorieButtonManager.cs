using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CategorieButtonManager : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(ExecuteAfterTime(1));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        foreach (Transform button in transform)
        {
            foreach (Transform buttonComponent in button.transform)
            {
                if(buttonComponent.name == "CategorieName")
                {
                    buttonComponent.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                }
                
            }
        }
    }

    public void Reset()
    {
        foreach (Transform button in transform)
        {
            foreach (Transform buttonComponent in button.transform)
            {
                if (buttonComponent.name == "CategorieName")
                {
                    buttonComponent.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                }

            }
        }
    }
}
