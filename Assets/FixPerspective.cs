using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPerspective : MonoBehaviour {
	CharacterController cctrl;
	void Start(){
		cctrl = GetComponent<CharacterController> ();
	}
	void Update(){
		if (MovementScript.PlayerDeath == false)
		{
			cctrl.Move(Vector3.forward * Time.deltaTime * MovementScript.ForwardSpeed);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "Enemy" || col.tag == "Point"){
			Destroy (col.gameObject);
		}
	}
}
