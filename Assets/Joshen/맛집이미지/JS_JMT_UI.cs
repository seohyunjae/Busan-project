using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_JMT_UI : MonoBehaviour
{
    [SerializeField]
    GameObject main;
    [SerializeField]
    GameObject menu1;
    [SerializeField]
    GameObject menu2;
    [SerializeField]
    GameObject menu3;
    [SerializeField]
    GameObject menu4;

   

    public void menu1_ck()
    {
        main.SetActive(false);
        menu1.SetActive(true);
    }
    public void menu2_ck()
    {
        main.SetActive(false);
        menu2.SetActive(true);
    }
    public void menu3_ck() 
    {
        main.SetActive(false);
        menu3.SetActive(true);
    }  
    public void menu4_ck() 
    {
        main.SetActive(false);
        menu4.SetActive(true);
    }
    public void back_main()
    {
        main.SetActive(true);
        menu1.SetActive(false);
        menu2.SetActive(false);
        menu3.SetActive(false);
        menu4.SetActive(false);
    }

    public void ui_open()
    {
        this.gameObject.SetActive(true);
    }
    public void ui_close()
    {
        this.gameObject.SetActive(false);
    }
}
