using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpiderObjectsController : MonoBehaviour
{
    [SerializeField] GameObject[] doorsToClose;
    [SerializeField] GameObject[] doorsLever;

    public void HideObjectsLevers()
    {
        for (int i = 0; i < doorsLever.Length; i++)
        {
            doorsLever[i].SetActive(false);
        }
    }
}
