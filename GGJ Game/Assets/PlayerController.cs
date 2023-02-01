using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

    [SerializeField] Vector3 wallBoxSize;
    [SerializeField] float wallMaxDistance;
    [SerializeField] LayerMask wallLayerMask;

    [SerializeField] Rigidbody2D rb;
    private void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        velocity = rb.velocity;
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
        if (RightSideWallCheck() == true || LeftSideWallCheck() == true)
        {
        Debug.Log("Pegado de la pared");
        rb.velocity = new Vector2(rb.velocity.x, moveY * slidingSpeed * Time.fixedDeltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(jumpForceX, jumpForceY);
            }
        }
    }
    void Jump(bool canJump)
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForceY);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position - transform.up * groundMaxDistance, groundBoxSize);
        Gizmos.DrawCube(transform.position - transform.right * wallMaxDistance, wallBoxSize);
        Gizmos.DrawCube(transform.position + transform.right * wallMaxDistance, wallBoxSize);

    }
    bool GroundCheck()
    {
        if (Physics2D.BoxCast(transform.position, groundBoxSize,0, -transform.up, groundMaxDistance, groundLayerMask))
        {
            Debug.Log("Pegando del piso");
            return true;
        } else
        {
            return false;
        }
    }

    bool LeftSideWallCheck()
    {
        return BoxChecker(transform.position, wallBoxSize, 0, -transform.right, wallMaxDistance, wallLayerMask);
    }

    bool RightSideWallCheck()
    {
        return BoxChecker(transform.position, wallBoxSize, 0, transform.right, wallMaxDistance, wallLayerMask);

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
}
