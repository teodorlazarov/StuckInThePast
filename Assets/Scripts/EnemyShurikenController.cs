using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShurikenController : MonoBehaviour {

    public float speed;
    public PlayerController player;
    public float rotationSpeed;
    public int damageToInflict;
    public GameObject hurtParticle;
    public GameObject impactParticle;
    private HealthManager healthManager;



    private Rigidbody2D rb;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();

        healthManager = FindObjectOfType<HealthManager>();

        if (player.transform.position.x < transform.position.x)
        {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
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
            collision.GetComponent<Animator>().SetTrigger("PlayerHurt");
            Instantiate(hurtParticle, player.gameObject.transform.position, player.gameObject.transform.rotation);
            Instantiate(impactParticle, gameObject.transform.position, gameObject.transform.rotation);
            healthManager.HurtPlayer(damageToInflict);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        rb.angularVelocity = rotationSpeed;
    }
}
