using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {
    public AudioSource point_sfx;

	void Start(){
		
	}
    void OnTriggerEnter(Collider other) // When Player gets a point
    {
		if(other.gameObject.name == "Player"){
			Debug.Log ("working");
            point_sfx = GameObject.Find ("ScoreSound").GetComponent<AudioSource>();
            ScoreSystem.AddPoint();
            MovementScript.SpeedUp();
		    point_sfx.Stop();
		    point_sfx.Play ();
            Destroy(this.gameObject);
		

		}
    }
}
