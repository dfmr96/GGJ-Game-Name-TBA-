using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float speed;
    [SerializeField] BoxCollider2D movementArea;
    [SerializeField] BoxCollider2D enemyCollider;
    [SerializeField] float changeDirectionCooldown;
    [SerializeField] float changeDirectionTimer;

    private void Update()
    {
        changeDirectionTimer += Time.deltaTime;
        HorizontalMovement();
        ChangeDirection();
    }

    void HorizontalMovement()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    void ChangeDirection()
    {
        if((enemyCollider.bounds.max.x >= movementArea.bounds.max.x || enemyCollider.bounds.min.x <= movementArea.bounds.min.x) && changeDirectionTimer >= changeDirectionCooldown)
        {
            changeDirectionTimer = 0;
            speed = -speed;
        }
    }
}
