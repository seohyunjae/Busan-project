using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BusCarwheelchange : MonoBehaviour
{
    JS_EXPO_Bus stopck;
    public GameObject[] wheels;
    public GameObject CarspeedControl;
    public GameObject dist_sk;
    public float xspeed = 180;
    bool isstop=false;

    private void Awake()
    {
        stopck = GetComponentInParent<JS_EXPO_Bus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isstop||stopck._isStop) 
        {
            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(0, 0, 0);
            }
        }
        else if(stopck._isSlow)
        {
            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(0, xspeed * Time.deltaTime*0.3f, 0);
            }
        }
        else {
            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(0, xspeed *Time.deltaTime*2f, 0);
            }
        }

    }
    public void Stop()
    {
        isstop = true;
    }
    public void Go()
    {
        isstop = false;
    }

}
