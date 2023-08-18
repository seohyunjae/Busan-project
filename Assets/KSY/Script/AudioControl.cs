using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] private AudioSource audioSorce = null;
    [SerializeField] private float timer = 0.0f;
    [SerializeField] private float playTime = 0.5f;
    
    private void Awake()
    {
        if (!audioSorce) audioSorce = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (playTime > timer)
        {
            timer += Time.deltaTime;
        }
        else if (playTime <= timer)
        {
            audioSorce.Play();
        }
    }

    private void CountdownAndPlay()
    {
        if (playTime > timer)
        {
            timer += Time.deltaTime;
        }
        else if (playTime <= timer)
        {
            audioSorce.Play();
        }
    }
}
