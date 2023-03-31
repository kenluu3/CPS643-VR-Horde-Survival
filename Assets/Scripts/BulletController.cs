using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float uptime = 5.0f;
    private float bulletForce = 35.0f;
    private int bulletDamage = 50;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);
    }

    void Update()
    {
        uptime -= Time.deltaTime;
        if (uptime <= 0.0f) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11) // Enemy Layer
        {
            EnemyController enemyObj = collision.gameObject.GetComponent<EnemyController>();
            enemyObj.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 11) // Enemy Layer
        {
            EnemyController enemyObj = collision.gameObject.GetComponent<EnemyController>();
            enemyObj.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
