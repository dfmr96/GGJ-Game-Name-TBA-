using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] spiderChildren;
    [SerializeField] SpiderObjectsController objectsController;
    [SerializeField] AudioSource spiderSound;
    [SerializeField] AudioClip spiderBGM;
    public void ActiveSpider()
    {
        AudioManager.sharedInstance.PlayBGM(spiderBGM);
        spiderSound.Play();
        for (int i = 0; i < spiderChildren.Length; i++)
        {
            spiderChildren[i].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActiveSpider();
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        objectsController.HideObjectsLevers();
    }
}
