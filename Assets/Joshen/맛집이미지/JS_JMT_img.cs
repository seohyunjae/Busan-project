using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_JMT_img : MonoBehaviour
{
    [SerializeField]
    GameObject img1;
    [SerializeField]
    GameObject img2;

    public void road()
    {
        img1.SetActive(true);
        img2.SetActive(false);
    }
    public void imfo()
    {
        img1.SetActive (false);
        img2.SetActive (true);
    }
}
