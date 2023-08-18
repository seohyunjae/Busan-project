using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_Drone_controller : MonoBehaviour
{
    [SerializeField]
    [Range(10f, 50f)]
    private float moveSpeed = 10f;
    [SerializeField, Range(10f, 100f)]
    private float rotSpeed = 10f;
    // Class Member Variables
    private Transform tr = null;
    private Rigidbody rb = null;


    private bool _is_right = false;
    private bool _is_left = false;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        //tr = transform;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(_is_right)
        {
            right();
        }
        if(_is_left)
        {
            left();
        }

    }


   public void front()
    {
        Debug.Log("ÀüÁø");
        rb.velocity = tr.forward * moveSpeed;
    }

    public void front_exit()
    {
        rb.velocity = Vector3.zero;
    }    
   public void back() 
    {
        rb.velocity = tr.forward * -moveSpeed;
    }
    public void back_exit()
    {
        rb.velocity = Vector3.zero;
    }

    public void left_turn()
    {
        _is_left=true;
    }
    public void right_turn() 
    {
        _is_right = true;

    }
    public void left_turn_off()
    {
        _is_left = false;
    }
    public void right_turn_off()
    {
        _is_right = false;
    }




    void right()
    {
        tr.Rotate(Vector3.up,
                 rotSpeed * Time.deltaTime);
    }

    void left()
    {
        Vector3 newRot = tr.rotation.eulerAngles;
        newRot.y -= rotSpeed * Time.deltaTime;
        tr.rotation = Quaternion.Euler(newRot);
    }



}
