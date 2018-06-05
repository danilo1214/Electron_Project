using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject Player_ob;
    public float distance_to_player;
	CharacterController camcctrl;

	void Start(){
		camcctrl = GetComponent<CharacterController> ();
	}
	// Update is called once per frame
	void Update () {
        if (MovementScript.PlayerDeath == false)
        {
            //Vector3 cameraPos = new Vector3(0,0,Player_ob.transform.position.z - distance_to_player);
            //transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, Player_ob.transform.position.z), Time.deltaTime);

			camcctrl.Move(Vector3.forward * Time.deltaTime * MovementScript.ForwardSpeed);
        }
    }
}
