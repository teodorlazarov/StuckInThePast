using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRainbow : MonoBehaviour
{
    public float speed;
    public int damageToInflict;
    public GameObject impactParticle;

    public PlayerController player;
    private Rigidbody2D rb;
    private HealthManager healthManager;


    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        healthManager = FindObjectOfType<HealthManager>();
        GetComponent<Transform>().transform.Rotate(0, 180, 45);

        if (player.transform.position.x < transform.position.x)
        {
            speed = -speed;
            GetComponent<Transform>().transform.Rotate(0, 180, 90);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            healthManager.HurtPlayer(damageToInflict);
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
        speed = 0.0f;
        Destroy(gameObject);
    }
}
