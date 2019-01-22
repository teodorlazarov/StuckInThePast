using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    public int pointsOnDeath;

    public GameObject playerObject;

    private PlayerController playerController;
    public HealthManager HealthManager;
    public Animator animator;

	void Start () {
        animator = FindObjectOfType<Animator>();
        playerController = FindObjectOfType<PlayerController>();
        HealthManager = FindObjectOfType<HealthManager>();
	}
	
	void Update () {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
	}

    public void RespawnPlayer()
    {
        playerController.enabled = false;
        playerObject.GetComponent<BoxCollider2D>().enabled = false;
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        playerObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        StartCoroutine("DoAnimation");
        ScoreManager.AddPoints(-pointsOnDeath);
        HealthManager.ResetHealth();
    }

    public IEnumerator RespawnPlayerFromFallDeath()
    {
        yield return new WaitForSeconds(0.5f);
        ScoreManager.AddPoints(-pointsOnDeath);
        HealthManager.ResetHealth();
        playerController.transform.position = currentCheckpoint.transform.position;
    }

    IEnumerator DoAnimation()
    {
        yield return new WaitForSeconds(1.5f);
        playerController.transform.position = currentCheckpoint.transform.position;
        playerController.enabled = true;
        playerObject.GetComponent<BoxCollider2D>().enabled = true;
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 2f;
    }
}
