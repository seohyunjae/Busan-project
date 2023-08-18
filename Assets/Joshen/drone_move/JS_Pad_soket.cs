using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_Pad_soket : MonoBehaviour
{
    [SerializeField]
    GameObject Pad_controller;
    


  


    public void Pad_on()
    {
        Pad_controller.SetActive(true);
        
    }
    public void Pad_off()
    {
        Pad_controller.SetActive(false);
        
    }
}
