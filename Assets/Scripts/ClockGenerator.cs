using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockGenerator : MonoBehaviour {
	public GameObject Clock;
	public int ClockAmount;
	float spawnposZ = 100f;
	void Start () {
		SpawnClocks ();
	}
	
	void Update () {
		
	}
	void SpawnClocks(){
		for(int i = 0; i < ClockAmount; i++){
		float TempX = Random.Range (-0.7f,0.7f);
		float TempY = Random.Range (-0.7f,0.7f);
			Instantiate(Clock, new Vector3(TempX, TempY, spawnposZ), Clock.transform.rotation);
			spawnposZ += 500f;
		}
	}
}
