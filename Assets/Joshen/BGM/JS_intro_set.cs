using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_intro_set : MonoBehaviour
{
    [SerializeField] private SoundControlller_SY soundController = null;
    private bool start = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!start)
            {
                start = true;
                soundController.seaToggle.isOn = true;
                
                StartCoroutine(StartInterval());
            }
        }
    }

    IEnumerator StartInterval()
    {
       // soundController.seaToggle.isOn = true;

        yield return new WaitForSeconds(13.5f);

        soundController.audioSource.Pause();
        //soundController.freshToggle.isOn = true;
        this.gameObject.SetActive(false);
    }
}
