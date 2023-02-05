using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : MonoBehaviour
{
    [SerializeField] AudioSource sfx;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            sfx.Play();
            collision.gameObject.GetComponentInParent<PlayerController>().AllowShoot();
            Destroy(gameObject);
        }
    }
}
