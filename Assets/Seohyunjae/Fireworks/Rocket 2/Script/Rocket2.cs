using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket2 : MonoBehaviour
{

    public Rigidbody rig;
    public ConstantForce cf;
    public Transform IsKinematic;

    IEnumerator Start()

    {
        yield return new WaitForSeconds(1);
        this.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2);
        rig.isKinematic = true;
        cf.enabled = false;
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);



    }
}
