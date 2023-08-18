using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_elevator_controller : MonoBehaviour
{
    [SerializeField]
    Animator ani;

    public void up()
    {
        ani.SetTrigger("UPUP");   

    }
    public void down()
    {
        ani.SetTrigger("DWDW");
    }
    public void open()
    {
        ani.SetTrigger("open");
    }
}
