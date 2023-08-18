using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_elevator_door : MonoBehaviour
{
    [SerializeField]
    Animator ani;
   public void open()
    {
        ani.SetTrigger("open");
    }

    
}
