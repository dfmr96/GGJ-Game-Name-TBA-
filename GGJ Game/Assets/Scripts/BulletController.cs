using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float destroyDelay = 2f;

    private void Start()
    {
        Destroy(gameObject, destroyDelay);
    }
    private void Update()
    {
        BulletDirection();
    }

    void BulletDirection()
    {
        transform.Translate(new Vector3(transform.localPosition.x,0,0).normalized * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
