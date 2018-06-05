using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public ParticleSystem explosion_particle;
	public AudioSource audiSrc;
	void Start(){
		
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player") //Detect player to deal damage or to kill
        {
            Debug.Log("Enemy collision");
            audiSrc = GameObject.Find("DieSound").GetComponent<AudioSource>();
            //Destroy(other.gameObject);
            //Destroy(this.gameObject);
            MovementScript.PlayerDeath = true;
            //playsound
			PlayParticle();
			audiSrc.Play();
		
        }
        
    }
	void PlayParticle(){
		Debug.Log ("Playing");
		//explosion_particle.Play ();
	}
}
