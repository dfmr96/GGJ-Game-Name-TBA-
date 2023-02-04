using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbAbility : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            collision.gameObject.GetComponentInParent<PlayerController>().AllowClimb();
            Destroy(gameObject);
        }
    }
}
