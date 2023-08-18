using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingPeopleControl_SY : MonoBehaviour
{
    [SerializeField] private float hideDistance = 150f;
    [SerializeField] private float showDistance = 100f;

    private GameObject player = null;

    private bool isHidden = false;

    private void Awake()
    {
        if(!player) player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < showDistance)
        {
            if (isHidden)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).transform.GetComponent<Animator>().enabled = true;
                }
                isHidden = false;
            }
        }
        else if (distance > hideDistance)
        {
            if (!isHidden)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).transform.GetComponent<Animator>().enabled = false;
                }
                isHidden = true;
            }
        }
    }
}
