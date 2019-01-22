using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStarAtPlayer : MonoBehaviour {

    public float playerRange;
    public GameObject enemyShuriken;
    public PlayerController player;
    public Transform launchPoint;
    public float timeBetweenShots;

    private float shotCounter;

	void Start () {
        player = FindObjectOfType<PlayerController>();
        shotCounter = timeBetweenShots;
	}
	
	void Update () {
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y+0.5f, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y + 0.5f, transform.position.z));

        shotCounter -= Time.deltaTime;
        if(transform.localScale.x > 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0)
        {
            Instantiate(enemyShuriken, launchPoint.position, launchPoint.rotation);
            shotCounter = timeBetweenShots;
        }

        if (transform.localScale.x < 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0)
        {
            Instantiate(enemyShuriken, launchPoint.position, launchPoint.rotation);
            shotCounter = timeBetweenShots;
        }
    }
}
