using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        BulletDirection();
    }

    void BulletDirection()
    {
        transform.Translate(transform.localPosition * speed * Time.deltaTime);
    }
}
