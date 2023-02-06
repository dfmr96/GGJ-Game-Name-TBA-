using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCredits : MonoBehaviour
{
    [SerializeField] AudioClip creditsClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.sharedInstance.PlayBGM(creditsClip);
            StartCoroutine(CallCredits());
        }
    }

    IEnumerator CallCredits()
    {
        GameManager.sharedInstance.fader.FadeOut();
        yield return new WaitForSeconds(2f);
        GameManager.sharedInstance.fader.FadeIn();
        GameManager.sharedInstance.ShowCredits();
    }
}
