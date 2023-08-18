using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_Path : MonoBehaviour
{
    public JS_EXPO_Bus expo_bus;
    public GameObject bus;
    Transform nowpos;
    public Transform nexpos;

    
    private void Update()
    {
        if(bus.transform.position==gameObject.transform.position)
        {
            nowpos.transform.position = gameObject.transform.position;
            //expo_bus.movetonextpos(nowpos, nexpos);
        }
    }



}
