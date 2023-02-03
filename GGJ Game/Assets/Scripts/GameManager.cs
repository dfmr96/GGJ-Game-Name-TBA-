using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject lastCheckpoint;
    public static GameManager sharedInstance;

    private void Awake()
    {
        if (sharedInstance ==null)
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
        lastCheckpoint = checkpoint;
    }
}
