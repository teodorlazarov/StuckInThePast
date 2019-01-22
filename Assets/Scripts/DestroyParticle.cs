using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {

    private  ParticleSystem currentParticleSystem;

	void Start () {
        currentParticleSystem = GetComponent<ParticleSystem>();
	}
	
	void Update () {
        if (currentParticleSystem.isPlaying)
        {
            return;
        }
        Destroy(gameObject);
	}
}
