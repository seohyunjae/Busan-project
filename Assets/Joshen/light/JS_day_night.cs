 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JS_day_night : MonoBehaviour
{
    public Material night = null;
    public Material day = null;
    public GameObject dLight;
    [SerializeField]
    private GameObject obj_night_on;
    [SerializeField]
    private GameObject obj_night_off;
    public Color dayfog;
    public Color nightfog;
    // Start is called before the first frame update


    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            dayOn();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            nightOn();
        }
            
    }

    public void dayOn()
    {
        RenderSettings.skybox = day;
        dLight.GetComponent<Light>().enabled = true;


        obj_night_off.SetActive(true);
        obj_night_on.SetActive(false);
        RenderSettings.ambientLight = dayfog;
        RenderSettings.fogDensity = 0;

    }
    public void nightOn()
    {
        RenderSettings.skybox = night;
        dLight.GetComponent<Light>().enabled = false;
        obj_night_off.SetActive(false);
        obj_night_on.SetActive(true);
        RenderSettings.ambientLight = nightfog;
        RenderSettings.fogDensity = 0.001f;
    }
    
}
