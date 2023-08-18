using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Name_SY : MonoBehaviour
{
    [SerializeField] private SpriteRenderer nameRenderer = null;
    private bool firstPlay = true;

    public void FadeOut()
    {
        StartCoroutine(FadeOut(0));
    }

    IEnumerator FadeOut(int index)
    {
        if (firstPlay) 
        {
            firstPlay = false;
            yield return new WaitForSeconds(3f);
        }

        else yield return new WaitForSeconds(1f);

        GameObject _nameGO = transform.GetChild(index).gameObject;
        _nameGO.SetActive(true);

        nameRenderer = transform.GetChild(index).GetComponent<SpriteRenderer>();

        Color tempColor = nameRenderer.color;
        yield return new WaitForSeconds(1.5f);
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / 1.5f /*FadeoutTime*/;
            nameRenderer.color = tempColor;

            if (tempColor.a <= 0f)
            { 
                tempColor.a = 0f;
            }
            yield return null;              // ÇÊ¼ö
        }
        nameRenderer.color = tempColor;

        index++;

       if (index < transform.childCount) StartCoroutine(FadeOut(index));
    }
}
