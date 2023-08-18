using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTimer_SY : MonoBehaviour
{
    [SerializeField] private  ParticleSystem particleSystem = null;

    [SerializeField] private float triggerInterval = 8f;

    [SerializeField] private float timer = 0.0f;

    private void Awake()
    {
        if (!particleSystem) particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (timer < triggerInterval)
        { timer += Time.deltaTime; }

        else if (timer >= triggerInterval)
        {
            particleSystem.Play();
            timer = 0f;
        }
    }
}
