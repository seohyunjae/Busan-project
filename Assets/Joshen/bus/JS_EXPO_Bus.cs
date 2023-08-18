using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_EXPO_Bus : MonoBehaviour
{
    [SerializeField]
    private GameObject bus;

    [SerializeField]
    private GameObject dist_ck;
    public bool _isStop = false;

    public bool _isSlow = false;
    [SerializeField]
    private Transform player;

    public float scrPlayDist_slow = 8f;

    public float scrPlayDist_stop = 3f;


   
    private void Update()
    {
       

        float dist = CalcDistanceWithTarget();

        if (dist < scrPlayDist_slow && dist > scrPlayDist_stop)
        {
            _isStop = false;
            _isSlow = true;
            bus.GetComponent<Animator>().speed = 0.3f;
        }
        else if (dist < scrPlayDist_stop)
        {
            _isSlow = false;
            _isStop = true;
            bus.GetComponent<Animator>().speed = 0f;
        }
        else
        {
            _isSlow = false;
            _isStop = false;
            bus.GetComponent<Animator>().speed = 1f;
        }


    }

    private float CalcDistanceWithTarget()
    {
        Vector3 dirToTarget =
            player.position - dist_ck.transform.position;
        float dist = dirToTarget.magnitude;

        dist = Vector3.Distance(
            player.position, dist_ck.transform.position);

        return dist;
    }


}
