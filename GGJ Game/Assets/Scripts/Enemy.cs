using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    [SerializeField] int damage;
    [SerializeField] float speed;
    [SerializeField] BoxCollider2D movementArea;
    [SerializeField] BoxCollider2D enemyCollider;
    [SerializeField] float changeDirectionCooldown;
    [SerializeField] float changeDirectionTimer;
    [SerializeField] float attackCooldown;
    [SerializeField] float attackTimer;

    private void Start()
    {
        attackTimer = 0;
        changeDirectionTimer = 0;
    }
    private void Update()
    {
        attackTimer += Time.deltaTime;
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (attackTimer >= attackCooldown && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador dañado");
            attackTimer = 0;
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
