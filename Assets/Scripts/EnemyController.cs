using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundLayer, playerLayer;
    public float health;
    public bool dead;

    //attacking
    public float attackCooldown;
    public bool attacked;

    public bool playerInAttackRange;
    public float attackRange;

    public EnemySpawnerController spawner;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }
    protected virtual void Update()
    {
        if (!dead)
        {
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
            if (!playerInAttackRange)
            {
                Chase();
            }
            else
            {
                Attack();
            }
        }
    }

    public void ResetAttack()
    {
        attacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.RemoveEnemy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    protected abstract void Chase();
    protected abstract void Attack();
    protected abstract void DestroyEnemy();
}