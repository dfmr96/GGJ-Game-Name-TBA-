using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.sharedInstance.SetLastCheckpoint(this.gameObject);
            if (collision.gameObject.GetComponentInParent<PlayerStats>().health != collision.gameObject.GetComponentInParent<PlayerStats>().maxHealth)
            {
                collision.gameObject.GetComponentInParent<PlayerStats>().FullHealthRestore();
            }
        }
    }
}
