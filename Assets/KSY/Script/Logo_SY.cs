using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo_SY : MonoBehaviour
{
    [SerializeField] private SpriteRenderer logoRenderer = null;

    private bool playName = false;

    private void Start()
    {
        if (!logoRenderer) logoRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            FadeOut();

            if (!playName)
            {
                playName = true;
                transform.GetChild(1).GetComponent<Name_SY>().FadeOut();
            } 
        }
    }

    private void FadeOut()
    {
        StartCoroutine(FadeOut(3f));
    }

    IEnumerator FadeOut(float fadeOutTime)
    {
        Color tempColor = logoRenderer.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            logoRenderer.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return null;
        }
        logoRenderer.color = tempColor;
    }
}
