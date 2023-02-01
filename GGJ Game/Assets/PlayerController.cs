using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int jumpForce = 10;
    [SerializeField] Vector2 jumpVector;
    [SerializeField] float moveX;
    [SerializeField] Vector2 velocity;
    private void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        jumpVector = new Vector2(0, jumpForce);

    }
    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        velocity = rb.velocity;

        Jump();
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
    }
    void HorizontalMovement()
    {
        rb.velocity = new Vector2(moveX * speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpVector);
        }
    }
}
