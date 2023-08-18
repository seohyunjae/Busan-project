using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_UI_actvie : MonoBehaviour
{
    public GameObject UI;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            UI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI.SetActive(false);
        }
    }
}
