using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager sharedInstance;

    public AudioSource[] audioClips;
    public AudioClip[] bmgs;
    [SerializeField] AudioSource source;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        source.clip = bmgs[0];
        source.Play();
    }

    public void PlayBGM(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
