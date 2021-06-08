using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Animator animator;
   


    // Health System for Enemies

    public float enemyHealth = 100;

    public void enemyDamage(float damage)
    {
        enemyHealth -= damage;

        if(enemyHealth <= 0)
        {
            animator.SetBool("isDead", true);
            Object.Destroy(gameObject, 5f);
        }
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent <NavMeshAgent>();
    }

    private void Update()
    { 
        if(enemyHealth <= 0)
        {
            animator.SetBool("eAttacking", false);
            animator.SetBool("isChasing", false);

           

        }else {
    
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

        if (playerInAttackRange) animator.SetBool("eAttacking", true);
        if (!playerInAttackRange) animator.SetBool("eAttacking", false);

         }
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

        agent.speed = 1.5f;
        animator.SetBool("isChasing", false);
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

        agent.speed = 3.5f;
        animator.SetBool("isChasing", true);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Sword")
        {
            enemyDamage(20);
        }
    }


}
