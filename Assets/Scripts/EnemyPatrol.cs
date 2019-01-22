using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public float moveSpeed;
    private float moveSpeedOriginal;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool notAtEdge;
    public Transform edgeCheck;


    private Animator animator;

    private float stunTime;
    public float startStunTime;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        moveSpeedOriginal = moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {

        if(stunTime <= 0)
        {
            moveSpeed = moveSpeedOriginal;
        }
        else
        {
            moveSpeed = 0;
            stunTime -= Time.deltaTime;
        }

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall || !notAtEdge)
        {
            moveRight = !moveRight;
            Flip();
        }

        if (moveRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        animator.SetFloat("Speed", Mathf.Abs(moveSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BotLvlBorder")
        {
            Destroy(gameObject);
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void ActivateStun()
    {
        stunTime = startStunTime;
    }
}
