using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public int maxHealth;
    public int playerHealth;
    public Animator anim;

    Text text;

    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        playerHealth = maxHealth;
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth <= 0)
        {
            playerHealth = 0;
            anim.SetTrigger("PlayerDead");
            levelManager.RespawnPlayer();
        }

        text.text = "" + playerHealth + "%";
	}

    public void HurtPlayer(int damage)
    {
        playerHealth -= damage;
        anim.SetTrigger("PlayerHurt");
    }

    public void ResetHealth()
    {
        playerHealth = maxHealth;
    }
}
