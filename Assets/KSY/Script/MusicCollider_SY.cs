using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCollider_SY : MonoBehaviour
{
    [SerializeField] private SoundControlller_SY soundController = null;
    private bool isColliderMusicPlay = false;
    private bool isPlayerInCollider = false;

    private void Awake()
    {
        if (!soundController) soundController = GameObject.FindWithTag("SoundController").GetComponent<SoundControlller_SY>();
    }

    private void PlayColliderBGM(Collider other)
    {
        switch (gameObject.name)
        {
            case "감옥BGM":
                {
                    other.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/감옥BGM");
                    other.GetComponent<AudioSource>().volume = 1;
                    other.GetComponent<AudioSource>().Play();
                    if (!isColliderMusicPlay) isColliderMusicPlay = true;
                }
                break;
            case "가야금BGM":
                {
                    other.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("BGM/가야금파티BGM");
                    other.GetComponent<AudioSource>().volume = 1;
                    other.GetComponent<AudioSource>().Play();
                    if (!isColliderMusicPlay) isColliderMusicPlay = true;
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<AudioSource>().clip.name == "감옥BGM" || other.GetComponent<AudioSource>().clip.name == "가야금파티BGM")
            {
                if (!isColliderMusicPlay) isColliderMusicPlay = true;

                while (other.GetComponent<AudioSource>().volume < 1)
                {
                    other.GetComponent<AudioSource>().volume += Time.deltaTime * 1.5f;
                }
            }
            else
            {
                if (isColliderMusicPlay) isColliderMusicPlay = false;

                while (other.GetComponent<AudioSource>().volume > 0)
                {
                    other.GetComponent<AudioSource>().volume -= Time.deltaTime * 1.5f;

                    if (other.GetComponent<AudioSource>().volume <= 0)
                    {
                        other.GetComponent<AudioSource>().volume = 0;
                        if (!isColliderMusicPlay) soundController.BGMStopCheck();
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<AudioSource>().clip.name == "감옥BGM" || other.GetComponent<AudioSource>().clip.name == "가야금파티BGM")
            {
                if (!isColliderMusicPlay) isColliderMusicPlay = true;
                if (!other.GetComponent<AudioSource>().isPlaying)
                {
                    other.GetComponent<AudioSource>().volume = 1f;
                    other.GetComponent<AudioSource>().Play();
                }
            }
            else 
            {
                while (other.GetComponent<AudioSource>().volume > 0)
                {
                    other.GetComponent<AudioSource>().volume -= Time.deltaTime * 1.5f;

                    if (other.GetComponent<AudioSource>().volume <= 0)
                    {
                        other.GetComponent<AudioSource>().volume = 0;
                        if (!isColliderMusicPlay) soundController.BGMStopCheck();
                    }
                }

                PlayColliderBGM(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<AudioSource>().clip.name == "감옥BGM" || other.GetComponent<AudioSource>().clip.name == "가야금파티BGM")
            {
                while (other.GetComponent<AudioSource>().volume > 0)
                {
                    other.GetComponent<AudioSource>().volume -= Time.deltaTime * 1.5f;

                    if (other.GetComponent<AudioSource>().volume <= 0)
                    {
                        other.GetComponent<AudioSource>().volume = 0;
                    }
                }
                if (!isPlayerInCollider) soundController.BGMStopCheck();
            }
        
        }
    }
}