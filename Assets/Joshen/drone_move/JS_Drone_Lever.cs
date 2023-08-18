using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_Drone_Lever : MonoBehaviour
{
    public JS_Drone_controller drone;

    public GameObject front;
    public GameObject back;
    public GameObject left;
    public GameObject right;

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == front)
        {
            Debug.Log("레버 앞감지");
            drone.front();
        }
        if (collision.gameObject == back)
        {
            drone.back();
        }
        if (collision.gameObject == left)
        {
            drone.left_turn();
        }
        if (collision.gameObject == right)
        {
            drone.right_turn();
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == front)
        {
           
            drone.front_exit();
        }
        if (collision.gameObject == back)
        {
            drone.back_exit();
        }
        if (collision.gameObject == left)
        {
            drone.left_turn_off();
        }
        if (collision.gameObject == right)
        {
            drone.right_turn_off();
        }
    }
    
}
