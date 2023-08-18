using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptForBOOGI : MonoBehaviour
{
    // �÷��̾�� spawnPoint ������ּ���~~~
    private BoogiAction_SY boogiAction = null;

    void Awake()
    {
        if (!boogiAction) boogiAction = GameObject.Find("Boogi").GetComponent<BoogiAction_SY>();
    }

    private void OnTriggerEnter(Collider other)
    {
        boogiAction.PlayerOnTriggerEnter(other);
    }

    private void OnTriggerStay(Collider other)
    {
        boogiAction.PlayerOnTriggerStay(other);
    }

    private void OnTriggerExit(Collider other)
    {
        boogiAction.PlayerOnTriggerExit(other);
    }
}
