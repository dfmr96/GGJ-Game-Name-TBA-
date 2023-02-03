using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components or Game Objects")]
    [SerializeField] GameObject bulletSpawnPoint;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] PlayerStats stats;

    [Header("Movement Stats")]
    [SerializeField] float speed = 5;
    [SerializeField] float slidingSpeed = 5;
    [SerializeField] float jumpForceX = 10;
    [SerializeField] float jumpForceY = 10;
    [Header("Variable Debug")]
    [SerializeField] float moveX;
    [SerializeField] float moveY;
    [SerializeField] Vector2 velocity;

    [Header("Ground Checker")]

    [SerializeField] Vector3 groundBoxSize;
    [SerializeField] float groundMaxDistance;
    [SerializeField] LayerMask groundLayerMask;

    [Header("Wall Checker")]

    [SerializeField] bool isFacingRight;
    [SerializeField] Vector2 facingDirection;
    [SerializeField] Vector3 wallBoxSize;
    [SerializeField] float wallMaxDistance;
    [SerializeField] LayerMask wallLayerMask;

    private void Start()
    {
        Application.targetFrameRate = 60;
        stats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = true;
        facingDirection = transform.right;

    }
    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        velocity = rb.velocity;

        if (moveX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveX < 0 && isFacingRight)
        {
            Flip();
        }
        Shoot();
        Jump(GroundCheck());
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
        VerticalMovement();
    }
    void HorizontalMovement()
    {
        
        rb.velocity = new Vector2(moveX * speed * Time.fixedDeltaTime, rb.velocity.y);
    }


    void VerticalMovement()
    {
        if (WallCheck())
        {
        Debug.Log("Pegado de la pared");
        rb.velocity = new Vector2(rb.velocity.x, moveY * slidingSpeed * Time.fixedDeltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(jumpForceX * -facingDirection.x, jumpForceY);
            }
        }
    }
    void Jump(bool canJump)
    {
        if (canJump) Debug.Log("Puede saltar");
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForceY);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position - transform.up * groundMaxDistance, groundBoxSize);
        Gizmos.DrawCube(transform.position + (Vector3)facingDirection * wallMaxDistance, wallBoxSize);

    }
    bool GroundCheck()
    {
        return BoxChecker(transform.position, groundBoxSize, 0, -transform.up, groundMaxDistance, groundLayerMask);

/*
        if (Physics2D.BoxCast(transform.position, groundBoxSize,0, -transform.up, groundMaxDistance, groundLayerMask))
        {
            return true;
        } else
        {
            return false;
        }*/
    }

    bool WallCheck()
    {
        return BoxChecker(transform.position, wallBoxSize, 0, facingDirection, wallMaxDistance, wallLayerMask);
    }


    bool BoxChecker(Vector2 position, Vector2 size, float angle, Vector2 direction, float distance, int layermask)
    {
        if (Physics2D.BoxCast(position, size, angle, direction, distance, layermask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.F) && stats.health > 0)
        {
            stats.ReduceSap();
            Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        facingDirection = -facingDirection;
        transform.Rotate(0, 180f, 0);
    }
}
