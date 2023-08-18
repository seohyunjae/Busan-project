using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_Drone_show_controll : MonoBehaviour
{
    Animator drone_ani;

    private void Start()
    {
        drone_ani = GetComponent<Animator>();
    }

    public void drone_show_Start()
    {
        this.gameObject.SetActive(true);
        //  drone_ani.SetTrigger("dron_full_show");
    }

    public void drone_show_End()
    {
        this.gameObject.SetActive(false);
    }
}
