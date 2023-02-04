using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLever : MonoBehaviour
{
    [SerializeField] GameObject doorToOpen;

    [ContextMenu("Interact")]
    void OpenInteract()
    {
        doorToOpen.GetComponent<Door>().OpenDoor();
    }

    void CloseInteract()
    {
        doorToOpen.GetComponent<Door>().CloseDoor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (doorToOpen.GetComponent<Door>().isLock)
            {
                OpenInteract();
            }
            else
            {
                CloseInteract();
            }
        }
    }
}
