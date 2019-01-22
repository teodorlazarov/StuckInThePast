using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;
    public GameObject hurtParticle;
    private HealthManager healthManager;

	// Use this for initialization
	void Start () {
        healthManager = FindObjectOfType<HealthManager>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(hurtParticle, other.gameObject.transform.position, other.gameObject.transform.rotation);
            healthManager.HurtPlayer(damageToGive);
        }  
    }
}

