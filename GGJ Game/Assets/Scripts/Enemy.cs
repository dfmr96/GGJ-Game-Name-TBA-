using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
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

        if (health <= 0) Destroy(gameObject);
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

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
