using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] spiderChildren;
    [SerializeField] SpiderObjectsController objectsController;

    public void ActiveSpider()
    {
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
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        objectsController.HideObjectsLevers();
    }
}
