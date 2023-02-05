using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager sharedInstance;

    public AudioSource[] audioClips;
    [SerializeField] AudioSource bgm;

    private void Start()
    {
        bgm.Play();
    }
}
