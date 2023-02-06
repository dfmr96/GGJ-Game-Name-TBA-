using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject lastCheckpoint;
    public static GameManager sharedInstance;
    [SerializeField] AudioSource checkpointSound;
    [SerializeField] GameObject creditsPanel;
    public Fades fader;
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void RespawnPlayer(GameObject player)
    {
        player.transform.position = lastCheckpoint.transform.position;
    }

    public void SetLastCheckpoint (GameObject checkpoint)
    {
        checkpointSound.Play();
        lastCheckpoint = checkpoint;
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }
}
