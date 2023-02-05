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
    [SerializeField] bool isChasing;
    [SerializeField] bool isAttacking;
    [SerializeField] Vector3 movDirection;

    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource deathSound;

    private void Start()
    {
        attackTimer = 0;
        changeDirectionTimer = 0;
        movDirection = transform.right;
    }
    private void Update()
    {
        attackTimer += Time.deltaTime;
        changeDirectionTimer += Time.deltaTime;
        HorizontalMovement();
        ChangeDirection();

        if (health <= 0)
        {
            deathSound.Play();
            Destroy(gameObject);
        }
    }

    void HorizontalMovement()
    {
        if (isAttacking) return;
        if (!isChasing)
        {
        transform.Translate(movDirection * speed * Time.deltaTime);
        }
    }

    void ChangeDirection()
    {
        if (isAttacking) return;

        if ((enemyCollider.bounds.max.x > movementArea.bounds.max.x || enemyCollider.bounds.min.x < movementArea.bounds.min.x) && !isChasing) 
        {
            movDirection = (movementArea.transform.position - transform.position).normalized;
        }

        if ((enemyCollider.bounds.max.x >= movementArea.bounds.max.x || enemyCollider.bounds.min.x <= movementArea.bounds.min.x) && changeDirectionTimer >= changeDirectionCooldown && !isChasing)
        {
            changeDirectionTimer = 0;
            movDirection = -movDirection;
        }
    }

    public void TakeDamage(int damage)
    {
        hitSound.Play();
        health -= damage;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (attackTimer >= attackCooldown && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StopOnAttack());
            Debug.Log("Jugador dañado");
            attackTimer = 0;
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 playerDir = collision.gameObject.transform.position - transform.position;
            Debug.Log($"{gameObject.name} is chasing Player");
            isChasing = true;
            if (isAttacking) return;
            transform.Translate(new Vector3((playerDir.x),0,0).normalized * speed * Time.deltaTime);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isChasing = false;
        }
    }

    IEnumerator StopOnAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
