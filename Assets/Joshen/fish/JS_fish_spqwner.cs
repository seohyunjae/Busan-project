using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_fish_spqwner : MonoBehaviour
{
    public GameObject fishobj;

    public int spawn_count;
   


   
    public void fish_spawn()
    {
     
        for (int i = 0; i < spawn_count; i++) 
        {
            Instantiate(fishobj, this.gameObject.transform.position, Quaternion.identity);
        }
    }


   
}

