using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPartcleButton_SY : MonoBehaviour
{
    private bool play = false;

    private void Update()
    {
        if (play)
        {
            StartCoroutine(StopParticle());
        }
    }

    public void PlayParicle()               // ���׹�ư ������ ����Ǵ� ��ũ��Ʈ
    {
        play = true;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            transform.GetChild(i).GetComponent<ParticleSystem>().Play();
        }
    }

    private IEnumerator StopParticle()
    {
        yield return new WaitForSeconds(30.0f);

        play = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<ParticleSystem>().Stop();
        }

        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
