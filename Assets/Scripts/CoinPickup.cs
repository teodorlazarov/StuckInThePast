using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int pointsToAdd;

    public AudioSource coinPickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreManager.AddPoints(pointsToAdd);
            coinPickUpSound.Play();
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }

}
