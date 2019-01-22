using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    private float timeBetweenAttacks;
    private float timeBetweenFireballs;

    public float startTimeBetweenAttacks;
    public float startTimeBetweenFireballs;

    public Transform attackPos;
    public float attackRange;
    public LayerMask enemies;
    public int damageToGive;

    public GameObject fireball;
    public Transform firePoint;

    void Update()
    {
        if (timeBetweenAttacks <= 0)
        {
            if (Input.GetKey(KeyCode.L))
            {
                animator.SetTrigger("PlayerAttack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealthManager>().GiveDamage(damageToGive);
                    enemiesToDamage[i].GetComponent<EnemyPatrol>().ActivateStun();
                }
                timeBetweenAttacks = startTimeBetweenAttacks;
            }
        }
        else
        {
            timeBetweenAttacks -= Time.deltaTime;
        }

        timeBetweenFireballs -= Time.deltaTime;
        if (Input.GetKey(KeyCode.K) && timeBetweenFireballs < 0)
        {
            Instantiate(fireball, firePoint.position, firePoint.rotation);
            timeBetweenFireballs = startTimeBetweenFireballs;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
