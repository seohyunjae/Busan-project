using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_start_gate : MonoBehaviour
{
    SpriteRenderer sr;
    BoxCollider boxcol;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        boxcol = GetComponent<BoxCollider>();
    }

    public void start_gate()
    {
        boxcol.enabled = false;
        StartCoroutine(CoFadeOut(1f));
    }
    IEnumerator CoFadeOut(float fadeOutTime)
    {
        
        Color tempColor = sr.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            sr.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return null;
        }
        sr.color = tempColor;
    }
    }

