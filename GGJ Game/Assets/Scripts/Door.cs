using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLock;
    [SerializeField] float speed;
    [SerializeField] Vector3 movDirection;
    [SerializeField] bool haveToMove;
    [SerializeField] float moveTimer;
    [SerializeField] float moveCooldown;

    private void Start()
    {
        haveToMove = false;
        isLock = true;
    }
    private void Update()
    {
        VerticalMovement(); 
    }

    void VerticalMovement()
    {
        if (haveToMove)
        {
            moveTimer += Time.deltaTime;
            transform.Translate(movDirection * speed * Time.deltaTime);

            if(moveTimer >= moveCooldown)
            {
                haveToMove = false;
                moveTimer = 0;
            }
        }
    }

    [ContextMenu("OpenDoor")]
    public void OpenDoor()
    {
        isLock = false;
        movDirection = -transform.up;
        haveToMove = true;
    }

    [ContextMenu("CloseDoor")]
    public void CloseDoor()
    {
        isLock = true;
        movDirection = transform.up;
        haveToMove = true;
    }
}
