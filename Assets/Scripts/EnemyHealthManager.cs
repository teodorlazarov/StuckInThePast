using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

    public int enemyHealth;
    public int pointsOnDeath;
    public float delay = 0f;
    public GameObject hurtParticle;
    public GameObject bossParticle;

    public BoxCollider2D attackCollider;
    private bool enemyKilled = false;

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            if (!enemyKilled)
            {
                ScoreManager.AddPoints(pointsOnDeath);
            }
            if (gameObject.name == "Boss")
            {
                Instantiate(bossParticle, gameObject.transform.position, gameObject.transform.rotation);
                var exitTrigger = GameObject.FindGameObjectWithTag("ExitLevel");
                exitTrigger.GetComponent<BoxCollider2D>().enabled = true;
            }
            enemyKilled = true;
            GetComponent<Animator>().SetTrigger("Death");
            gameObject.GetComponent<EnemyPatrol>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            if (gameObject.GetComponent<ThrowStarAtPlayer>() != null)
            {
                gameObject.GetComponent<ThrowStarAtPlayer>().enabled = false;
            }
            attackCollider.enabled = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        }
    }

    public void GiveDamage(int damage)
    {
        enemyHealth -= damage;
        GetComponent<Animator>().SetTrigger("WasHit");
        Instantiate(hurtParticle, gameObject.transform.position, gameObject.transform.rotation);
    }
}
