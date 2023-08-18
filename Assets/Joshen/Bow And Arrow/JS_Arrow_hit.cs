using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_Arrow_hit : MonoBehaviour
{
    [SerializeField]
    ParticleSystem core;//Á¡¼ö

    [SerializeField]
    AudioSource hit;

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("ArrowTip"))
        {
            core.Play();
            hit.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ArrowTip"))
        {
            core.Play();
        }

    }

}
