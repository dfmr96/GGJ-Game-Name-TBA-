using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Rendering;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    [SerializeField] GameObject[] dropPositions;
    [SerializeField] Vector3 randomPosition;
    [SerializeField] Transform bodyTransform;
    [SerializeField] bool canDrop;
    [SerializeField] float speed;
    [SerializeField] float currentSpeed;
    [SerializeField] float timeToGoUp;
    [SerializeField] float timeToGoDown;
    [SerializeField] float stunTime;
    [SerializeField] Collider2D stopZone;

    private void Start()
    {
        canDrop = false;
        currentSpeed = speed;
    }

    private void Update()
    {
        VerticalMovement();
    }
    void GetRandomPosition()
    {
        int randomNumber = Random.Range(0, dropPositions.Length);

        randomPosition = dropPositions[randomNumber].transform.position;
    }
    [ContextMenu("MoveSpider")]
    void MoveSpiderToRandomPosition()
    {
        GetRandomPosition();
        bodyTransform.position = randomPosition;
    }

    void VerticalMovement()
    {
        bodyTransform.Translate(-transform.up * currentSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(ChangeSpeed(stunTime, -speed));
            canDrop = false;
        }

        if (collision == stopZone)
        {
            canDrop = true;
            StartCoroutine(ChangeSpeed(timeToGoDown, speed));
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ChangeSpeed(timeToGoUp, -speed));
            canDrop = false;
        }
    }

    IEnumerator ChangeSpeed(float timeToMove, float speed)
    {
        currentSpeed = 0;
        yield return new WaitForSeconds(timeToMove);
        if (canDrop) MoveSpiderToRandomPosition();
        currentSpeed = speed;
    }
}
