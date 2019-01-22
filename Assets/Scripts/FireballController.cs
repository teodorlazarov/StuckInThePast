using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public float speed;
    public int damageToInflict;
    public GameObject impactParticle;

    private PlayerController player;
    private Rigidbody2D rb;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            GetComponent<Transform>().transform.Rotate(0, 0, 180);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Animator>().SetTrigger("WasHit");
            collision.GetComponent<EnemyHealthManager>().GiveDamage(damageToInflict);
            DestroyParticle();
        }
        if (collision.gameObject.tag == "Ground")
        {
            DestroyParticle();
        }
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void DestroyParticle()
    {
        Instantiate(impactParticle, gameObject.transform.position, gameObject.transform.rotation);
        GetComponent<Animator>().SetTrigger("DestroyFireball");
        speed = 0.0f;
        Destroy(gameObject);
    }
}
