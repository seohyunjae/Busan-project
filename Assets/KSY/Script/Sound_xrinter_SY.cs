using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_xrinter_SY : MonoBehaviour
{
    public GameObject soundUI;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioClip2;
    public void openUI()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        soundUI.SetActive(true);
        
    }
    public void closeUI()
    {
        audioSource.clip = audioClip2;
        audioSource.Play();
        soundUI.SetActive(false);
    }
}
