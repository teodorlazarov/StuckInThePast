using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;
    private Animator animator;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        animator = GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "BotLvlBorder")
            {
                StartCoroutine(levelManager.RespawnPlayerFromFallDeath());
            }
            else
            {
                animator.SetTrigger("AttackPlayer");
                levelManager.RespawnPlayer();
            }
        }
    }
}
